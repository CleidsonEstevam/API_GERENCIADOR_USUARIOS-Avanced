using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Crate(UserDTO userDto);
        Task<UserDTO> Update(UserDTO userDto);
        Task Remove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> Get();
        Task<List<UserDTO>> SearchByName(string Name);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<UserDTO> GetByEmail(string email);


    }
}