using WebAPIGoldenData.Dto.InfoConsumidor;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.InfoConsumidor
{
    public interface IInfoConsumidorInterface
    {
        Task<ResponseModel<List<InfoConsumidorModel>>> ListarInfosConsumidor();
        Task<ResponseModel<InfoConsumidorModel>> BuscarInfoConsumidorPorId(int idInfoConsumidor);
        Task<ResponseModel<List<InfoConsumidorModel>>> BuscarInfoConsumidorPorIdConsumidor(int idConsumidor);
        Task<ResponseModel<List<InfoConsumidorModel>>> InserirInfoConsumidor(CriarInfoConsumidorDto criarInfoConsumidorDto);
        Task<ResponseModel<List<InfoConsumidorModel>>> AtualizarInfoConsumidor(EditarInfoConsumidorDto editarInfoConsumidorDto);
        Task<ResponseModel<List<InfoConsumidorModel>>> DeletarInfoConsumidor(int idInfoConsumidor);
    }
}
