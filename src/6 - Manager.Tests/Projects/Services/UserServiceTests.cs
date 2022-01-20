using AutoMapper;
using Moq;
using Manager.Services.Interfaces;
using Manager.Infra.Interfaces;
using EscNet.Cryptography.Interfaces;
using Manager.Services.Services;
using Manager.Tests.Configurations;

namespace Manager.Tests.Projects.Services
{
    public class UserServiceTests
    {
        // //O obj que sera testado
        private readonly IUserService _sut;

        private readonly IMapper _mapper;
        #region "Mokes"
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IRijndaelCryptography> _rijndaelCryptographyMock;

        #endregion

     public UserServiceTests()
     {
        _mapper = AutoMapperConfiguration.GetConfiguration();
        _userRepositoryMock = new Mock<IUserRepository>();
        _rijndaelCryptographyMock = new Mock<IRijndaelCryptography>();

          _sut = new UserServices(
                mapper: _mapper,
                userRepository: _userRepositoryMock.Object,
                rijndaelCryptography: _rijndaelCryptographyMock.Object
        );
     }
    }
}