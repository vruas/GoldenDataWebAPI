using WebAPIGoldenData.Dto.Pagamento;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.Pagamento
{
    public interface IPagamentoInterface
    {
        Task<ResponseModel<List<PagamentoModel>>> ListarPagamentos();
        Task<ResponseModel<PagamentoModel>> BuscarPagamentoPorId(int idPagamento);
        Task<ResponseModel<List<PagamentoModel>>> BuscarPagamentoPorIdHistoricoCompra(int idHistoricoCompra);
        Task<ResponseModel<List<PagamentoModel>>> InserirPagamento(CriarPagamentoDto criarPagamentoDto);
        Task<ResponseModel<List<PagamentoModel>>> DeletarPagamento(int idPagamento);
    }
}
