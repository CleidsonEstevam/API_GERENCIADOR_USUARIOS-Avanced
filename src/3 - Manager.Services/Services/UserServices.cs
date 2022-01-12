using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Core.Exceptions;
namespace Manager.Services.Services
{
    public class UserServices : IUserService
    {  
        //Fazendo a injeção de dependencias
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Crate(UserDTO userDto)
        {
            var userExists = await _userRepository.GetByEmail(userDto.Email);

            if(userExists != null)

            throw new DomainException("Usuário já cadastrado com esse e-mail."); 

            //Fazendo o De Para da DTO para a Entidade User
            var user = _mapper.Map<User>(userDto);
            user.Validate();
            //Mandando entidade para o Repoitorio de criação
            //UserRepository retorna uma estancia de User
            var userCreated = await _userRepository.CreateAsync(user);
            //Retorno a estancia
            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserDTO>> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserDTO>> SearchByName(string Name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDTO> Update(UserDTO userDto)
        {
            throw new System.NotImplementedException();
        }
    }
}