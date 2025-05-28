using LojaManoel.Models;

namespace LojaManoel.Services
{
    public interface ILojaService
    {
        List<Resultado> Pedidos(Root pedido);

        HistoricoPedidosDb HistoricoPedidos(List<Resultado> resp);
    }
}
