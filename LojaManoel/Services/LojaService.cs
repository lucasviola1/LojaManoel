

using LojaManoel.Models;

namespace LojaManoel.Services
{
    public class LojaService : ILojaService
    {
        public LojaService()
        {
        }
        public List<Resultado> Pedidos(Root pedido)
        {

            var resultado = new List<Resultado>();

            var caixasDisponiveis = new List<Caixa>
            {
                new Caixa { caixa_id = "Caixa 1", dimensoes = new Dimensoes {altura = 30, largura = 40, comprimento = 80 }},
                new Caixa { caixa_id = "Caixa 2", dimensoes = new Dimensoes {altura = 80, largura = 50, comprimento = 40 }},
                new Caixa { caixa_id = "Caixa 3", dimensoes = new Dimensoes {altura = 50, largura = 80, comprimento = 60 }}
            };

            var x = pedido.pedidos;

            foreach (var pedidoUni in x)
            {
                var caixasParaPedido = new List<CaixaUsada>();
                foreach (var itemPedido in pedidoUni.produtos)
                {
                    var caixaSelecionada = caixasDisponiveis.FirstOrDefault(c => CabeNaCaixa(itemPedido.dimensoes, c.dimensoes));

                    if (caixaSelecionada != null)
                    {
                        var caixaExistente = caixasParaPedido
                            .FirstOrDefault(c => c.caixaUsada_id == caixaSelecionada.caixa_id);

                        if (caixaExistente == null)
                        {
                            caixaExistente = new CaixaUsada { caixaUsada_id = caixaSelecionada.caixa_id, produtos = new List<string>() };
                            caixasParaPedido.Add(caixaExistente);
                        }

                        caixaExistente.produtos.Add(itemPedido.produto_id);
                    }
                    else
                    {
                        caixasParaPedido.Add(new CaixaUsada { caixaUsada_id = null, produtos = new List<string> { itemPedido.produto_id } , observacao = "Produto não cabe em nenhuma caixa disponível." });
                    }
                }
                resultado.Add(new Resultado {pedidofinal_id = pedidoUni.pedido_id, caixas = caixasParaPedido });
                
            }

            return resultado;
        }

        public HistoricoPedidosDb HistoricoPedidos(List<Resultado> resp)
        {
            HistoricoPedidosDb result = new HistoricoPedidosDb { data = DateTime.Now.ToString(), QtdPedidos = resp.Count };

            return result;
        }

        bool CabeNaCaixa(Dimensoes produto, Dimensoes caixa)
        {
            return produto.altura <= caixa.altura &&
                   produto.largura <= caixa.largura &&
                   produto.comprimento <= caixa.comprimento;
        }

        

    }
}
