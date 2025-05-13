using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ProductoDatos
    {
        private static List<Producto> productos = new List<Producto>();
        private static int contadorId = 1;

        public List<Producto> ObtenerTodos() => productos.ToList();

        public void Agregar(string nombre, decimal precio, int stock)
        {
            productos.Add(new Producto(contadorId++, nombre, precio, stock));
        }

        public void Eliminar(int id)
        {
            var p = productos.FirstOrDefault(x => x.Id == id);
            if (p != null) productos.Remove(p);
        }

        public void Actualizar(Producto producto)
        {
            var index = productos.FindIndex(p => p.Id == producto.Id);
            if (index != -1) productos[index] = producto;
        }

        public Producto ObtenerPorId(int id) => productos.FirstOrDefault(p => p.Id == id);
    }
}
