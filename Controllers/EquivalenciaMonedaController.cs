using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioBCP.BD;
using DesafioBCP.Business.Implement;
using DesafioBCP.Business.Service;
using DesafioBCP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace DesafioBCP.Controllers
{
    [ApiController]
    [Route("v1/tipoCambio")]
    public class EquivalenciaMonedaController: ControllerBase
    {
        private readonly IConvMonedaService service;

        public EquivalenciaMonedaController(BDContext context)
        {
            service = new ConvMonedaImpl(context);
        }

        [HttpGet("buscarTipoCambio")]
        public ActionResult<decimal> BuscarTipoCambio(String monedaOrigen, String monedaDestino)
        {

            return service.BuscarTipoCambio(monedaOrigen, monedaDestino);
        }


        [HttpPost("crearTipoCambio")]
        public ActionResult<EquivMonedaEntity> CrearTipoCambio([FromBody] EquivMonedaEntity entity)
        {

            return service.Save(entity);
        }

        [HttpPost("crearTipoCambioLista")]
        public ActionResult<String> CrearTipoCambioLista([FromBody] List<EquivMonedaEntity> entity)
        {

            return service.Save(entity);
        }

        [HttpPost("calcularCambio")]
        public ActionResult<ConversionMonedaResponseDTO> CalcularTipoCambio([FromBody] ConversionMonedaRequestDTO dto)
        {

            return service.CalcularEquivalencia(dto);
        }


        [HttpGet("listarTodo")]
        public ActionResult<List<EquivMonedaEntity>> listarTodo()
        {

            return service.FindAll();
        }

        [HttpDelete("deleteById")]
        public ActionResult<String> delete(int id)
        {

            return service.Delete(id);
        }

    }
}
