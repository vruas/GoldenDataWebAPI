using WebAPIGoldenData.Dto.Feedback;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.Feedback
{
    public interface IFeedbackInterface
    {
        Task<ResponseModel<List<FeedbackModel>>> ListarFeedBacks();
        Task<ResponseModel<FeedbackModel>> BuscarFeedbacksPorId(int idFeedback);
        Task<ResponseModel<List<FeedbackModel>>> BuscarFeedbackPorIdConsumidor(int idConsumidor);
        Task<ResponseModel<List<FeedbackModel>>> CriarFeedback(CriarFeedbackDto criarFeedbackDto);
        Task<ResponseModel<List<FeedbackModel>>> EditarFeedback(EditarFeedbackDto editarFeedbackDto);
        Task<ResponseModel<List<FeedbackModel>>> DeletarFeedback(int idFeedback);

    }
}
