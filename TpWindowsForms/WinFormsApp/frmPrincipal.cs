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
using System.Security.Policy;

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
            dgvArticulos.Columns["Id"].Visible = false;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listar();

            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Precio");

            ocultarColumnas();
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
            cargar();
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
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text.ToString();

                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            string consulta;

        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            cargar();
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

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            frmGestionar frmgestionar = new frmGestionar();
            frmgestionar.ShowDialog();
        }


        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            CargarListaImagenes();

            if (cboImagenes.Items.Count > 0)
            {
                cboImagenes.SelectedIndex = 0;
                CargarImagen((string)cboImagenes.Items[0]);
            }

        }

        private void CargarListaImagenes()
        {



            if (dgvArticulos.CurrentRow == null)
            { return; }

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            cboImagenes.Items.Clear();

            foreach (string Image in seleccionado.Imagen)
            {
                cboImagenes.Items.Add(Image);
            }
        }

        private void CargarImagen(string url)
        {
            try
            {
                pbxArticulo.Load(url);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg?20200913095930");
            }
        }

        private void cboImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarImagen((string)cboImagenes.SelectedItem);
        }


        //si se borra una marca o una cat, la datagrid tira error de nulo en los datos
        //esto es p q no salte el error ese td el tiempo
        private void dgvArticulos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                DataGridViewRow filaSeleccionada = dgvArticulos.CurrentRow;
                int idArticulo = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articuloSeleccionado = negocio.obtenerPorId(idArticulo);

                if (articuloSeleccionado != null)
                {
                    frmDetalles detalles = new frmDetalles(articuloSeleccionado);
                    detalles.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontró el artículo seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artículo de la lista.");
            }
        }
    }
}