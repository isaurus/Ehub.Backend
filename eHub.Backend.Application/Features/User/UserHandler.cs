using AutoMapper;
using eHub.Backend.Application.Features.User.Commands;
using eHub.Backend.Application.Features.User.Queries;
using eHub.Backend.Domain.Contracts.Repositories;
using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User
{
    public class UserHandler(IMapper mapper, IUserRepository userRepository) :
        IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseModel>>,
        IRequestHandler<GetUserByIdQuery, UserResponseModel?>,
        IRequestHandler<CreateUserCommand, OkResponseModel>,
        IRequestHandler<DeleteUserCommand, OkResponseModel?>,
        IRequestHandler<UpdateUserCommand, OkResponseModel?>
    {

        private readonly IMapper _mapper = mapper;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<IEnumerable<UserResponseModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return (IEnumerable<UserResponseModel>)_mapper.Map(request, users);
        }

        public async Task<UserResponseModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserResponseModel>(user);    // ¿USAR EL OTRO MAPPER?
        }

        public async Task<OkResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);
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
            var existingGame = await _userRepository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException($"El usuario con ID {request.Id} no ha sido encontrado.");

            _mapper.Map(request, existingGame);

            return new OkResponseModel
            {
                Id = request.Id,
                Message = "El usuario se ha actuailzado con éxito."
            };
        }
    }
}
