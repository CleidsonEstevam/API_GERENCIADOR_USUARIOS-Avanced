<h1 align="center">API de gerenciamento de usuários</h1>

<h1 align="center">
<img src="https://github.com/CleidsonEstevam/API_MANAGER/blob/main/src/5%20-%20Manager.Core/Images/Design%20sem%20nome.jpg" height="400" width="400"/>
</h1>
<p align="center">API para validação e controle de cadastro de usuários, com foco em domínios ricos e boas práticas de arquitetura.</p>

<p align="center" height="400" width="400">
 <a href="#objetivo">Objetivo</a> •
 <a href="#tecnologias">Tecnologias</a> •
 <a href="#config">Configurações</a> •
 <a href="#pacotes">Pacotes</a> •
 <a href="#metodos">Métodos da API</a> •
 <a href="#autor">Autor</a> •
</p>

<h4 align="center"> 
	🚧  Projeto Finalizado!...Mas, aberto para possíveis Updates/Upgrades 🚧
</h4>

<h3 id="objetivo">✅ Objetivo:</h3>
<p>A API foi desenvolvida com o objetivo de aplicar padrões de projetos, arquitetura em camadas e boas práticas, as tecnologias foram empregadas visando escalabilidade e performace, foi desenvolvido apenas uma entidade para que o entendimento fosse mais limpo e focado nas tecnologias e padrões, podendo ser replicado em sistemas maiores posteriormente.<p/>
<br/>
<h3 id="tecnologias">✅ Tecnologias e padrões:</h3>
<p>- .NET 5 <p/>
<p>- C# <p/>
<p>- EF Framework Core<p/>
<p>- Modelagem de dados EF <p/>
<p>- Autenticação com JWT <p/>
<p>- FluentValidation </p>
<p>- Repository Patterns </p>
<p>- Reposyto Patterns </p>
<p>- Notify Patterns </p>
<p>- Arquitetura em Camadas </p>
<p>- Cloud: Azure para armazenamento da API </p>
<br/>
<h3 id="config">✅ Configurações necessárias:</h3>
Para poder rodar o projeto você precisa configurar algumas variaveis de ambiente:
<br/>
<p>Iniciar os segredos: dotnet user-secrets init<p/>
<p>Configurar a string de conexão: dotnet user-secrets set "ConnectionStrings:USER_MANAGER" "[STRING CONNECTION]"<p/>
<p>Configurar dados de autenticação (JWT): <p/>
<p>dotnet user-secrets set "Jwt:Key" "[JWT CRYPTOGRAPHY KEY]"<p/>
<p>dotnet user-secrets set "Jwt:Login" "[JWT LOGIN]"<p/>
<p>dotnet user-secrets set "Jwt:Password" "[JWT PASSWORD]"<p/>
<p>Configurar a chave de criptografia: dotnet user-secrets set "Cryptography" "[CHAVE DE CRIPTOGRAFIA DA APLICAÇÃO]"
<br/>
<br/>
<h3 id="pacotes">✅ Pacotes:</h3>
Foi utilizado alguns pacotes na camada de API para auxílio dos métodos:
<p>- Automapper" Version="11.0.0"<p/>
<p>- Azure.Identity" Version="1.5.0" <p/>
<p>- Azure.Security.KeyVault.Secrets" Version="4.2.0" <p/>
<p>- EscNet" Version="1.0.1" <p/>
<p>- Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0" <p/>
<p>- Microsoft.AspNetCore.Authentication.OpenIdConnect" Version="5.0" <p/>
<p>- Microsoft.Extensions.Configuration.AzureKeyVault" Version="3.1.22" <p/>
<p>- Swashbuckle.AspNetCore" Version="5.6.3" <p/>
<br/>
<h3 id="pacotes">✅ Métodos da API:</h3>
<p>Login para geração de TOKEN [POST]<p/>
<p>Create [POST]<p/>
<p>Update [PUT]<p/>
<p>Delete [DELETE]<p/>
<p>Get por Id [GET]<p/>
<p>Get de todos usuários [GET]<p/>
<p>Search por Nome [GET]<p/>
<p>Search por Email [GET]<p/>
<br/>
<h3 id="autor">✅ Autor:</h3>
 <p>Cleidson Estevam<p/>
 <p>Desenvolvedor .NET<p/>
 <p>cleidsonestevamdasilva@hotmail.com<p>












