using AutoMapper;
using Moq;
using Manager.Services.Interfaces;
using Manager.Infra.Interfaces;
using EscNet.Cryptography.Interfaces;
using Manager.Services.Services;
using Manager.Tests.Configurations;
using Xunit;
using Manager.Services.DTO;
using Manager.Domain.Entities;
using Bogus.DataSets;
using System.Linq.Expressions;
using System;
using FluentAssertions;
using System.Threading.Tasks;
using Manager.Tests.Fixtures;

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
        _mapper = AutoMapperConfiguration.GetConfiguration() ;
        _userRepositoryMock = new Mock<IUserRepository>();
        _rijndaelCryptographyMock = new Mock<IRijndaelCryptography>();

          _sut = new UserServices(
                mapper: _mapper,
                userRepository: _userRepositoryMock.Object,
                rijndaelCryptography: _rijndaelCryptographyMock.Object);
     }  
     
        //METODO_CONDICAO_RESULTADOESPERADO
      [Fact(DisplayName = "Create Valid User")]
     public async Task Create_WhenUserIsValid_ReturnsUserDTO()
      {
          // ARRANGE -- REUNE O TESTE 
           // var userToCreate = new UserDTO{Name = "Cleidson", Email = "teste@gmail.com", Password = "123321321"}; //Criando com instancia
           var userToCreate = UserFixture.CreateValidUserDTO();
           

           var encryptedPassword = new Lorem().Sentence();
            var userCreated = _mapper.Map<User>(userToCreate);
             userCreated.ChangePassword(encryptedPassword);

           _userRepositoryMock.Setup(x => x.GetAsync(
                 It.IsAny<long>()))
            .ReturnsAsync(() => null);

            _rijndaelCryptographyMock.Setup(x => x.Encrypt(It.IsAny<string>()))
                .Returns(encryptedPassword);

            _userRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(() => userCreated);
              
          // ACT -- REALIZA AS CHAMADAS 
            var result = await _sut.Crate(userToCreate);

          //ASSERT  -- VERIFICA O RESULTADO
         //Assert.Equal(result, userToCreate); --  Metodo de retorno padrão
         //Metodo da bilioteca fluentassertions
         result.Should()
                    .BeEquivalentTo(_mapper.Map<UserDTO>(userCreated));
      }  

        




    }
    
}