using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class ProductoNegocio
    {
        private ProductoDatos datos = new ProductoDatos();

        public List<Producto> Listar() => datos.ObtenerTodos();

        public void Agregar(string nombre, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("Nombre inválido");
            if (precio < 0) throw new Exception("Precio inválido");
            if (stock < 0) throw new Exception("Stock inválido");

            datos.Agregar(nombre, precio, stock);
        }

        public void Eliminar(int id) => datos.Eliminar(id);

        public void Actualizar(int id, string nombre, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("Nombre inválido");
            if (precio < 0) throw new Exception("Precio inválido");
            if (stock < 0) throw new Exception("Stock inválido");

            datos.Actualizar(new Producto(id, nombre, precio, stock));
        }

        public Producto Obtener(int id) => datos.ObtenerPorId(id);
    }
}
