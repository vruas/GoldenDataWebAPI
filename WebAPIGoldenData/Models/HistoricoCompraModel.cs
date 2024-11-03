using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIGoldenData.Models
{
    [Table("HISTORICO_COMPRA")]
    public class HistoricoCompraModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistoricoCompra { get; set; }
        [Required]
        public string DataCompra { get; set; }
        [Required]
        public string ValorCompra { get; set; }
        
        public ConsumidorModel Consumidor { get; set; }

        public ICollection<PagamentoModel> Pagamentos { get; set; }
    }
}
