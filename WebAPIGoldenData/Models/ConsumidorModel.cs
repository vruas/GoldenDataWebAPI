using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace WebAPIGoldenData.Models
{
    [Table("CONSUMIDOR")]
    public class ConsumidorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsumidor { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Estado { get; set; }

        [JsonIgnore]
        public ICollection<InfoConsumidorModel> InfosConsumidor { get; set; }
    }
}
