using LearnSharp.Application.Dtos;

namespace LearnSharp.Application.Services.Interfaces
{
    public interface IModuleService
    {
        Task<ModuleDto> GetModuleByNameAsync(string name);

        Task<IEnumerable<ModuleDto>> GetModulesByCourseIdAsync(Guid courseId);

        Task<ModuleDto> GetModuleWithClassesAsync(Guid id);

        Task<IEnumerable<ModuleDto>> GetAllModulesWithCoursesAsync();

        Task<bool> CreateModuleAsync(ModuleDto moduleInput);

        Task<bool> UpdateModuleAsync(ModuleDto moduleInput);

        Task<bool> DeleteModuleAsync(Guid idModule);
    }
}