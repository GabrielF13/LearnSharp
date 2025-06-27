using LearnSharp.Application.Dtos;
using LearnSharp.Application.Services.Interfaces;
using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.UnitOfWorks;

namespace LearnSharp.Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClassDto>> Get(CancellationToken cancellationToken)
        {
            var classes = await _unitOfWork.Classes.GetAllAsync();

            return classes.Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Duration = c.Duration,
                IdModule = c.IdModule
            });
        }

        public async Task<ClassDto> GetById(Guid idModule, CancellationToken cancellationToken)
        {
            var classEntity = await _unitOfWork.Classes.GetByIdAsync(idModule);

            return new ClassDto
            {
                Id = classEntity.Id,
                Name = classEntity.Name,
                Description = classEntity.Description,
                LinkVideo = classEntity.LinkVideo,
                Duration = classEntity.Duration,
                IdModule = classEntity.IdModule
            };
        }

        public async Task<bool> Create(ClassDto inputClass, CancellationToken cancellationToken)
        {
            var classInput = new Class
            {
                Id = inputClass.Id,
                Name = inputClass.Name,
                Description = inputClass.Description,
                LinkVideo = inputClass.LinkVideo,
                Duration = inputClass.Duration,
                IdModule = inputClass.IdModule
            };

            var created = await _unitOfWork.Classes.AddAsync(classInput);
            await _unitOfWork.CompleteAsync();

            if (created == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Update(ClassDto inputClass, CancellationToken cancellationToken)
        {
            try
            {
                var classInput = new Class
                {
                    Id = inputClass.Id,
                    Name = inputClass.Name,
                    Description = inputClass.Description,
                    LinkVideo = inputClass.LinkVideo,
                    Duration = inputClass.Duration,
                    IdModule = inputClass.IdModule
                };

                await _unitOfWork.Classes.UpdateAsync(classInput);

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<bool> Delete(Guid idModule, CancellationToken cancellationToken)
        {
            var classEntity = await _unitOfWork.Classes.GetByIdAsync(idModule);

            if (classEntity == null)
            {
                return false;
            }

            try
            {
                await _unitOfWork.Classes.DeleteAsync(idModule);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}