using System;
namespace DesafioBCP.Model
{
    public class ConversionMonedaRequestDTO
    {
        public decimal MontoDTO { get; set; }
        public String MonedaOrigenDTO { get; set; }
        public String MonedadDestinoDTO { get; set; }
    }
}
