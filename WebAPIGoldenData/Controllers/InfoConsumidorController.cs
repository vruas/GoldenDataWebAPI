using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGoldenData.Services.InfoConsumidor;
using WebAPIGoldenData.Dto.InfoConsumidor;
using WebAPIGoldenData.Models;


namespace WebAPIGoldenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoConsumidorController : ControllerBase
    {
        private readonly IInfoConsumidorInterface _infoConsumidorInterface;

        public InfoConsumidorController(IInfoConsumidorInterface infoConsumidorInterface)
        {
            _infoConsumidorInterface = infoConsumidorInterface;
        }

        [HttpGet("ListarInfosConsumidor")]
        public async Task<ActionResult<ResponseModel<InfoConsumidorModel>>> ListarInfosConumidor()
        {
            var infosConsumidor = await _infoConsumidorInterface.ListarInfosConsumidor();
            return Ok(infosConsumidor);
        }

        [HttpGet("BuscarInfoConsumidorPorId/{idInfoConsumidor}")]
        public async Task<ActionResult<ResponseModel<InfoConsumidorModel>>> BuscarInfoConsumidorPorId(int idInfoConsumidor)
        {
            var infoConsumidor = await _infoConsumidorInterface.BuscarInfoConsumidorPorId(idInfoConsumidor);
            return Ok(infoConsumidor);
        }

        [HttpGet("BuscarInfoConsumidorPorIdConsumidor/{idConsumidor}")]
        public async Task<ActionResult<ResponseModel<List<InfoConsumidorModel>>>> BuscarInfoConsumidorPorIdConsumidor(int idConsumidor)
        {
            var infoConsumidor = await _infoConsumidorInterface.BuscarInfoConsumidorPorIdConsumidor(idConsumidor);
            return Ok(infoConsumidor);
        }

        [HttpPost("InserirInfoConsumidor")]
        public async Task<ActionResult<ResponseModel<List<InfoConsumidorModel>>>> InseriInfoConsumidor(CriarInfoConsumidorDto criarInfoConsumidorDto)
        {
            var infoConsumidor = await _infoConsumidorInterface.InserirInfoConsumidor(criarInfoConsumidorDto);
            return Ok(infoConsumidor);
        }

        [HttpPut("AtualizarInfoConsumidor")]
        public async Task<ActionResult<ResponseModel<List<InfoConsumidorModel>>>> AtualizarInfoConsumidor(EditarInfoConsumidorDto editarInfoConsumidorDto)
        {
            var infoConsumidor = await _infoConsumidorInterface.AtualizarInfoConsumidor(editarInfoConsumidorDto);
            return Ok(infoConsumidor);
        }

        [HttpDelete("DeletarInfoConsumidor")]
        public async Task<ActionResult<ResponseModel<List<InfoConsumidorModel>>>> DeletarInfoConsumidor(int idInfoConsumidor)
        {
            var infoConsumidor = await _infoConsumidorInterface.DeletarInfoConsumidor(idInfoConsumidor);
            return Ok(infoConsumidor);
        }

    }
}
