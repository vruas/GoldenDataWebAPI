using WebAPIGoldenData.Dto.Consumidor;
using WebAPIGoldenData.Models;
using WebAPIGoldenData.Data;
using Microsoft.EntityFrameworkCore;


namespace WebAPIGoldenData.Services.Consumidor
{
    public class ConsumidorService : IConsumidorInterface
    {
        private readonly ApplicationDbContext _context;

        public ConsumidorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ConsumidorModel>>> ListarConsumidores()
        {
            ResponseModel<List<ConsumidorModel>> resposta = new ResponseModel<List<ConsumidorModel>>();
            try
            {
                var consumidores = await _context.Consumidores.ToListAsync();

                resposta.Dados = consumidores;
                resposta.Mensagem = "Todos os consumidores foram pesquisados!";
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<ConsumidorModel>> BuscaConsumidorPorId(int idConsumidor)
        {
            ResponseModel<ConsumidorModel> resposta = new ResponseModel<ConsumidorModel>();
            try
            {
                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == idConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                resposta.Dados = consumidor;
                resposta.Mensagem = "Consumidor encontrado!";
                return resposta;

            }
            catch (Exception e)
            {

                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConsumidorModel>>> CadastrarConsumidor(CriarConsumidorDto criarConsumidorDto)
        {
            ResponseModel<List<ConsumidorModel>> resposta = new ResponseModel<List<ConsumidorModel>>();
            try
            {
                var consumidor = new ConsumidorModel()
                {
                    Nome = criarConsumidorDto.Nome,
                    CPF = criarConsumidorDto.CPF,
                    Email = criarConsumidorDto.Email,
                    Senha = criarConsumidorDto.Senha,
                    Sexo = criarConsumidorDto.Sexo,
                    Estado = criarConsumidorDto.Estado
                };

                _context.Add(consumidor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consumidores.ToListAsync();
                resposta.Mensagem = "Consumidor cadastrado com sucesso!";

                return resposta;
            }
            catch (Exception e)
            {

                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConsumidorModel>>> AtualizarConsumidor(EditarConsumidorDto editarConsumidorDto)
        {
            ResponseModel<List<ConsumidorModel>> resposta = new ResponseModel<List<ConsumidorModel>>();
            try
            {
                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == editarConsumidorDto.IdConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                consumidor.Nome = editarConsumidorDto.Nome;
                consumidor.CPF = editarConsumidorDto.CPF;
                consumidor.Email = editarConsumidorDto.Email;
                consumidor.Senha = editarConsumidorDto.Senha;
                consumidor.Sexo = editarConsumidorDto.Sexo;
                consumidor.Estado = editarConsumidorDto.Estado;

                _context.Update(consumidor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consumidores.ToListAsync();
                resposta.Mensagem = "Consumidor atualizado com sucesso!";

                return resposta;
            }
            catch (Exception e)
            {

                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<ConsumidorModel>>> DeletarConsumidor(int idConsumidor)
        {
            ResponseModel<List<ConsumidorModel>> resposta = new ResponseModel<List<ConsumidorModel>>();
            try
            {
                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == idConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                _context.Remove(consumidor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consumidores.ToListAsync();
                resposta.Mensagem = "Consumidor removido com sucesso!";

                return resposta;
            }
            catch (Exception e)
            {

                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
