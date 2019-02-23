namespace App.Desktop
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
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cuadrado = new System.Windows.Forms.RadioButton();
            this.triangulo = new System.Windows.Forms.RadioButton();
            this.circulo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtLadoX = new System.Windows.Forms.TextBox();
            this.txtLadoY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(47, 161);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(424, 28);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "CALCULAR";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RESULTADO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "LADO X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "LADO Y";
            // 
            // cuadrado
            // 
            this.cuadrado.AutoSize = true;
            this.cuadrado.Location = new System.Drawing.Point(50, 60);
            this.cuadrado.Name = "cuadrado";
            this.cuadrado.Size = new System.Drawing.Size(86, 17);
            this.cuadrado.TabIndex = 4;
            this.cuadrado.TabStop = true;
            this.cuadrado.Text = "CUADRADO";
            this.cuadrado.UseVisualStyleBackColor = true;
            // 
            // triangulo
            // 
            this.triangulo.AutoSize = true;
            this.triangulo.Location = new System.Drawing.Point(201, 60);
            this.triangulo.Name = "triangulo";
            this.triangulo.Size = new System.Drawing.Size(88, 17);
            this.triangulo.TabIndex = 5;
            this.triangulo.TabStop = true;
            this.triangulo.Text = "TRIÁNGULO";
            this.triangulo.UseVisualStyleBackColor = true;
            // 
            // circulo
            // 
            this.circulo.AutoSize = true;
            this.circulo.Location = new System.Drawing.Point(357, 60);
            this.circulo.Name = "circulo";
            this.circulo.Size = new System.Drawing.Size(72, 17);
            this.circulo.TabIndex = 6;
            this.circulo.TabStop = true;
            this.circulo.Text = "CIRCULO";
            this.circulo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "CALCULAR ÁREA";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(144, 224);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(10, 13);
            this.lblResultado.TabIndex = 8;
            this.lblResultado.Text = " ";
            // 
            // txtLadoX
            // 
            this.txtLadoX.Location = new System.Drawing.Point(168, 93);
            this.txtLadoX.Name = "txtLadoX";
            this.txtLadoX.Size = new System.Drawing.Size(100, 20);
            this.txtLadoX.TabIndex = 9;
            // 
            // txtLadoY
            // 
            this.txtLadoY.Location = new System.Drawing.Point(168, 126);
            this.txtLadoY.Name = "txtLadoY";
            this.txtLadoY.Size = new System.Drawing.Size(100, 20);
            this.txtLadoY.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 266);
            this.Controls.Add(this.txtLadoY);
            this.Controls.Add(this.txtLadoX);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.circulo);
            this.Controls.Add(this.triangulo);
            this.Controls.Add(this.cuadrado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalcular);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton cuadrado;
        private System.Windows.Forms.RadioButton triangulo;
        private System.Windows.Forms.RadioButton circulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtLadoX;
        private System.Windows.Forms.TextBox txtLadoY;
    }
}

