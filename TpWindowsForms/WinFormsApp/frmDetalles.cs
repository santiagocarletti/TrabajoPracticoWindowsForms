using dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmDetalles : Form
    {
        private Articulo articulo = null;

        public frmDetalles(Articulo articulo)
        {
            InitializeComponent();

            if (articulo == null)
            {
               
                Close();
                return;
            }

            this.articulo = articulo;
            MostrarDetalles();
        }

        
        private void MostrarDetalles()
        {
           
            txtCodigo.Text = articulo.Codigo.ToString();
            txtCodigo.ReadOnly = true;

            txtNombre.Text = articulo.Nombre.ToString();
            txtNombre.ReadOnly = true;

            txtDescripcion.Text = articulo.Descripcion.ToString();
            txtDescripcion.ReadOnly = true;

            txtPrecio.Text = articulo.Precio.ToString("C");
            txtPrecio.ReadOnly = true;

            txtCategoria.Text = articulo.Categoria != null ? articulo.Categoria.Descripcion : "Sin Categoría";
            txtCategoria.ReadOnly = true;

            txtMarca.Text = articulo.Marca != null ? articulo.Marca.Descripcion : "Sin Marca";
            txtMarca.ReadOnly = true;

            
            CargarListaImagenes();

            
            if (articulo.Imagen != null && articulo.Imagen.Count > 0)
            {
                cboImagenes.SelectedIndex = 0;
                CargarImagen(articulo.Imagen[0]);
            }
            else
            {
                CargarImagen("https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg");
            }
        }

     
        private void CargarListaImagenes()
        {
            cboImagenes.Items.Clear(); 

            if (articulo.Imagen != null && articulo.Imagen.Count > 0)
            {
                foreach (string url in articulo.Imagen)
                {
                    cboImagenes.Items.Add(url);
                }

                cboImagenes.SelectedIndex = 0; 
            }
            else
            {
                cboImagenes.Text = "Sin imágenes disponibles"; 
            }
        }

        
        private void CargarImagen(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    pbxArticulo.Load(url); 
                }
                else
                {
                    throw new Exception("URL vacía");
                }
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg"); 
            }
        }

        
        private void cboImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboImagenes.SelectedItem != null)
            {
                try
                {
                    pbxArticulo.Load(cboImagenes.SelectedItem.ToString()); 
                }
                catch
                {
                    pbxArticulo.Image = null; 
                }
            }
        }

       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
