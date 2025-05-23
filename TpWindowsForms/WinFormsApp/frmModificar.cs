﻿using System;
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
            //por si es null con ternario le pongo 0
            cboCategoria.SelectedValue = articulo.Categoria != null ? articulo.Categoria.Id : 0;
            cboMarca.SelectedValue = articulo.Marca != null ? articulo.Marca.Id : 0;
            txtPrecio.Text = articulo.Precio.ToString();

            CargarListaImagenes();

            if (cboImagenes.Items.Count > 0)
            { 
                cboImagenes.SelectedIndex = 0;
                CargarImagen(articulo.Imagen[0]);
            }         
        }

        private void CargarListaImagenes()
        {
            cboImagenes.Items.Clear();
            cboImagenes.Text = "";

            foreach (string Image in articulo.Imagen)
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






        private void txtImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(cboImagenes.Text);
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if (cboImagenes.Items.Count == 0)
            {
                return;
            }
            
            int indice = cboImagenes.SelectedIndex;
            cboImagenes.Items.RemoveAt(indice);

            if (cboImagenes.Items.Count > 0)
            {
                cboImagenes.SelectedIndex = 0;
            }

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (txtImagen.Text == "")
            { return; }

            foreach (string image in articulo.Imagen)
            {
                if (image == txtImagen.Text)
                {
                    cboImagenes.SelectedItem = txtImagen.Text;
                    return;
                }
            }

            cboImagenes.Items.Add(txtImagen.Text);
            cboImagenes.SelectedItem = txtImagen.Text;
            txtImagen.Clear();
            CargarImagen(cboImagenes.SelectedItem.ToString());


            //articulo.Imagen.Add(txtImagen.Text);
            //CargarListaImagenes();


        }

        private void cboImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarImagen(cboImagenes.SelectedItem.ToString());
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!(ChequearCambios(articulo)))
            {
                Close();
                MessageBox.Show("No hubo cambios");
                return;
            }

            if (!ValidarDatos())
            {
                return;
            }

            ModificarArticuloBD();
        }

        private void ModificarArticuloBD()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Marca = (Marca)cboMarca.SelectedItem;
            articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
            articulo.Precio = (Convert.ToDecimal(txtPrecio.Text));
            articulo.Imagen.Clear();

            foreach (string imagen in cboImagenes.Items)
            {
                articulo.Imagen.Add(imagen);
            }

            try
            {
                negocio.modificar(articulo);
                MessageBox.Show("Articulo Modificado Exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }






        //VALIDACIONES:
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

        private bool ChequearCambios(Articulo articulo)
        {
            if (txtCodigo.Text == articulo.Codigo &&
                txtNombre.Text == articulo.Nombre &&
                txtDescripcion.Text == articulo.Descripcion &&
                txtPrecio.Text == articulo.Precio.ToString())
            {

                if (cboCategoria.SelectedValue != null && 
                    (int)cboCategoria.SelectedValue != articulo.Categoria.Id)
                {
                    return true;
                }

                if (cboMarca.SelectedValue != null &&
                    (int)cboMarca.SelectedValue != articulo.Marca.Id)
                {
                    return true;
                }
  
                if (articulo.Imagen.Count != cboImagenes.Items.Count)
                { return true; }

                int contador = 0;

                foreach (var imagen in cboImagenes.Items)
                {
                    if (imagen.ToString() != articulo.Imagen[contador])
                    { return true; }
                    contador++;
                }

                return false;
            }
            return true;
        }

        private void frmModificar_Load(object sender, EventArgs e)
        {

        }
    }
}
