﻿namespace Chinook.UI.Desktop
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.dcCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFiltroXNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(234, 29);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dcCodigo,
            this.dcNombre});
            this.dgvListado.Location = new System.Drawing.Point(16, 76);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.Size = new System.Drawing.Size(658, 348);
            this.dgvListado.TabIndex = 1;
            // 
            // dcCodigo
            // 
            this.dcCodigo.DataPropertyName = "ArtistId";
            this.dcCodigo.HeaderText = "Código";
            this.dcCodigo.Name = "dcCodigo";
            // 
            // dcNombre
            // 
            this.dcNombre.DataPropertyName = "Name";
            this.dcNombre.HeaderText = "Nombre";
            this.dcNombre.Name = "dcNombre";
            // 
            // txtFiltroXNombre
            // 
            this.txtFiltroXNombre.Location = new System.Drawing.Point(24, 31);
            this.txtFiltroXNombre.Name = "txtFiltroXNombre";
            this.txtFiltroXNombre.Size = new System.Drawing.Size(174, 20);
            this.txtFiltroXNombre.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 438);
            this.Controls.Add(this.txtFiltroXNombre);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.btnConsultar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcNombre;
        private System.Windows.Forms.TextBox txtFiltroXNombre;
    }
}

