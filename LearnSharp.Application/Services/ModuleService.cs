using LearnSharp.Application.Dtos;
using LearnSharp.Application.Services.Interfaces;
using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.UnitOfWorks;

namespace LearnSharp.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ModuleDto>> GetAllModulesWithCoursesAsync()
        {
            var modules = await _unitOfWork.Modules.GetAllModulesWithCoursesAsync();

            return modules.Select(m => new ModuleDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                DateCreated = m.DateCreated,
            });
        }

        public async Task<ModuleDto> GetModuleByNameAsync(string name)
        {
            var module = await _unitOfWork.Modules.GetModuleByNameAsync(name);

            return new ModuleDto
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                DateCreated = module.DateCreated,
            };
        }

        public async Task<IEnumerable<ModuleDto>> GetModulesByCourseIdAsync(Guid courseId)
        {
            var modules = await _unitOfWork.Modules.GetModulesByCourseIdAsync(courseId);

            return modules.Select(m => new ModuleDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                DateCreated = m.DateCreated,
            });
        }

        public async Task<ModuleDto> GetModuleWithClassesAsync(Guid id)
        {
            var module = await _unitOfWork.Modules.GetModuleWithClassesAsync(id);

            return new ModuleDto
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                DateCreated = module.DateCreated,
            };
        }

        public async Task<bool> CreateModuleAsync(ModuleDto moduleInput)
        {
            try
            {
                var module = new Module
                {
                    Id = moduleInput.Id,
                    Name = moduleInput.Name,
                    Description = moduleInput.Description,
                    DateCreated = moduleInput.DateCreated,
                };

                await _unitOfWork.Modules.AddAsync(module);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateModuleAsync(ModuleDto moduleInput)
        {
            try
            {
                var module = new Module
                {
                    Id = moduleInput.Id,
                    Name = moduleInput.Name,
                    Description = moduleInput.Description,
                    DateCreated = moduleInput.DateCreated,
                };

                await _unitOfWork.Modules.UpdateAsync(module);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteModuleAsync(Guid idModule)
        {
            try
            {
                await _unitOfWork.Modules.DeleteAsync(idModule);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}