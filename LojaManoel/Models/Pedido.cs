using System.Text.Json.Nodes;

namespace LojaManoel.Models
{
    public class Dimensoes
    {
        public int id { get; set; }
        public int altura { get; set; }
        public int largura { get; set; }
        public int comprimento { get; set; }
    }

    public class Pedido
    {
        public int pedido_id { get; set; }
        public List<Produto> produtos { get; set; }
    }

    public class Produto
    {
        public string produto_id { get; set; }
        public Dimensoes dimensoes { get; set; }
    }

    public class Root
    {
        public List<Pedido> pedidos { get; set; }
    }
}
