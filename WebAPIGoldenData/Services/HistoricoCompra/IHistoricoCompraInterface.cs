using WebAPIGoldenData.Dto.HistoricoCompra;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.HistoricoCompra
{
    public interface IHistoricoCompraInterface
    {
        Task<ResponseModel<List<HistoricoCompraModel>>> ListarHistoricosCompra();
        Task<ResponseModel<HistoricoCompraModel>> BuscarHistoricoCompraPorId(int idHistoricoCompra);
        Task<ResponseModel<List<HistoricoCompraModel>>> BuscarHistoricoCompraPorIdConsumidor(int idConsumidor);
        Task<ResponseModel<List<HistoricoCompraModel>>> InserirHistoricoCompra(CriarHistCompraDto criarHistCompraDto);
        //Task<ResponseModel<List<HistoricoCompraModel>>> AtualizarHistoricoCompra(EditarHistCompraDto editarrHistCompraDto);
        Task<ResponseModel<List<HistoricoCompraModel>>> DeletarHistoricoCompra(int idHistoricoCompra);
    }
}
