using WebAPIGoldenData.Dto.Consumidor;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Services.Consumidor
{
    public interface IConsumidorInterface
    {
        Task<ResponseModel<List<ConsumidorModel>>> ListarConsumidores();
        Task<ResponseModel<ConsumidorModel>> BuscaConsumidorPorId(int idConsumidor);
        Task<ResponseModel<List<ConsumidorModel>>> CadastrarConsumidor(CriarConsumidorDto criarConsumidorDto);
        Task<ResponseModel<List<ConsumidorModel>>> AtualizarConsumidor(EditarConsumidorDto editarConsumidorDto);
        Task<ResponseModel<List<ConsumidorModel>>> DeletarConsumidor(int idConsumidor);

    }
}
