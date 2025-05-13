using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        ProductoNegocio negocio = new ProductoNegocio();

        public Form1()
        {
            InitializeComponent();

            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = negocio.Listar();
        }


        private void Limpiar()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                decimal precio = decimal.Parse(txtPrecio.Text);
                int stock = int.Parse(txtStock.Text);

                negocio.Agregar(nombre, precio, stock);
                CargarProductos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                try
                {
                    int id = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
                    string nombre = txtNombre.Text;
                    decimal precio = decimal.Parse(txtPrecio.Text);
                    int stock = int.Parse(txtStock.Text);

                    negocio.Actualizar(id, nombre, precio, stock);
                    CargarProductos();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int id = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
                negocio.Eliminar(id);
                CargarProductos();
                Limpiar();
            }
        }


        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var fila = dgvProductos.SelectedRows[0];
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
            }
        }
    }
}
