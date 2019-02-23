using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Entities;
namespace App.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Forma oForma = new Forma();
            oForma.LadoX = Convert.ToDecimal(txtLadoX.Text);
            oForma.LadoY = Convert.ToDecimal(txtLadoY.Text);
            oForma.Area = 0.00M;
            oForma.TipoForma = ObtenerTipoForma();
            if (!String.IsNullOrEmpty(oForma.TipoForma))
            {
                oForma.onDespuesCalcular += new App.Entities.Events.Listeners.DespuesCalcular(MostrarDatos);
                oForma.calcularArea();
            }

        }
        private void MostrarDatos(object obj)
        {
            Forma objForma = (Forma)obj;
            lblResultado.Text = $"El area del {objForma.TipoForma} es de {objForma.Area}";
        }

        private string ObtenerTipoForma()
        {
            string tipoForma = String.Empty;
            if (cuadrado.Checked)
            {
                tipoForma = "cuadrado";
            }
            else if (triangulo.Checked)
            {
                tipoForma = "triangulo";
            }
            else if (circulo.Checked)
            {
                tipoForma = "circulo";
            }
            else
            {
                tipoForma = String.Empty;
            }
            return tipoForma;
        }

    }
}
