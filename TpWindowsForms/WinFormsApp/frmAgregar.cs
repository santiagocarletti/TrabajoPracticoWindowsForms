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
    public partial class frmAgregar : Form
    {
        private Articulo articulo;
        public frmAgregar()
        {
            InitializeComponent();
            articulo = new Articulo();
            if (articulo.Imagen == null)
            {
                articulo.Imagen = new List<string>();
            }
            CargarControles();
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

        private void CargarListaImagenes()
        {
           
            cboImagenes.Items.Clear();
            cboImagenes.Text = "";

            
            foreach (string imagen in articulo.Imagen)
            {
                cboImagenes.Items.Add(imagen);
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string nuevaImagen = txtImagen.Text.Trim();

            if (string.IsNullOrEmpty(nuevaImagen))
            {
                MessageBox.Show("Por favor, introduce una URL válida.");
                return;
            }

           
            foreach (string imagen in articulo.Imagen)
            {
                if (imagen.Equals(nuevaImagen, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La URL ya está en la lista.");
                    cboImagenes.SelectedItem = nuevaImagen;
                    return;
                }
            }

            articulo.Imagen.Add(nuevaImagen);
            CargarListaImagenes();

            
            cboImagenes.SelectedItem = nuevaImagen;
            txtImagen.Clear();
            CargarImagen(nuevaImagen);
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            
            if (cboImagenes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná una imagen para eliminar.");
                return;
            }

           
            int indice = cboImagenes.SelectedIndex;

            
            cboImagenes.Items.RemoveAt(indice);

           
            if (indice >= 0 && indice < articulo.Imagen.Count)
            {
                articulo.Imagen.RemoveAt(indice);
            }

            
            if (cboImagenes.Items.Count > 0)
            {
                cboImagenes.SelectedIndex = 0;
                CargarImagen(cboImagenes.SelectedItem.ToString());
            }
            else
            {
                
                cboImagenes.Text = "";
                pbxArticulo.Image = null;
            }
        }
        private void txtImagen_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtImagen.Text)) 
            {
                CargarImagen(txtImagen.Text);
            }
        }

        private void cboImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboImagenes.SelectedItem != null) 
            {
                txtImagen.Text = cboImagenes.SelectedItem.ToString(); 
                CargarImagen(cboImagenes.SelectedItem.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            AgregarArticuloBD();
        }

        private void AgregarArticuloBD()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Marca = (Marca)cboMarca.SelectedItem;
            articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
            articulo.Precio = Convert.ToDecimal(txtPrecio.Text);

            articulo.Imagen.Clear();
            foreach (string imagen in cboImagenes.Items)
            {
                articulo.Imagen.Add(imagen);
            }

            try
            {
                negocio.agregar(articulo);
                MessageBox.Show("Artículo agregado exitosamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidarDatos()
        {
            lblCamposObligatorios.Visible = false;
            lblErrorCodigo.Visible = false;
            lblErrorNombre.Visible = false;
            lblErrorPrecio.Visible = false;

            bool validado = true;

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                lblCamposObligatorios.Visible = true;
                lblErrorCodigo.Visible = true;
                validado = false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
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
            return decimal.TryParse(numero, out decimal num);
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {

        }

      
    }
}
