using System;
using System.Collections.Generic;
using DesafioBCP.Model;

namespace DesafioBCP.Business.Service
{
    public interface IConvMonedaService
    {

        decimal BuscarTipoCambio(String monedaOrigen, String monedaDestino);

		ConversionMonedaResponseDTO CalcularEquivalencia(ConversionMonedaRequestDTO dto);

		EquivMonedaEntity Save(EquivMonedaEntity entity);

		String Save(List<EquivMonedaEntity> entitys);

		EquivMonedaEntity Update(EquivMonedaEntity entity);

		List<EquivMonedaEntity> FindAll();

		String Delete(int id);

	}
}
