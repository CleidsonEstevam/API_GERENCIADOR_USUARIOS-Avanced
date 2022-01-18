using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Core.Exceptions;
using EscNet.Cryptography.Interfaces;

namespace Manager.Services.Services
{
    public class UserServices : IUserService
    {  
        //Fazendo a injeção de dependencias
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRijndaelCryptography _rijndaelCryptography;

        public UserServices(IMapper mapper, IUserRepository userRepository, IRijndaelCryptography rijndaelCryptography)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _rijndaelCryptography = rijndaelCryptography;
        }

        public async Task<UserDTO> Crate(UserDTO userDto)
        {
            var userExists = await _userRepository.GetByEmail(userDto.Email);

            if(userExists != null)

            throw new DomainException("Usuário já cadastrado com esse e-mail."); 

            //Fazendo o De Para da DTO para a Entidade User
            var user = _mapper.Map<User>(userDto);
            user.Validate(); 
            user.ChangePassword(_rijndaelCryptography.Encrypt(user.Password)); 
            //Mandando entidade para o Repoitorio de criação
            //UserRepository retorna uma estancia de User
            var userCreated = await _userRepository.CreateAsync(user);
            //Retorno a estancia
            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetAsync(userDTO.Id);

            if(userExists == null)

            throw new DomainException("Usuário não existe."); 

            var user = _mapper.Map<User>(userDTO);
            
            user.Validate();
            user.ChangePassword(_rijndaelCryptography.Encrypt(user.Password)); 


            var userCreated = await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

         public async Task Remove(long id)
        {
            await _userRepository.RemoveAsync(id);
        }


        public async Task<UserDTO> Get(long id)
        {
           var allUsers = await _userRepository.GetAsync(id);

            return _mapper.Map<UserDTO>(allUsers);
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.GetAllAsync();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task<List<UserDTO>> SearchByName(string nome)
        {
           var allUsers = await _userRepository.SearchByName(nome);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var allUsers = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
             var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
    }
}