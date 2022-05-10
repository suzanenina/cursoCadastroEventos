using System;
using System.Threading.Tasks;
using AutoMapper;
using CadastroEventos.Application.Dtos;
using CadastroEventos.Domain;
using CadastroEventos.Persistence.Contrato;

namespace CadastroEventos.Application.Contratos
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPalestrantePersist _palestrantePersist;

        private readonly IMapper _mapper;

        public PalestranteService(IGeralPersist geralPersist, IPalestrantePersist palestrantePersist, IMapper mappper)
        {
            _palestrantePersist = palestrantePersist;
            _geralPersist = geralPersist;
            _mapper = mappper;
        }

        public async Task<PalestranteDto[]> GetAllPalestrantesAsync(bool includeEventos)
        {
           var palestrantes = await _palestrantePersist.GetAllPalestrantesAsync(includeEventos);
           
            if(palestrantes == null) return null;

            return _mapper.Map<PalestranteDto[]>(palestrantes);
        }

        public async Task<PalestranteDto> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
           var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(PalestranteId, includeEventos);
           
            if(palestrante == null) return null;

            return _mapper.Map<PalestranteDto>(palestrante);
        }

        public async Task<PalestranteDto[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            var palestrantes = await _palestrantePersist.GetAllPalestrantesByNomeAsync(nome, includeEventos);
           
            if(palestrantes == null) return null;

            return _mapper.Map<PalestranteDto[]>(palestrantes);
        }
    }
}