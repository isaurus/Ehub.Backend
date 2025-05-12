using AutoMapper;
using eHub.Backend.Application.Features.User.Commands;
using eHub.Backend.Application.Features.User.Queries;
using eHub.Backend.Domain.Contracts.Repositories;
using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User
{
    public class UserHandler(
        IMapper mapper, IUserRepository userRepository, IPasswordHasherService passwordHasher, IAuthService authService) :
        IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseModel>>,
        IRequestHandler<GetUserByIdQuery, UserResponseModel?>,
        IRequestHandler<CreateUserCommand, OkResponseModel>,
        IRequestHandler<DeleteUserCommand, OkResponseModel?>,
        IRequestHandler<UpdateUserCommand, OkResponseModel?>,
        IRequestHandler<RegisterUserCommand, OkResponseModel>,
        IRequestHandler<CompleteUserProfileCommand, OkResponseModel>,
        IRequestHandler<LoginUserCommand, AuthResponseModel?>
    {

        private readonly IMapper _mapper = mapper;
        private readonly IUserRepository _userRepository = userRepository;

        private readonly IPasswordHasherService _passwordHasher = passwordHasher;
        private readonly IAuthService _authService = authService;

        public async Task<IEnumerable<UserResponseModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseModel>>(users);
        }

        public async Task<UserResponseModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserResponseModel>(user);
        }

        public async Task<OkResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request.Model);
            await _userRepository.AddAsync(user);

            return new OkResponseModel
            {
                Id = user.Id,
                Message = "Usuario creado con éxito."
            };
        }

        public async Task<OkResponseModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(request.Id);
            return new OkResponseModel
            {
                Id = request.Id,
                Message = "Usuario borrado con éxito."
            };
        }

        public async Task<OkResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException($"El usuario con ID {request.Id} no ha sido encontrado.");

            _mapper.Map(request.Model, existingUser);

            await _userRepository.UpdateAsync(request.Id, existingUser);

            return new OkResponseModel
            {
                Id = request.Id,
                Message = "El usuario se ha actuailzado con éxito."
            };
        }





        public async Task<OkResponseModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request.Model);

            user.PasswordHash = _passwordHasher.Hash(request.Model.Password);       // Lógica para hashear contraseña

            await _userRepository.AddAsync(user);

            return new OkResponseModel
            {
                Id = user.Id,
                Message = "Primera fase de registro completada con éxito."
            };
        }

        public async Task<OkResponseModel> Handle(CompleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException($"El usuario con ID {request.Id} no ha sido encontrado.");

            _mapper.Map(request.Model, existingUser);

            await _userRepository.UpdateAsync(request.Id, existingUser);

            return new OkResponseModel
            {
                Id = existingUser.Id,
                Message = "Operación de registro completada con éxito."
            };
        }

        public async Task<AuthResponseModel?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Model.Email)
                ?? throw new KeyNotFoundException($"El usuario con email {request.Model.Email} no ha sido encontrado.");

            var isPasswordValid = _passwordHasher.Verify(request.Model.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Credenciales incorrectas");
            }
            else
            {
                var userModel = _mapper.Map<UserModel>(user);
                var token = _authService.GenerateJwtToken(userModel);

                return new AuthResponseModel
                {
                    Token = token,
                    Email = user.Email,
                    FullName = $"{user.FirstName} {user.LastName}"
                };
            }
        }
    }
}
