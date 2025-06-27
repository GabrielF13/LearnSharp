using LearnSharp.Application.Dtos;
using LearnSharp.Application.Services.Interfaces;
using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.UnitOfWorks;

namespace LearnSharp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.GetAllAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Birthdate = u.Birthdate,
                Email = u.Email,
                Document = u.Document,
                Cellphone = u.Cellphone,
                Role = u.Role,
                Active = u.Active
            });
        }

        public async Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Document = user.Document,
                Cellphone = user.Cellphone,
                Role = user.Role,
                Active = user.Active
            };
        }

        public async Task<UserDto> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Document = user.Document,
                Cellphone = user.Cellphone,
                Role = user.Role,
                Active = user.Active
            };
        }

        public async Task<UserDto> GetUserByDocumentAsync(string document, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByDocumentAsync(document);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Document = user.Document,
                Cellphone = user.Cellphone,
                Role = user.Role,
                Active = user.Active
            };
        }

        public async Task<bool> UserExistsAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            return true;
        }

        public async Task<bool> CreateUserAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            var existingUserByEmail = await _unitOfWork.Users.GetByEmailAsync(userDto.Email);

            if (existingUserByEmail != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Birthdate = userDto.Birthdate,
                Password = userDto.Password,
                Email = userDto.Email,
                Document = userDto.Document,
                Cellphone = userDto.Cellphone,
                Role = userDto.Role,
                Active = userDto.Active
            };

            var result = await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.Users.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            try
            {
                var emailExists = await _unitOfWork.Users.GetByEmailAsync(userDto.Email);

                if (emailExists != null)
                {
                    throw new InvalidOperationException("A user with this email already exists.");
                }

                var user = new User
                {
                    Id = userDto.Id,
                    Name = userDto.Name,
                    Birthdate = userDto.Birthdate,
                    Email = userDto.Email,
                    Document = userDto.Document,
                    Cellphone = userDto.Cellphone,
                    Role = userDto.Role,
                    Active = userDto.Active
                };

                await _unitOfWork.Users.UpdateAsync(user);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);

                if (user == null)
                {
                    throw new InvalidOperationException("User not found.");
                }

                await _unitOfWork.Users.DeleteAsync(userId);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}