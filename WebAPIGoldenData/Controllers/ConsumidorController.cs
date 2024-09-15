using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGoldenData.Dto.Consumidor;
using WebAPIGoldenData.Models;
using WebAPIGoldenData.Services.Consumidor;

namespace WebAPIGoldenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumidorController : ControllerBase
    {
        private readonly IConsumidorInterface _consumidorInterface;
        public ConsumidorController(IConsumidorInterface consumidorInterface)
        {
            _consumidorInterface = consumidorInterface;
        }

        [HttpGet("ListarConsumidores")]
        public async Task<ActionResult<ResponseModel<List<ConsumidorModel>>>> ListarConsumidores()
        {
            var consumidores = await _consumidorInterface.ListarConsumidores();
            return Ok(consumidores);
        }

        [HttpGet("BuscaConsumidorPorId/{idConsumidor}")]
        public async Task<ActionResult<ResponseModel<ConsumidorModel>>> BuscaConsumidorPorId(int idConsumidor)
        {
            var consumidor = await _consumidorInterface.BuscaConsumidorPorId(idConsumidor);
            return Ok(consumidor);
        }

        [HttpPost("CadastrarConsumidor")]
        public async Task<ActionResult<ResponseModel<List<ConsumidorModel>>>> CadastrarConsumidor(CriarConsumidorDto criarConsumidorDto)
        {
            var consumidor = await _consumidorInterface.CadastrarConsumidor(criarConsumidorDto);
            return Ok(consumidor);
        }

        [HttpPut("AtualizarConsumidor")]
        public async Task<ActionResult<ResponseModel<List<ConsumidorModel>>>> AtualizarConsumidor(EditarConsumidorDto editarConsumidorDto)
        {
            var consumidor = await _consumidorInterface.AtualizarConsumidor(editarConsumidorDto);
            return Ok(consumidor);
        }

        [HttpDelete("DeletarConsumidor")]
        public async Task<ActionResult<ResponseModel<List<ConsumidorModel>>>> DeletarConsumidor(int idConsumidor)
        {
            var consumidor = await _consumidorInterface.DeletarConsumidor(idConsumidor);
            return Ok(consumidor);
        }


    }
}
