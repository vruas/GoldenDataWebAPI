using Microsoft.EntityFrameworkCore;
using WebAPIGoldenData.Data;
using WebAPIGoldenData.Dto.Feedback;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.Feedback
{
    public class FeedbackService : IFeedbackInterface
    {
        private readonly ApplicationDbContext _context;

        public FeedbackService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<FeedbackModel>>> ListarFeedBacks()
        {
            ResponseModel<List<FeedbackModel>> resposta = new ResponseModel<List<FeedbackModel>>();
            try
            {
                var feedbacks = await _context.Feedbacks.Include(c => c.Consumidor).ToListAsync();

                resposta.Dados = feedbacks;
                resposta.Mensagem = "Feedbacks listados com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<FeedbackModel>> BuscarFeedbacksPorId(int idFeedback)
        {
            ResponseModel<FeedbackModel> resposta = new ResponseModel<FeedbackModel>();
            try
            {
                var feedback = await _context.Feedbacks.Include(c => c.Consumidor).FirstOrDefaultAsync(cadFeed => cadFeed.IdFeedback == idFeedback);

                if (feedback == null)
                {
                    resposta.Mensagem = "Feedback não encontrado!";
                    return resposta;
                }

                resposta.Dados = feedback;
                resposta.Mensagem = "Feedback encontrado com sucesso!";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FeedbackModel>>> BuscarFeedbackPorIdConsumidor(int idConsumidor)
        {
            ResponseModel<List<FeedbackModel>> resposta = new ResponseModel<List<FeedbackModel>>();
            try
            {
                var feedback = await _context.Feedbacks
                     .Include(c => c.Consumidor)
                     .Where(cadFeed => cadFeed.Consumidor.IdConsumidor == idConsumidor).ToListAsync();

                if (feedback == null)
                {
                    resposta.Mensagem = "Feedback não encontrado!";
                    return resposta;
                }

                resposta.Dados = feedback;
                resposta.Mensagem = "Feedback encontrado com sucesso!";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FeedbackModel>>> CriarFeedback(CriarFeedbackDto criarFeedbackDto)
        {
            ResponseModel<List<FeedbackModel>> resposta = new ResponseModel<List<FeedbackModel>>();
            try
            {
                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == criarFeedbackDto.Consumidor.IdConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                var feedback = new FeedbackModel
                {
                    Comentario = criarFeedbackDto.Comentario,
                    Avaliacao = criarFeedbackDto.Avaliacao,
                    Consumidor = consumidor
                };

                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Feedbacks.Include(c => c.Consumidor).ToListAsync();
                resposta.Mensagem = "Feedback criado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FeedbackModel>>> EditarFeedback(EditarFeedbackDto editarFeedbackDto)
        {
            ResponseModel<List<FeedbackModel>> resposta = new ResponseModel<List<FeedbackModel>>();
            try
            {
                var feedback = await _context.Feedbacks.Include(c => c.Consumidor).FirstOrDefaultAsync(cadFeed => cadFeed.IdFeedback == editarFeedbackDto.IdFeedback);
                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == editarFeedbackDto.Consumidor.IdConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                if (feedback == null)
                {
                    resposta.Mensagem = "Feedback não encontrado!";
                    return resposta;
                }

                feedback.Comentario = editarFeedbackDto.Comentario;
                feedback.Avaliacao = editarFeedbackDto.Avaliacao;
                feedback.Consumidor = consumidor;

                _context.Feedbacks.Update(feedback);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Feedbacks.Include(c => c.Consumidor).ToListAsync();
                resposta.Mensagem = "Feedback editado com sucesso!";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FeedbackModel>>> DeletarFeedback(int idFeedback)
        {
            ResponseModel<List<FeedbackModel>> resposta = new ResponseModel<List<FeedbackModel>>();
            try
            {
                var feedback = await _context.Feedbacks.Include(c => c.Consumidor).FirstOrDefaultAsync(cadFeed => cadFeed.IdFeedback == idFeedback);

                if (feedback == null)
                {
                    resposta.Mensagem = "Feedback não encontrado!";
                    return resposta;
                }

                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Feedbacks.Include(c => c.Consumidor).ToListAsync();
                resposta.Mensagem = "Feedback deletado com sucesso!";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

    }
}
