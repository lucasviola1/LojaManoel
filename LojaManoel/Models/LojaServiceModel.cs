using System.Text.Json.Serialization;

namespace LojaManoel.Models
{
    public class Resultado
    {
        public int pedidofinal_id { get; set; }
        public List<CaixaUsada> caixas { get; set; }
    }

    public class Caixa
    {
        public int id { get; set; }
        public string caixa_id { get; set; }
        public Dimensoes dimensoes { get; set; }
    }

    public class CaixaUsada
    {
        public string caixaUsada_id { get; set; }
        public List<string> produtos { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string observacao { get; set; }
    }
}
