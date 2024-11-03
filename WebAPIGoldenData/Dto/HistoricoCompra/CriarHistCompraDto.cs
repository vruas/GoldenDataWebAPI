using System.ComponentModel.DataAnnotations;
using WebAPIGoldenData.Dto.LinkConsumidor;

namespace WebAPIGoldenData.Dto.HistoricoCompra
{
    public class CriarHistCompraDto
    {
        public string DataCompra { get; set; }
        public string ValorCompra { get; set; }
        public LinkConsumidorDto Consumidor { get; set; } // Changed from private to public
    }
}
