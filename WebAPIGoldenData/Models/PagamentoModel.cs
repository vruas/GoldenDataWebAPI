using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIGoldenData.Models
{
    [Table("PAGAMENTO")]
    public class PagamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPagamento { get; set; }
        [Required]
        public string ValorPagamento { get; set; }
        [Required]
        public  string MetodoPagamento { get; set; }
        [Required]
        public string StatusPagamento { get; set; }

        [JsonIgnore]
        public HistoricoCompraModel HistoricoCompra { get; set; }
    }
}
