using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

namespace WebAPIGoldenData.Controllers
{
    // Classe para dados de treinamento
    public class FeedbackInput
    {
        [LoadColumn(0)]
        public string Comentario { get; set; }

        [LoadColumn(1)]
        public float Avaliacao { get; set; }

        [LoadColumn(2)]
        public string Sentimento { get; set; } 
    }

    // Classe para dados de previsão
    public class FeedbackInputPrediction
    {
        public string Comentario { get; set; }
        public float Avaliacao { get; set; }

        public string Sentimento { get; set; }
    }

    // Classe para previsão de sentimento
    public class SentimentoPrediction
    {
        [ColumnName("PredictedLabel")]
        public string SentimentoPrevisto { get; set; }
    }

    // Classe para resposta da API
    public class SentimentoResponse
    {
        public string Sentimento { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SentimentoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloSentimento.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "feeling-train.csv");
        private readonly MLContext mlContext;

        public SentimentoController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        // Método para treinar o modelo e salvar como arquivo .zip
        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            // Carregar dados de treinamento
            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<FeedbackInput>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            // Definir a pipeline de transformações e treinamento
            var pipeline = mlContext.Transforms.Text.FeaturizeText(
                    outputColumnName: "ComentarioFeaturizado",
                    inputColumnName: nameof(FeedbackInput.Comentario))
                .Append(mlContext.Transforms.Concatenate(
                    "Features",
                    "ComentarioFeaturizado",
                    nameof(FeedbackInput.Avaliacao)))
                .Append(mlContext.Transforms.Conversion.MapValueToKey(
                    outputColumnName: "Label",
                    inputColumnName: nameof(FeedbackInput.Sentimento))) 
                .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(
                    mlContext.BinaryClassification.Trainers.SdcaLogisticRegression()))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue(
                    outputColumnName: "PredictedLabel",
                    inputColumnName: "PredictedLabel"));

            // Treinamento do modelo
            var modelo = pipeline.Fit(dadosTreinamento);

            // Salvar o modelo treinado em um arquivo .zip
            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo treinado e salvo em: {caminhoModelo}");
        }

        // Endpoint para fazer previsões com o modelo treinado
        [HttpPost("prever")]
        public ActionResult<SentimentoResponse> PreverSentimento([FromBody] FeedbackInputPrediction feedback)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            // Carregar o modelo salvo
            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            // Criar o engine de previsão
            var enginePrevisao = mlContext.Model.CreatePredictionEngine<FeedbackInputPrediction, SentimentoPrediction>(modelo);

            // Realizar a previsão
            var previsao = enginePrevisao.Predict(feedback);

            // Verificar se a previsão está nula ou vazia
            if (previsao == null || string.IsNullOrEmpty(previsao.SentimentoPrevisto))
            {
                Console.WriteLine("A previsão do sentimento está vazia ou nula.");
                return StatusCode(500, "Erro ao realizar a previsão de sentimento.");
            }

            // Retornar o resultado com o sentimento previsto como string
            return Ok(new SentimentoResponse { Sentimento = previsao.SentimentoPrevisto });
        }
    }
}
