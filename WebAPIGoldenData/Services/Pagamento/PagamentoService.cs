using Microsoft.EntityFrameworkCore;
using WebAPIGoldenData.Data;
using WebAPIGoldenData.Dto.Pagamento;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.Pagamento
{
    public class PagamentoService : IPagamentoInterface
    {
        private readonly ApplicationDbContext _context;

        public PagamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<PagamentoModel>>> ListarPagamentos()
        {
            ResponseModel<List<PagamentoModel>> resposta = new ResponseModel<List<PagamentoModel>>();
            try
            {
                var pagamentos = await _context.Pagamentos.Include(h => h.HistoricoCompra).ToListAsync();

                resposta.Dados = pagamentos;
                resposta.Mensagem = "Pagamentos listados com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<PagamentoModel>> BuscarPagamentoPorId(int idPagamento)
        {
            ResponseModel<PagamentoModel> resposta = new ResponseModel<PagamentoModel>();
            try
            {
                var pagamento = await _context.Pagamentos.Include(h => h.HistoricoCompra).FirstOrDefaultAsync(pag => pag.IdPagamento == idPagamento);

                if (pagamento == null)
                {
                    resposta.Mensagem = "Pagamento não encontrado!";
                    return resposta;
                }

                resposta.Dados = pagamento;
                resposta.Mensagem = "Pagamento encontrado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }

        }

        public async Task<ResponseModel<List<PagamentoModel>>> BuscarPagamentoPorIdHistoricoCompra(int idHistoricoCompra)
        {
            ResponseModel<List<PagamentoModel>> resposta = new ResponseModel<List<PagamentoModel>>();
            try
            {
                var pagamento = await _context.Pagamentos.Include(h => h.HistoricoCompra).Where(pag => pag.HistoricoCompra.IdHistoricoCompra == idHistoricoCompra).ToListAsync();

                if (pagamento == null)
                {
                    resposta.Mensagem = "Pagamento não encontrado!";
                    return resposta;
                }

                resposta.Dados = pagamento;
                resposta.Mensagem = "Pagamento encontrado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<PagamentoModel>>> InserirPagamento(CriarPagamentoDto criarPagamentoDto)
        {
            ResponseModel<List<PagamentoModel>> resposta = new ResponseModel<List<PagamentoModel>>();
            try
            {
                var historicoCompra = await _context.HistoricoCompras.FirstOrDefaultAsync(cadHist => cadHist.IdHistoricoCompra == criarPagamentoDto.HistoricoCompra.IdHistoricoCompra);

                if (historicoCompra == null)
                {
                    resposta.Mensagem = "Histórico de compra não encontrado!";
                    return resposta;
                }

                PagamentoModel pagamento = new PagamentoModel
                {
                    ValorPagamento = criarPagamentoDto.ValorPagamento,
                    MetodoPagamento = criarPagamentoDto.MetodoPagamento,
                    StatusPagamento = criarPagamentoDto.StatusPagamento,
                    HistoricoCompra = historicoCompra
                };

                _context.Pagamentos.Add(pagamento);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pagamentos.Include(h => h.HistoricoCompra).ToListAsync();
                resposta.Mensagem = "Pagamento inserido com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PagamentoModel>>> DeletarPagamento(int idPagamento)
        {
            ResponseModel<List<PagamentoModel>> resposta = new ResponseModel<List<PagamentoModel>>();
            try
            {
                var pagamento = await _context.Pagamentos.Include(h => h.HistoricoCompra).FirstOrDefaultAsync(cadPag => cadPag.IdPagamento == idPagamento);
                
                if (pagamento == null)
                {
                    resposta.Mensagem = "Pagamento não encontrado!";
                    return resposta;
                }

                _context.Pagamentos.Remove(pagamento);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pagamentos.ToListAsync();
                resposta.Mensagem = "Pagamento deletado com sucesso!";

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
