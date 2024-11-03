using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebAPIGoldenData.Data;
using WebAPIGoldenData.Dto.HistoricoCompra;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.HistoricoCompra
{
    public class HistoricoCompraService : IHistoricoCompraInterface
    {
        private readonly ApplicationDbContext _context;

        public HistoricoCompraService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<HistoricoCompraModel>>> ListarHistoricosCompra()
        {
            ResponseModel<List<HistoricoCompraModel>> resposta = new ResponseModel<List<HistoricoCompraModel>>();
            try
            {
                var historicoCompras = await _context.HistoricoCompras.Include(c => c.Consumidor).ToListAsync();

                resposta.Dados = historicoCompras;
                resposta.Mensagem = "Historico de compras listados com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }

        }

        public async Task<ResponseModel<HistoricoCompraModel>> BuscarHistoricoCompraPorId(int idHistoricoCompra)
        {
            ResponseModel<HistoricoCompraModel> resposta = new ResponseModel<HistoricoCompraModel>();
            try
            {
                var historicoCompra = await _context.HistoricoCompras.Include(c => c.Consumidor).FirstOrDefaultAsync(cadHist => cadHist.IdHistoricoCompra == idHistoricoCompra);

                if (historicoCompra == null)
                {
                    resposta.Mensagem = "Historico de compra não encontrado!";
                    return resposta;
                }

                resposta.Dados = historicoCompra;
                resposta.Mensagem = "Historico de compra encontrado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<HistoricoCompraModel>>> BuscarHistoricoCompraPorIdConsumidor(int idConsumidor)
        {
            ResponseModel<List<HistoricoCompraModel>> resposta = new ResponseModel<List<HistoricoCompraModel>>();
            try
            {
                var historicoCompra = await _context.HistoricoCompras.Include(c => c.Consumidor).Where(cadHist => cadHist.Consumidor.IdConsumidor == idConsumidor).ToListAsync();

                if (historicoCompra == null)
                {
                    resposta.Mensagem = "Historico de compra não encontrado!";
                    return resposta;
                }

                resposta.Dados = historicoCompra;
                resposta.Mensagem = "Historico de compra encontrado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }



        public async Task<ResponseModel<List<HistoricoCompraModel>>> InserirHistoricoCompra(CriarHistCompraDto criarHistCompraDto)
        {
            ResponseModel<List<HistoricoCompraModel>> resposta = new ResponseModel<List<HistoricoCompraModel>>();
            try
            {
                var consumidor = await _context.Consumidores.FirstOrDefaultAsync(cadConsumidor => cadConsumidor.IdConsumidor == criarHistCompraDto.Consumidor.IdConsumidor);

                if (consumidor == null)
                {
                    resposta.Mensagem = "Consumidor não encontrado!";
                    return resposta;
                }

                HistoricoCompraModel historicoCompra = new HistoricoCompraModel
                {
                    DataCompra = criarHistCompraDto.DataCompra,
                    ValorCompra = criarHistCompraDto.ValorCompra,
                    Consumidor = consumidor
                };

                _context.HistoricoCompras.Add(historicoCompra);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.HistoricoCompras.Include(c => c.Consumidor).ToListAsync();
                resposta.Mensagem = "Historico de compra inserido com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<HistoricoCompraModel>>> DeletarHistoricoCompra(int idHistoricoCompra)
        {
            ResponseModel<List<HistoricoCompraModel>> resposta = new ResponseModel<List<HistoricoCompraModel>>();
            try
            {
                var historicoCompra = await _context.HistoricoCompras.Include(c => c.Consumidor).FirstOrDefaultAsync(cadHist => cadHist.IdHistoricoCompra == idHistoricoCompra);

                if (historicoCompra == null)
                {
                    resposta.Mensagem = "Historico de compra não encontrado!";
                    return resposta;
                }

                _context.HistoricoCompras.Remove(historicoCompra);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.HistoricoCompras.ToListAsync();
                resposta.Mensagem = "Historico de compra deletado com sucesso!";

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
