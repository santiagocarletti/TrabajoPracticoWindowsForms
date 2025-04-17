namespace WinFormsApp
{
    partial class frmGestionar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lboxCategorias = new System.Windows.Forms.ListBox();
            this.lboxMarcas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.btnEliminarMarca = new System.Windows.Forms.Button();
            this.btnAgregarMarca = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErrorCategoria = new System.Windows.Forms.Label();
            this.lblErrorMarca = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lboxCategorias
            // 
            this.lboxCategorias.FormattingEnabled = true;
            this.lboxCategorias.Location = new System.Drawing.Point(12, 43);
            this.lboxCategorias.Name = "lboxCategorias";
            this.lboxCategorias.Size = new System.Drawing.Size(155, 147);
            this.lboxCategorias.TabIndex = 0;
            // 
            // lboxMarcas
            // 
            this.lboxMarcas.FormattingEnabled = true;
            this.lboxMarcas.Location = new System.Drawing.Point(12, 243);
            this.lboxMarcas.Name = "lboxMarcas";
            this.lboxMarcas.Size = new System.Drawing.Size(155, 147);
            this.lboxMarcas.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Categorias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Marcas";
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(173, 167);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(127, 23);
            this.btnAgregarCategoria.TabIndex = 3;
            this.btnAgregarCategoria.Text = "<   Agregar Categoria";
            this.btnAgregarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.Location = new System.Drawing.Point(173, 43);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(127, 23);
            this.btnEliminarCategoria.TabIndex = 1;
            this.btnEliminarCategoria.Text = "Eliminar seleccionada";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Location = new System.Drawing.Point(173, 141);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(127, 20);
            this.txtNombreCategoria.TabIndex = 2;
            this.txtNombreCategoria.Enter += new System.EventHandler(this.txtNombreCategoria_Enter);
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Location = new System.Drawing.Point(173, 341);
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(127, 20);
            this.txtNombreMarca.TabIndex = 6;
            this.txtNombreMarca.Enter += new System.EventHandler(this.txtNombreMarca_Enter);
            // 
            // btnEliminarMarca
            // 
            this.btnEliminarMarca.Location = new System.Drawing.Point(173, 243);
            this.btnEliminarMarca.Name = "btnEliminarMarca";
            this.btnEliminarMarca.Size = new System.Drawing.Size(127, 23);
            this.btnEliminarMarca.TabIndex = 5;
            this.btnEliminarMarca.Text = "Eliminar seleccionada";
            this.btnEliminarMarca.UseVisualStyleBackColor = true;
            this.btnEliminarMarca.Click += new System.EventHandler(this.btnEliminarMarca_Click);
            // 
            // btnAgregarMarca
            // 
            this.btnAgregarMarca.Location = new System.Drawing.Point(173, 367);
            this.btnAgregarMarca.Name = "btnAgregarMarca";
            this.btnAgregarMarca.Size = new System.Drawing.Size(127, 23);
            this.btnAgregarMarca.TabIndex = 7;
            this.btnAgregarMarca.Text = "<     Agregar Marca";
            this.btnAgregarMarca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarMarca.UseVisualStyleBackColor = true;
            this.btnAgregarMarca.Click += new System.EventHandler(this.btnAgregarMarca_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(170, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nombre:";
            // 
            // lblErrorCategoria
            // 
            this.lblErrorCategoria.AutoSize = true;
            this.lblErrorCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCategoria.ForeColor = System.Drawing.Color.IndianRed;
            this.lblErrorCategoria.Location = new System.Drawing.Point(231, 125);
            this.lblErrorCategoria.Name = "lblErrorCategoria";
            this.lblErrorCategoria.Size = new System.Drawing.Size(69, 13);
            this.lblErrorCategoria.TabIndex = 14;
            this.lblErrorCategoria.Text = "Campo vacio";
            // 
            // lblErrorMarca
            // 
            this.lblErrorMarca.AutoSize = true;
            this.lblErrorMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMarca.ForeColor = System.Drawing.Color.IndianRed;
            this.lblErrorMarca.Location = new System.Drawing.Point(231, 325);
            this.lblErrorMarca.Name = "lblErrorMarca";
            this.lblErrorMarca.Size = new System.Drawing.Size(69, 13);
            this.lblErrorMarca.TabIndex = 15;
            this.lblErrorMarca.Text = "Campo vacio";
            // 
            // frmGestionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 411);
            this.Controls.Add(this.lblErrorMarca);
            this.Controls.Add(this.lblErrorCategoria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreMarca);
            this.Controls.Add(this.btnEliminarMarca);
            this.Controls.Add(this.btnAgregarMarca);
            this.Controls.Add(this.txtNombreCategoria);
            this.Controls.Add(this.btnEliminarCategoria);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lboxMarcas);
            this.Controls.Add(this.lboxCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGestionar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionar Marcas y Categorias";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmGestionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxCategorias;
        private System.Windows.Forms.ListBox lboxMarcas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.TextBox txtNombreMarca;
        private System.Windows.Forms.Button btnEliminarMarca;
        private System.Windows.Forms.Button btnAgregarMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblErrorCategoria;
        private System.Windows.Forms.Label lblErrorMarca;
    }
}