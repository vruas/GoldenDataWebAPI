using WebAPIGoldenData.Data;
using WebAPIGoldenData.Models;
using WebAPIGoldenData.Dto.InfoConsumidor;
using Microsoft.EntityFrameworkCore;

namespace WebAPIGoldenData.Services.InfoConsumidor
{
    public class InfoConsumidorService : IInfoConsumidorInterface
    {
        private readonly ApplicationDbContext _context;

        public InfoConsumidorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<InfoConsumidorModel>>> ListarInfosConsumidor()
        {
            ResponseModel<List<InfoConsumidorModel>> resposta = new ResponseModel<List<InfoConsumidorModel>>();
            try
            {
                var infosConsumidor = await _context.InfosConsumidores.Include(c => c.Consumidor).ToListAsync();

                resposta.Dados = infosConsumidor;
                resposta.Mensagem = "Informações do consumidor listadas com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<InfoConsumidorModel>> BuscarInfoConsumidorPorId(int idInfoConsumidor)
        {
            ResponseModel<InfoConsumidorModel> resposta = new ResponseModel<InfoConsumidorModel>();
            try
            {
                var infoConsumidor = await _context.InfosConsumidores.Include(c => c.Consumidor).FirstOrDefaultAsync(cadInfo => cadInfo.IdInfoConsumidor == idInfoConsumidor);

                if (infoConsumidor == null)
                {
                    resposta.Mensagem = "Informações do consumidor não encontradas!";
                    return resposta;
                }

                resposta.Dados = infoConsumidor;
                resposta.Mensagem = "Informações do consumidor encontradas com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<InfoConsumidorModel>>> BuscarInfoConsumidorPorIdConsumidor(int idConsumidor)
        {
            ResponseModel<List<InfoConsumidorModel>> resposta = new ResponseModel<List<InfoConsumidorModel>>();
            try
            {
                var infoConsumidor = await _context.InfosConsumidores
                    .Include(c => c.Consumidor)
                    .Where(cadInfo => cadInfo.Consumidor.IdConsumidor == idConsumidor)
                    .ToListAsync();

                if (infoConsumidor == null)
                {
                    resposta.Mensagem = "Informações do consumidor não encontradas!";

                }

                    resposta.Dados = infoConsumidor;
                resposta.Mensagem = "Informações do consumidor encontradas com sucesso!";
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

        public async Task<ResponseModel<List<InfoConsumidorModel>>> InserirInfoConsumidor(CriarInfoConsumidorDto criarInfoConsumidorDto)
        {
            ResponseModel<List<InfoConsumidorModel>> resposta = new ResponseModel<List<InfoConsumidorModel>>();
            try
            {
                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == criarInfoConsumidorDto.Consumidor.IdConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                var infoConsumidor = new InfoConsumidorModel
                {
                    PreferenciaCompraCliente = criarInfoConsumidorDto.PreferenciaCompraCliente,
                    PreferenciaAnuncio = criarInfoConsumidorDto.PreferenciaAnuncio,
                    MarcasEvitadas = criarInfoConsumidorDto.MarcasEvitadas,
                    Hobbies = criarInfoConsumidorDto.Hobbies,
                    AnunciosEvitados = criarInfoConsumidorDto.AnunciosEvitados,
                    CompraOnline = criarInfoConsumidorDto.CompraOnline,
                    Consumidor = consumidor
                };

                _context.Add(infoConsumidor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.InfosConsumidores.Include(c => c.Consumidor).ToListAsync();
                resposta.Mensagem = "Informações do consumidor inseridas com sucesso!";
                

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<InfoConsumidorModel>>> AtualizarInfoConsumidor(EditarInfoConsumidorDto editarInfoConsumidorDto)
        {
            ResponseModel<List<InfoConsumidorModel>> resposta = new ResponseModel<List<InfoConsumidorModel>>();
            try
            {
                var infoConsumidor = await _context.InfosConsumidores.Include(c => c.Consumidor).FirstOrDefaultAsync(cadInfo => cadInfo.IdInfoConsumidor == editarInfoConsumidorDto.IdInfoConsumidor);

                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == editarInfoConsumidorDto.Consumidor.IdConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                if (infoConsumidor == null)
                {
                    resposta.Mensagem = "Informações do consumidor não encontradas!";
                    return resposta;
                }

                infoConsumidor.PreferenciaCompraCliente = editarInfoConsumidorDto.PreferenciaCompraCliente;
                infoConsumidor.PreferenciaAnuncio = editarInfoConsumidorDto.PreferenciaAnuncio;
                infoConsumidor.MarcasEvitadas = editarInfoConsumidorDto.MarcasEvitadas;
                infoConsumidor.Hobbies = editarInfoConsumidorDto.Hobbies;
                infoConsumidor.AnunciosEvitados = editarInfoConsumidorDto.AnunciosEvitados;
                infoConsumidor.CompraOnline = editarInfoConsumidorDto.CompraOnline;
                infoConsumidor.Consumidor = consumidor;

                _context.Update(infoConsumidor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.InfosConsumidores.ToListAsync();
                resposta.Mensagem = "Informações do consumidor atualizadas com sucesso!";
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

        public async Task<ResponseModel<List<InfoConsumidorModel>>> DeletarInfoConsumidor(int idInfoConsumidor)
        {
            ResponseModel<List<InfoConsumidorModel>> resposta = new ResponseModel<List<InfoConsumidorModel>>();
            try
            {
                var infoConsumidor = await _context.InfosConsumidores.Include(c => c.Consumidor).FirstOrDefaultAsync(cadInfo => cadInfo.IdInfoConsumidor == idInfoConsumidor);

                if (infoConsumidor == null)
                {
                    resposta.Mensagem = "Informações do consumidor não encontradas!";
                    return resposta;
                }

                _context.Remove(infoConsumidor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.InfosConsumidores.ToListAsync();
                resposta.Mensagem = "Informações do consumidor deletadas com sucesso!";
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


    

   



