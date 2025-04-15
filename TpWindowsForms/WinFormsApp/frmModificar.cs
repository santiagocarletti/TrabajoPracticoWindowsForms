using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace WinFormsApp
{
    public partial class frmModificar : Form
    {
        private Articulo articulo = null;

        public frmModificar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            CargarControles();

            CargarDatos(articulo);
        }

        private void CargarDatos(Articulo articulo)
        {
            txtCodigo.Text = articulo.Codigo.ToString();
            txtNombre.Text = articulo.Nombre.ToString();
            txtDescripcion.Text = articulo.Descripcion.ToString();
            cboCategoria.SelectedValue = articulo.IdCategoria;
            cboMarca.SelectedValue = articulo.IdMarca;
            txtPrecio.Text = articulo.Precio.ToString();
            txtImagen.Text = articulo.Imagen;
        }

        private void CargarControles()
        {
            MarcaNegocio mNegocio = new MarcaNegocio();
            CategoriaNegocio cNegocio = new CategoriaNegocio();

            cboMarca.DataSource = mNegocio.listar();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Descripcion";

            cboCategoria.DataSource = cNegocio.listar();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Descripcion";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {

        }
    }
}
