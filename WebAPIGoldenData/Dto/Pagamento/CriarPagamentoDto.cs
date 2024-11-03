using System.ComponentModel.DataAnnotations;
using WebAPIGoldenData.Dto.LinkDto;

namespace WebAPIGoldenData.Dto.Pagamento
{
    public class CriarPagamentoDto
    {
        public string ValorPagamento { get; set; }
        public string MetodoPagamento { get; set; }
        public string StatusPagamento { get; set; }

        public LinkHistCompraDto HistoricoCompra { get; set; }

    }
}
