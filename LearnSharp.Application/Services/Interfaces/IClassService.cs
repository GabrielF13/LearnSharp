using LearnSharp.Application.Dtos;

namespace LearnSharp.Application.Services.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> Get(CancellationToken cancellationToken);

        Task<ClassDto> GetById(Guid idModule, CancellationToken cancellationToken);

        Task<bool> Create(ClassDto inputClass, CancellationToken cancellationToken);

        Task<bool> Update(ClassDto inputClass, CancellationToken cancellationToken);

        Task<bool> Delete(Guid idModule, CancellationToken cancellationToken);
    }
}