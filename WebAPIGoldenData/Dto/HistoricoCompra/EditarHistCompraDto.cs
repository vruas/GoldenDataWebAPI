using System.ComponentModel.DataAnnotations;
using WebAPIGoldenData.Dto.LinkConsumidor;

namespace WebAPIGoldenData.Dto.HistoricoCompra
{
    public class EditarHistCompraDto
    {
        public int IdHistoricoCompra { get; set; }
        public string DataCompra { get; set; }
        public string ValorCompra { get; set; }

        LinkConsumidorDto Consumidor { get; set; }

    }
}
