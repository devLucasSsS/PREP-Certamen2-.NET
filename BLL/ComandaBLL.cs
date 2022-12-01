using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ComandaBLL
    {
        RestaurantEntities bd = new RestaurantEntities();
        public void AddComanda(int mesa, int cant)
        {
            if (Get(mesa) == null)
            {
                Comanda nueva = new Comanda();
                nueva.Mesa = mesa;
                nueva.Comensales = cant;
                bd.Comanda.Add(nueva);
                bd.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Mesa Ocupada");
            }

        }
        public void AddPedido(int mesa,int plato,int cant)
        {
            Pedido nueva = new Pedido();
            nueva.IdComanda = mesa;
            nueva.IdPlato = plato;
            nueva.Cantidad = cant;
            bd.Pedido.Add(nueva);
            bd.SaveChanges();
        }

        public List<Comanda> getMesas()
        {
            return bd.Comanda.ToList();
        }

        public List<Plato> getPlatos()
        {
            return bd.Plato.ToList();
        }

        public Comanda Get(int mesa)
        {
            Comanda comanda = bd.Comanda.Where(c => c.Mesa == mesa).FirstOrDefault();
            return comanda;
        }
        public Plato GetIdPlato(string nombre)
        {
            Plato plato = bd.Plato.Where(c => c.Nombre == nombre).FirstOrDefault();
            return plato;
        }
    }
}
