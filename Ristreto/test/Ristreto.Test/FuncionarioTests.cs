using Ristreto.Application.DTO;
using Ristreto.Domain.Enum;
using Ristreto.Domain.Interfaces;
using Ristreto.Domain.Models;
using Ristreto.Domain.validations;
using Moq;
using Ristreto.Application;

namespace Ristreto.Test
{
    public class FuncionarioTests
    {
        [Fact]
        public void Funcionario_ValidarFuncionario_DeveEstarValido()
        {
            var funcionario = new Funcionario(
                 "Felix Gustavo Donel",
                 "Felixgustavodonel@gmail.com",
                 "Desenvolvedor",
                 DateTime.Now.AddYears(-30),
                 "FelixDonel",
                 "Senha123",
                 ESituacaoFuncionario.Ativo,
                 1
            );

            var validator = new FuncionarioValidator();

            var result = validator.Validate(funcionario);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("", "Felixgustavodonel@gmail.com", "Desenvolvedor", "Senha123", 1)]
        [InlineData("Felix Gustavo Donel", "", "Desenvolvedor", "Senha123", 1)]
        [InlineData("Felix Gustavo Donel", "Felixgustavodonel@gmail.com", "", "Senha123", 1)]
        [InlineData("Felix Gustavo Donel", "Felixgustavodonel@gmail.com", "Desenvolvedor", "", 1)]
        [InlineData("Felix Gustavo Donel", "invalid_email", "Desenvolvedor", "Senha123", 1)]
        public void Funcionario_ValidarFuncionario_DeveEstarinValido(string nome, string email, string cargo, string passwordHash, int empresaId)
        {
            var funcionario = new Funcionario(
            nome,
            email,
            cargo,
            DateTime.Now.AddYears(-30),
            "FelixDonel",
            passwordHash,
            ESituacaoFuncionario.Ativo,
            empresaId
        );

            var validator = new FuncionarioValidator();

            var result = validator.Validate(funcionario);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Funcionario_AtivarFuncionario_DeveEstarAtivo() {
            var funcionario = new Funcionario(
                 "Felix Gustavo Donel",
                 "Felixgustavodonel@gmail.com",
                 "Desenvolvedor",
                 DateTime.Now.AddYears(-30),
                 "FelixDonel",
                 "Senha123",
                 ESituacaoFuncionario.Inativo,
                 1
            );

            funcionario.Ativar();

            Assert.Equal(ESituacaoFuncionario.Ativo, funcionario.Situacao);
        }

        [Fact]
        public void Funcionario_DesativarFuncionario_DeveEstarDesativo()
        {
            var funcionario = new Funcionario(
                 "Felix Gustavo Donel",
                 "Felixgustavodonel@gmail.com",
                 "Desenvolvedor",
                 DateTime.Now.AddYears(-30),
                 "FelixDonel",
                 "Senha123",
                 ESituacaoFuncionario.Ativo,
                 1
            );

            funcionario.Desativar();

            Assert.Equal(ESituacaoFuncionario.Inativo, funcionario.Situacao);
        }

        [Fact]
        public async Task FuncionarioApplication_AdicionarFuncionarioComUserNameExistente_DeveLancarExcecao()
        {
            var mockRepositorioFuncionario = new Mock<IFuncionarioRepository>();
            mockRepositorioFuncionario.Setup(repo => repo.AnyUserName(It.IsAny<string>())).ReturnsAsync(true);

            var funcionario = FuncionarioDTOFactory.CreateDTO(new Funcionario(
                 "Felix Gustavo Donel",
                 "Felixgustavodonel@gmail.com",
                 "Desenvolvedor",
                 DateTime.Now.AddYears(-30),
                 "FelixDonel",
                 "Senha123",
                 ESituacaoFuncionario.Ativo,
                 1
            ));

            var aplicacao = new FuncionarioApplication(mockRepositorioFuncionario.Object);

            
            await Assert.ThrowsAsync<FluentValidation.ValidationException>(() => aplicacao.Add(funcionario));
        }
    }
}
