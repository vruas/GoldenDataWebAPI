using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGoldenData.Dto.Pagamento;
using WebAPIGoldenData.Models;
using WebAPIGoldenData.Services.Pagamento;

namespace WebAPIGoldenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoInterface _pagamentoInterface;

        public PagamentoController(IPagamentoInterface pagamentoInterface)
        {
            _pagamentoInterface = pagamentoInterface;
        }

        [HttpGet("ListarPagamentos")]
        public async Task<ActionResult<ResponseModel<List<PagamentoModel>>>> ListarPagamentos()
        {
            var pagamentos = await _pagamentoInterface.ListarPagamentos();
            return Ok(pagamentos);
        }

        [HttpGet("BuscarPagamentoPorId/{idPagamento}")]
        public async Task<ActionResult<ResponseModel<PagamentoModel>>> BuscarPagamentoPorId(int idPagamento)
        {
            var pagamento = await _pagamentoInterface.BuscarPagamentoPorId(idPagamento);
            return Ok(pagamento);
        }

        [HttpGet("BuscarPagamentoPorIdHistoricoCompra/{idHistoricoCompra}")]
        public async Task<ActionResult<ResponseModel<List<PagamentoModel>>>> BuscarPagamentoPorIdHistoricoCompra(int idHistoricoCompra)
        {
            var pagamentos = await _pagamentoInterface.BuscarPagamentoPorIdHistoricoCompra(idHistoricoCompra);
            return Ok(pagamentos);
        }

        [HttpPost("InserirPagamento")]
        public async Task<ActionResult<ResponseModel<List<PagamentoModel>>>> InserirPagamento(CriarPagamentoDto criarPagamentoDto)
        {
            var pagamentos = await _pagamentoInterface.InserirPagamento(criarPagamentoDto);
            return Ok(pagamentos);
        }

        [HttpDelete("DeletarPagamento")]
        public async Task<ActionResult<ResponseModel<List<PagamentoModel>>>> DeletarPagamento(int idPagamento)
        {
            var pagamentos = await _pagamentoInterface.DeletarPagamento(idPagamento);
            return Ok(pagamentos);
        }
    }
}
