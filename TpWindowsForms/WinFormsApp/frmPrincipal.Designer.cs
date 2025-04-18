namespace WinFormsApp
{
    partial class frmPrincipal
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.lblFiltroAvanzado = new System.Windows.Forms.Label();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnOpciones = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.cboImagenes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(388, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "GESTION DE ARTICULOS";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnAgregar.Location = new System.Drawing.Point(17, 370);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 45);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "AGREGAR ";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnEliminar.Location = new System.Drawing.Point(268, 370);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 45);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDetalle.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnDetalle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnDetalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnDetalle.Location = new System.Drawing.Point(577, 370);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(100, 45);
            this.btnDetalle.TabIndex = 9;
            this.btnDetalle.Text = "DETALLE";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnBuscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnBuscar.Location = new System.Drawing.Point(589, 76);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 36);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnModificar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnModificar.Location = new System.Drawing.Point(140, 370);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 45);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "MODIFICAR ";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.AllowUserToResizeRows = false;
            this.dgvArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(17, 118);
            this.dgvArticulos.MinimumSize = new System.Drawing.Size(660, 238);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowHeadersWidth = 51;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(660, 238);
            this.dgvArticulos.TabIndex = 4;
            this.dgvArticulos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvArticulos_DataError);
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // lblFiltroAvanzado
            // 
            this.lblFiltroAvanzado.AutoSize = true;
            this.lblFiltroAvanzado.Location = new System.Drawing.Point(15, 73);
            this.lblFiltroAvanzado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroAvanzado.Name = "lblFiltroAvanzado";
            this.lblFiltroAvanzado.Size = new System.Drawing.Size(48, 13);
            this.lblFiltroAvanzado.TabIndex = 18;
            this.lblFiltroAvanzado.Text = "FILTRO:";
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(17, 88);
            this.txtFiltroAvanzado.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltroAvanzado.MaxLength = 15;
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(280, 20);
            this.txtFiltroAvanzado.TabIndex = 0;
            // 
            // cboCriterio
            // 
            this.cboCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(454, 88);
            this.cboCriterio.Margin = new System.Windows.Forms.Padding(2);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(107, 21);
            this.cboCriterio.TabIndex = 2;
            // 
            // lblCriterio
            // 
            this.lblCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(451, 73);
            this.lblCriterio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(61, 13);
            this.lblCriterio.TabIndex = 15;
            this.lblCriterio.Text = "CRITERIO:";
            // 
            // cboCampo
            // 
            this.cboCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(313, 88);
            this.cboCampo.Margin = new System.Windows.Forms.Padding(2);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(119, 21);
            this.cboCampo.TabIndex = 1;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // lblCampo
            // 
            this.lblCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(310, 73);
            this.lblCampo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(48, 13);
            this.lblCampo.TabIndex = 13;
            this.lblCampo.Text = "CAMPO:";
            // 
            // btnOpciones
            // 
            this.btnOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpciones.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpciones.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnOpciones.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnOpciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnOpciones.Location = new System.Drawing.Point(834, 370);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(100, 45);
            this.btnOpciones.TabIndex = 10;
            this.btnOpciones.Text = "OPCIONES";
            this.btnOpciones.UseVisualStyleBackColor = false;
            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxArticulo.BackColor = System.Drawing.Color.Silver;
            this.pbxArticulo.Location = new System.Drawing.Point(694, 118);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(240, 211);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 20;
            this.pbxArticulo.TabStop = false;
            // 
            // cboImagenes
            // 
            this.cboImagenes.AllowDrop = true;
            this.cboImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboImagenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImagenes.FormattingEnabled = true;
            this.cboImagenes.Location = new System.Drawing.Point(694, 335);
            this.cboImagenes.Name = "cboImagenes";
            this.cboImagenes.Size = new System.Drawing.Size(239, 21);
            this.cboImagenes.TabIndex = 5;
            this.cboImagenes.SelectedIndexChanged += new System.EventHandler(this.cboImagenes_SelectedIndexChanged);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(954, 431);
            this.Controls.Add(this.cboImagenes);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.btnOpciones);
            this.Controls.Add(this.lblFiltroAvanzado);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Label lblFiltroAvanzado;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Button btnOpciones;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.ComboBox cboImagenes;
    }
}