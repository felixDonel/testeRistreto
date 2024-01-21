using FluentValidation;
using Ristreto.Application.DTO;
using Ristreto.Domain.Interfaces;
using Ristreto.Domain.Models;
using Ristreto.Domain.validations;

namespace Ristreto.Application
{
    public class EmpresaApplication : IEmpresaApplication
    {
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaApplication(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task Add(EmpresaDTO empresaDTO)
        {
            Empresa empresa = EmpresaDTOFactory.Create(empresaDTO);

            EmpresaValidator validator = new EmpresaValidator();
            validator.ValidateAndThrow(empresa);

            await _empresaRepository.Add(empresa);
        }
        public async Task Update(EmpresaDTO empresaDTO)
        {
                Empresa empresa = EmpresaDTOFactory.Create(empresaDTO);

                EmpresaValidator validator = new EmpresaValidator();
            validator.ValidateAndThrow(empresa);

            await _empresaRepository.Update(empresa);
        }
        public async Task Delete(int id)
        {
            if (!await _empresaRepository.EmpresaIsRegistered(id))
                throw new Exception("empresa não encontrada!");
            Empresa empresa = await _empresaRepository.GetById(id);
            _empresaRepository.Delete(empresa);
        }

        public async Task<IEnumerable<EmpresaDTO>> GetAll()
        {
            return (await _empresaRepository.GetAll()).Select(empresa => EmpresaDTOFactory.CreateDTO(empresa))
                                                      .ToList();
        }

        public async Task<EmpresaDTO> GetForId(int id)
        {
            return EmpresaDTOFactory.CreateDTO(await _empresaRepository.GetById(id));
        }
    }
}
