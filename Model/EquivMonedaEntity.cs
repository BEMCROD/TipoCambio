using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DesafioBCP.Model
{
    public class EquivMonedaEntity
    {
        [Key]
        public int Id { get; set; }
        public String MonedaOrigen { get; set; }
        public String MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }


    }
}
