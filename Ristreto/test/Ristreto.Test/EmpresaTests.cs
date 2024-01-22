using Ristreto.Domain.Models;
using Ristreto.Domain.validations;

namespace Ristreto.Test
{
    public class EmpresaTests
    {

        [Fact]
        public void Empresa_ValidarCampos_ValidacaoCorreta()
        {
            var empresa = new Empresa("Nome Empresarial", "48984389996", "http://www.example.com");

            var validator = new EmpresaValidator();
            var result = validator.Validate(empresa);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Empresa_ValidarCampos_NomeEmpresarialObrigatorio()
        {
            var empresa = new Empresa("", "48984389996", "http://www.exemplo.com");

            var validator = new EmpresaValidator();

            var result = validator.Validate(empresa);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == nameof(empresa.NomeEmpresarial) && error.ErrorMessage == "O campo Nome Empresarial é obrigatório.");

        }

        [Fact]
        public void Empresa_ValidarCampos_TelefoneDeveSerValido()
        {
            // Arrange
            var empresa = new Empresa("Nome Empresarial", "123", "http://www.exemplo.com");
            var validator = new EmpresaValidator();

            // Act
            var result = validator.Validate(empresa);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == nameof(empresa.Telefone) && error.ErrorMessage == "Informe um número de telefone com DDD válido.");
        }

        [Fact]
        public void Empresa_ValidarCampos_URLDeveSerValida()
        {
            // Arrange
            var empresa = new Empresa("Nome Empresarial", "48984389996", "invalida");
            var validator = new EmpresaValidator();

            // Act
            var result = validator.Validate(empresa);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == nameof(empresa.URL) && error.ErrorMessage == "Informe uma URL válida começando com 'www.' e uma extensão de domínio válida.");
        }

    }
}