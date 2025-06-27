using LearnSharp.Application.Dtos;
using LearnSharp.Application.Services.Interfaces;
using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.UnitOfWorks;

namespace LearnSharp.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDto> GetByNameAsync(string name)
        {
            var course = await _unitOfWork.Courses.GetByNameAsync(name);
            if (course == null)
            {
                return null;
            }

            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                DateCreated = course.DateCreated,
            };
        }

        public async Task<IEnumerable<CourseDto>> GetBySubscriptionAsync(Guid courseId)
        {
            var courses = await _unitOfWork.Courses.GetBySubscriptionAsync(courseId);

            if (courses == null || !courses.Any())
            {
                return null;
            }

            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                DateCreated = c.DateCreated,
                Modules = c.Module.Select(m => new ModuleDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    DateCreated = m.DateCreated
                }).ToList(),
                Subscriptions = c.Subscription.Select(s => new SubscriptionDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Duration = s.Duration,
                }).ToList()
            });
        }

        public async Task<CourseDto> GetWithModulesAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetWithModulesAsync(id);

            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                DateCreated = course.DateCreated,
                Modules = course.Module.Select(m => new ModuleDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    DateCreated = m.DateCreated
                }).ToList()
            };
        }

        public async Task<bool> CreateCourseAsync(CourseDto courseDto, CancellationToken cancellationToken)
        {
            try
            {
                var course = new Course
                {
                    Id = Guid.NewGuid(),
                    Name = courseDto.Name,
                    Description = courseDto.Description,
                    DateCreated = DateTime.UtcNow
                };

                await _unitOfWork.Courses.AddAsync(course);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCourseAsync(CourseDto courseDto, CancellationToken cancellationToken)
        {
            try
            {
                var course = new Course
                {
                    Id = Guid.NewGuid(),
                    Name = courseDto.Name,
                    Description = courseDto.Description,
                    DateCreated = DateTime.UtcNow
                };

                await _unitOfWork.Courses.UpdateAsync(course);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCourseAsync(Guid courseId, CancellationToken cancellationToken)
        {
            try
            {
                var course = await _unitOfWork.Courses.GetByIdAsync(courseId);

                if (course == null)
                {
                    return false; // Course not found
                }

                await _unitOfWork.Courses.DeleteAsync(courseId);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}