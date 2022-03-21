using System;
using System.Collections.Generic;
using System.Linq;
using DesafioBCP.BD;
using DesafioBCP.Business.Service;
using DesafioBCP.Model;

namespace DesafioBCP.Business.Implement
{
    public class ConvMonedaImpl : IConvMonedaService
    {
        private readonly BDContext _context;

        public ConvMonedaImpl(BDContext context)
        {
            _context = context;
        }

        public decimal BuscarTipoCambio(string monedaOrigen, string monedaDestino)
        {
            return BuscarTipoCambioSimple(monedaOrigen, monedaDestino);
        }

        public ConversionMonedaResponseDTO CalcularEquivalencia(ConversionMonedaRequestDTO dto)
        {
            return CalcularEquivalenciaSimple(dto);
        }

        public string Delete(int id)
        {
            EquivMonedaEntity entity = _context.EquivMonedaEnt.Find(id);

            _context.EquivMonedaEnt.Remove(entity);

            return "OK";
           
        }

        public List<EquivMonedaEntity> FindAll()
        {
            return _context.EquivMonedaEnt.ToList();
        }

        public EquivMonedaEntity Save(EquivMonedaEntity entity)
        {
            return SaveSimple(entity);
        }

        public string Save(List<EquivMonedaEntity> entitys)
        {
            entitys.ForEach(item =>
            {
                SaveSimple(item);
            });

            return "OK";
        }

        public EquivMonedaEntity Update(EquivMonedaEntity entity)
        {
            return SaveSimple(entity);
        }

        private decimal BuscarTipoCambioSimple(String monedaOrigen, String monedaDestino)
        {

            var list = _context.EquivMonedaEnt.Where(obj => obj.MonedaOrigen == monedaOrigen && obj.MonedaDestino == monedaDestino).ToList();

            EquivMonedaEntity result = null;

            if(list.Count != 0){
                result = list.First();
            }

            if (result != null)
            {
                return result.TipoCambio;
            }

            list = _context.EquivMonedaEnt.Where(obj => obj.MonedaOrigen == monedaDestino && obj.MonedaDestino == monedaOrigen).ToList();

            if (list.Count != 0)
            {
                result = list.First();
            }

            if (result != null)
            {
                return Math.Round(1 / result.TipoCambio * 100) / 100;
            }

            return 0;
        }


        private ConversionMonedaResponseDTO CalcularEquivalenciaSimple(ConversionMonedaRequestDTO dto)
        {

            decimal tipoCambio = BuscarTipoCambioSimple(dto.MonedaOrigenDTO, dto.MonedadDestinoDTO);

            if (tipoCambio != 0)
            {

                ConversionMonedaResponseDTO result = new ConversionMonedaResponseDTO();

                result.MonedadDestinoDTO = dto.MonedadDestinoDTO;
                result.MonedaOrigenDTO = dto.MonedaOrigenDTO;
                result.MontoCalculadoDTO = dto.MontoDTO * tipoCambio;
                result.MontoDTO = dto.MontoDTO;
                result.TipoCambioDTO = tipoCambio;

                return result;
            }

            return null;
        }

        private EquivMonedaEntity SaveSimple(EquivMonedaEntity entity)
        {

            var list = _context.EquivMonedaEnt.Where(obj => obj.MonedaOrigen == entity.MonedaOrigen && obj.MonedaDestino == entity.MonedaDestino).ToList();

            EquivMonedaEntity result = null;

            if (list.Count != 0)
            {
                result = list.First();
            }

            if (result != null)
            {
                entity.Id = result.Id;
                _context.SaveChanges();

                return entity;
            }

            list = _context.EquivMonedaEnt.Where(obj => obj.MonedaOrigen == entity.MonedaDestino && obj.MonedaDestino == entity.MonedaOrigen).ToList();

            if (list.Count != 0)
            {
                result = list.First();
            }

            if (result != null)
            {
                entity.Id = result.Id;
                _context.SaveChanges();

                return entity;
            }

            _context.EquivMonedaEnt.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
