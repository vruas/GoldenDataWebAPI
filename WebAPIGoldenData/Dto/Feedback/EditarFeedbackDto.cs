using WebAPIGoldenData.Dto.LinkConsumidor;

namespace WebAPIGoldenData.Dto.Feedback
{
    public class EditarFeedbackDto
    {
        public int IdFeedback { get; set; }
        public string Comentario { get; set; }
        public float Avaliacao { get; set; }

        public LinkConsumidorDto Consumidor { get; set; }
    }
}
