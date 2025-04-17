using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace WinFormsApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                dgvArticulos.DataSource = negocio.listar(); 
                ocultarColumnas(); 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los artículos: " + ex.Message);
            }
        }


        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = true; 
             
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listar();

            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Precio");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar alta = new frmAgregar();
            alta.ShowDialog();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado;
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmModificar modificar = new frmModificar(seleccionado);
                modificar.ShowDialog();
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = cboCampo.SelectedItem.ToString();
            string criterio = cboCriterio.SelectedItem.ToString();
            string filtro = txtFiltroAvanzado.Text.ToString();
            string consulta;

            if (campo == "Precio")
            {
                decimal valorFiltro = decimal.Parse(txtFiltroAvanzado.Text);
                if (criterio == "Mayor a")
                {
                    consulta = "SELECT * FROM ARTICULOS WHERE Precio > " + valorFiltro;
                }
                else if (criterio == "Menor a")
                {
                    consulta = "SELECT * FROM ARTICULOS WHERE Precio < " + valorFiltro;
                }
                else
                {
                    consulta = "SELECT * FROM ARTICULOS WHERE Precio = " + valorFiltro;
                }
            }
            else if (campo == "Marca")
            {
                if (criterio == "Comienza con")
                {
                    consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion AS Marca FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id WHERE M.Descripcion LIKE '" + criterio + "%'";
                }
                else if (criterio == "Termina con")
                {
                    consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion AS Marca FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id WHERE M.Descripcion LIKE '%" + criterio + "'";
                }
                else
                {
                    consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion AS Marca FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id WHERE M.Descripcion LIKE '%" + criterio + "%'";
                }
            }
            else
            {
                //El criterio es Nombre
                if (criterio == "Comienza con")
                {
                    consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion AS Marca FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id WHERE A.Nombre LIKE '" + criterio + "%'";
                }
                else if (criterio == "Termina con")
                {
                    consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion AS Marca FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id WHERE A.Nombre LIKE '%" + criterio + "'";
                }
                else
                {
                    consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion AS Marca FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id WHERE A.Nombre LIKE '%" + criterio + "%'";
                }
            }
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            frmGestionar frmgestionar = new frmGestionar();
            frmgestionar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
            
            
                DialogResult respuesta = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este artículo?",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta == DialogResult.No)
                {
                    return; 
                }

                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                negocio.eliminar(seleccionado.Id);

                cargar(); 
                MessageBox.Show("Artículo eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar el articulo: " + ex.ToString());
            }
        }
        }
    }

