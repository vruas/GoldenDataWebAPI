using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIGoldenData.Models
{
    [Table("INFO_CONSUMIDOR")]
    public class InfoConsumidorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInfoConsumidor { get; set; }

        [Required]
        public string PreferenciaCompraCliente { get; set; }

        [Required]
        public string PreferenciaAnuncio { get; set; }

        [Required]
        public string MarcasEvitadas { get; set; }

        [Required]
        public string Hobbies { get; set; }

        [Required]
        public string AnunciosEvitados { get; set; }

        [Required]
        public string CompraOnline { get; set; }

        public ConsumidorModel Consumidor { get; set; }
    }
}
