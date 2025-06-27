using LearnSharp.Application.Dtos;
using LearnSharp.Application.Services.Interfaces;
using LearnSharp.Infra.Sql.UnitOfWorks;

namespace LearnSharp.Application.Services
{
    public class UserClassCompletedService : IUserClassCompletedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserClassCompletedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserClassCompletedDto> GetByUserAndClassAsync(Guid userId, Guid classId)
        {
            var repository = await _unitOfWork.UserClassesCompleteds.GetByUserAndClassAsync(userId, classId);

            if (repository == null)
            {
                return null;
            }

            return new UserClassCompletedDto
            {
                Id = repository.Id,
                IdUser = repository.IdUser,
                IdClass = repository.IdClass,
                DateCompleted = repository.DateCompleted,
                Note = repository.Note
            };
        }

        public async Task<IEnumerable<UserClassCompletedDto>> GetByUserAsync(Guid userId)
        {
            var user = await _unitOfWork.UserClassesCompleteds.GetByUserAsync(userId);

            if (user is null)
            {
                return null;
            }

            return user.Select(uac => new UserClassCompletedDto
            {
                Id = uac.Id,
                IdUser = uac.IdUser,
                IdClass = uac.IdClass,
                DateCompleted = uac.DateCompleted,
                Note = uac.Note
            });
        }

        public async Task<bool> UserCompletedClassAsync(Guid userId, Guid classId)
        {
            try
            {
                var userExist = await GetByUserAndClassAsync(userId, classId);

                if (userExist == null)
                {
                    return false;
                }

                var completed = await _unitOfWork.UserClassesCompleteds.UserCompletedClassAsync(userId, classId);

                return completed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CompleteClassAsync(Guid userId, Guid classId, int note)
        {
            try
            {
                var userExist = await GetByUserAndClassAsync(userId, classId);

                if (userExist == null)
                {
                    return false;
                }

                await _unitOfWork.UserClassesCompleteds.CompleteClassAsync(userId, classId, note);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}