using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGoldenData.Dto.Feedback;
using WebAPIGoldenData.Models;
using WebAPIGoldenData.Services.Feedback;

namespace WebAPIGoldenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackInterface _feedbackInterface;

        public FeedbackController(IFeedbackInterface feedbackInterface)
        {
            _feedbackInterface = feedbackInterface;
        }

        [HttpGet("ListarFeedbacks")]
        public async Task<ActionResult<ResponseModel<FeedbackModel>>> ListarFeedBacks()
        {
            var feedbacks = await _feedbackInterface.ListarFeedBacks();
            return Ok(feedbacks);
        }

        [HttpGet("BuscarFeedbackPorId/{idFeedback}")]
        public async Task<ActionResult<ResponseModel<FeedbackModel>>> BuscarFeedbacksPorId(int idFeedback)
        {
            var feedback = await _feedbackInterface.BuscarFeedbacksPorId(idFeedback);
            return Ok(feedback);
        }

        [HttpGet("BuscarFeedbackPorIdConsumidor/{idConsumidor}")]
        public async Task<ActionResult<ResponseModel<List<FeedbackModel>>>> BuscarFeedbackPorIdConsumidor(int idConsumidor)
        {
            var feedback = await _feedbackInterface.BuscarFeedbackPorIdConsumidor(idConsumidor);
            return Ok(feedback);
        }

        [HttpPost("CriarFeedback")]
        public async Task<ActionResult<ResponseModel<List<FeedbackModel>>>> CriarFeedback(CriarFeedbackDto criarFeedbackDto)
        {
            var feedback = await _feedbackInterface.CriarFeedback(criarFeedbackDto);
            return Ok(feedback);
        }

        [HttpPut("EditarFeedback")]
        public async Task<ActionResult<ResponseModel<List<FeedbackModel>>>> EditarFeedback(EditarFeedbackDto editarFeedbackDto)
        {
            var feedback = await _feedbackInterface.EditarFeedback(editarFeedbackDto);
            return Ok(feedback);
        }

        [HttpDelete("DeletarFeedback")]
        public async Task<ActionResult<ResponseModel<List<FeedbackModel>>>> DeletarFeedback(int idFeedback)
        {
            var feedback = await _feedbackInterface.DeletarFeedback(idFeedback);
            return Ok(feedback);
        }


    }
}
