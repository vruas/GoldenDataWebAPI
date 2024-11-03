using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIGoldenData.Models
{
    [Table("FEEDBACK")]
    public class FeedbackModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFeedback { get; set; }
        [Required]
        public string Comentario { get; set; }
        [Required]
        public float Avaliacao { get; set; }

        [JsonIgnore]
        public ConsumidorModel Consumidor { get; set; }

    }
}
