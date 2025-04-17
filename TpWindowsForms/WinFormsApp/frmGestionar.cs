using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmGestionar : Form
    {
        public frmGestionar()
        {
            InitializeComponent();
            CargarMarcas();
            CargarCategorias();
            lblErrorCategoria.Visible = false;
            lblErrorMarca.Visible = false;
        }

        private void CargarMarcas()
        {
            MarcaNegocio mNegocio = new MarcaNegocio();
            lboxMarcas.DataSource = mNegocio.listar();
            lboxMarcas.ValueMember = "Id";
            lboxMarcas.DisplayMember = "Descripcion";
        }

        private void CargarCategorias()
        {
            CategoriaNegocio cNegocio = new CategoriaNegocio();
            lboxCategorias.DataSource = cNegocio.listar();
            lboxCategorias.ValueMember = "Id";
            lboxCategorias.DisplayMember = "Descripcion";
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (lboxCategorias.SelectedItem == null)
            { return; }

            DialogResult result = MessageBox.Show("¿Estás seguro que desea eliminar la Categoria " + lboxCategorias.SelectedItem.ToString() + "?",
                                                    "Confirmar",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                Categoria categoria = (Categoria)lboxCategorias.SelectedItem;
                negocio.Eliminar(categoria.Id);
                CargarCategorias();
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                lblErrorCategoria.Visible = true; 
                return; 
            }

            CategoriaNegocio negocio = new CategoriaNegocio();
            negocio.Agregar(txtNombreCategoria.Text);
            CargarCategorias();
        }



        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMarca.Text))
            {
                lblErrorMarca.Visible = true;
                return; 
            }

            MarcaNegocio negocio = new MarcaNegocio();
            negocio.Agregar(txtNombreMarca.Text);
            CargarMarcas();
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (lboxMarcas.SelectedItem == null)
            { return; }

            DialogResult result = MessageBox.Show( "¿Estás seguro que desea eliminar la Marca " + lboxMarcas.SelectedItem.ToString() + "?",
                                                    "Confirmar",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MarcaNegocio negocio = new MarcaNegocio();
                Marca marca = (Marca)lboxMarcas.SelectedItem;
                negocio.Eliminar(marca.Id);
                CargarMarcas();
            }
        }

        private void txtNombreCategoria_Enter(object sender, EventArgs e)
        {
            lblErrorCategoria.Visible = false; 
        }

        private void txtNombreMarca_Enter(object sender, EventArgs e)
        {
            lblErrorMarca.Visible = false;
        }

        private void frmGestionar_Load(object sender, EventArgs e)
        {

        }
    }
}
