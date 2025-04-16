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

        private void CargarDatos(Articulo articulo)
        {
            txtCodigo.Text = articulo.Codigo.ToString();
            txtNombre.Text = articulo.Nombre.ToString();
            txtDescripcion.Text = articulo.Descripcion.ToString();
            cboCategoria.SelectedValue = articulo.Categoria;
            cboMarca.SelectedValue = articulo.Marca;
            txtPrecio.Text = articulo.Precio.ToString();
            txtImagen.Text = articulo.Imagen;
            CargarImagen(articulo.Imagen);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!(ChequearCambios(articulo)))
            {
                Close();
                return;
            }

            if (!ValidarDatos())
            {
                return;
            }

            MessageBox.Show("sin problemas");
        }

        private void ModificarArticuloBD(Articulo articulo)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();

            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Imagen = txtImagen.Text;
          //  articulo.IdCategoria = cboCategoria.SelectedIndex;
          //  articulo.IdMarca = cboMarca.SelectedIndex;

            negocio.modificar(articulo);


        }

        private bool ChequearCambios(Articulo articulo)
        {
            if (txtCodigo.Text == articulo.Codigo &&
                txtNombre.Text == articulo.Nombre &&
                txtDescripcion.Text == articulo.Descripcion &&
                (int)cboCategoria.SelectedValue == articulo.Categoria.Id &&
                (int)cboMarca.SelectedValue == articulo.Marca.Id &&
                txtPrecio.Text == articulo.Precio.ToString() &&
                txtImagen.Text == articulo.Imagen)
            {
                return false;
            }

            return true;
        }

        private bool ValidarDatos()
        {
            lblCamposObligatorios.Visible = false;
            lblErrorCodigo.Visible = false;
            lblErrorNombre.Visible = false;
            lblErrorPrecio.Visible = false;

            bool validado = true;

            if (txtCodigo.Text == "")
            {
                lblCamposObligatorios.Visible = true;
                lblErrorCodigo.Visible = true;
                validado = false;
            }

            if (txtNombre.Text == "")
            {
                lblCamposObligatorios.Visible = true;
                lblErrorNombre.Visible = true;
                validado = false;
            }

            if (!ValidarDecimal(txtPrecio.Text))
            {
                lblErrorPrecio.Visible = true;
                validado = false;
            }

            return validado;
        }

        private bool ValidarDecimal(string numero)
        {
            if (decimal.TryParse(numero, out decimal num))
                return true;
            else
                return false;
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtImagen.Text);
        }

    }
}
