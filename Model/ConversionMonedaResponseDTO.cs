using System;
namespace DesafioBCP.Model
{
    public class ConversionMonedaResponseDTO: ConversionMonedaRequestDTO
    {

        public decimal MontoCalculadoDTO { get; set; }
        public decimal TipoCambioDTO { get; set; }

    }
}
