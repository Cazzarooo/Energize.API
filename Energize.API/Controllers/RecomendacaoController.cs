using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Energize.API.Controllers
{
    public class DadosRecomendacao
    {
        [LoadColumn(0)] public string Nome { get; set; }
        [LoadColumn(1)] public string EnergiaRenovavel { get; set; }
        [LoadColumn(2)] public float AvaliacaoEnergiaRenovavel { get; set; }
    }
    public class RecomendacaoEnergiaRenovavel
    {
        [ColumnName("Score")]
        public float PontuacaoRecomendacao { get; set; }

        [ColumnName("EnergiaRenovavel")]
        public string EnergiaRenovavel { get; set; } = string.Empty;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RecomendacaoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloRecomendacao.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "EnergiaRenovavel.csv");
        private readonly MLContext mlContext;

        public RecomendacaoController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        [HttpGet("recomendar/{nome}/{energiaRenovavel}")]
        public IActionResult Recomendar(string nome, string energiaRenovavel)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            var engineRecomendacao = mlContext.Model.CreatePredictionEngine<DadosRecomendacao, RecomendacaoEnergiaRenovavel>(modelo);

            var recomendacao = engineRecomendacao.Predict(new DadosRecomendacao
            {
                Nome = nome,
                EnergiaRenovavel = energiaRenovavel
            });

            return Ok(new
            {
                score = recomendacao.PontuacaoRecomendacao,
                energiaRenovavel = recomendacao.EnergiaRenovavel,
                recomendacao = GetStatusRecomendacao(recomendacao.PontuacaoRecomendacao)
            });
        }
        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosRecomendacao>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(DadosRecomendacao.AvaliacaoEnergiaRenovavel))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "NomeCodificado", inputColumnName: nameof(DadosRecomendacao.Nome)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "EnergiaRenovavelCodificado", inputColumnName: nameof(DadosRecomendacao.EnergiaRenovavel)))
                .Append(mlContext.Transforms.Concatenate("Features", "NomeCodificado", "EnergiaRenovavelCodificado"))
                .Append(mlContext.Regression.Trainers.FastTree());

            var modelo = pipeline.Fit(dadosTreinamento);

            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo treinado e salvo em: {caminhoModelo}");
        }

        private string GetStatusRecomendacao(float pontuacao)
        {
            switch (Math.Round(pontuacao, 1))
            {
                case >= 4:
                    return "Altamente Recomendado";
                case >= 3:
                    return "Recomendado";
                default:
                    return "Não Recomendado";
            }
        }
    }
}
