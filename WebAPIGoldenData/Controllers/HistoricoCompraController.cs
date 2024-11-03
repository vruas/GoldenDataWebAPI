using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGoldenData.Dto.HistoricoCompra;
using WebAPIGoldenData.Models;
using WebAPIGoldenData.Services.HistoricoCompra;

namespace WebAPIGoldenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoricoCompraController : ControllerBase
    {
        private readonly IHistoricoCompraInterface _historicoCompraInterface;

        public HistoricoCompraController(IHistoricoCompraInterface historicoCompraInterface)
        {
            _historicoCompraInterface = historicoCompraInterface;
        }

        [HttpGet("ListarHistoricosCompra")]
        public async Task<ActionResult<ResponseModel<List<HistoricoCompraModel>>>> ListarHistoricosCompra()
        {
            var historicoCompras = await _historicoCompraInterface.ListarHistoricosCompra();
            return Ok(historicoCompras);
        }

        [HttpGet("BuscarHistoricoCompraPorId/{idHistoricoCompra}")]
        public async Task<ActionResult<ResponseModel<HistoricoCompraModel>>> BuscarHistoricoCompraPorId(int idHistoricoCompra)
        {
            var historicoCompra = await _historicoCompraInterface.BuscarHistoricoCompraPorId(idHistoricoCompra);
            return Ok(historicoCompra);
        }

        [HttpGet("BuscarHistoricoCompraPorIdConsumidor/{idConsumidor}")]
        public async Task<ActionResult<ResponseModel<List<HistoricoCompraModel>>>> BuscarHistoricoCompraPorIdConsumidor(int idConsumidor)
        {
            var historicoCompras = await _historicoCompraInterface.BuscarHistoricoCompraPorIdConsumidor(idConsumidor);
            return Ok(historicoCompras);
        }

        [HttpPost("InserirHistoricoCompra")]
        public async Task<ActionResult<ResponseModel<List<HistoricoCompraModel>>>> InserirHistoricoCompra(CriarHistCompraDto criarHistCompraDto)
        {
            var historicoCompras = await _historicoCompraInterface.InserirHistoricoCompra(criarHistCompraDto);
            return Ok(historicoCompras);
        }

        [HttpDelete("DeletarHistoricoCompra")]
        public async Task<ActionResult<ResponseModel<List<HistoricoCompraModel>>>> DeletarHistoricoCompra(int idHistoricoCompra)
        {
            var historicoCompras = await _historicoCompraInterface.DeletarHistoricoCompra(idHistoricoCompra);
            return Ok(historicoCompras);
        }
    }
}
