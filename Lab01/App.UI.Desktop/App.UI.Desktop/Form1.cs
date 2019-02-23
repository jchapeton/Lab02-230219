using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using App.Entities;
namespace App.UI.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblProp.Text = ConfigurationManager.AppSettings["IGV"].ToString();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Factura oFactura = new Factura();
            //oFactura.Total = Convert.ToDecimal(txtTotal.Text);
            //oFactura.Calcular();
            //lblTotal.Text = oFactura.Total.ToString();
            //lblSubTotal.Text = oFactura.SubTotal.ToString();
            //lblIGV.Text = oFactura.IGV.ToString();

            //Solo acepta instanciar de Factura porque la Clase Factura hereda de Documento
            Documento oFactura = new Factura();
            oFactura.Total = Convert.ToDecimal(txtTotal.Text);
            oFactura.onDespuesCalcular += new Entities.Events.Listeners.DespuesCalcular(MostrarDatos);
            oFactura.Calcular();

        }
        private void MostrarDatos(object obj)
        {
            var oFactura = (Factura)obj;
            lblTotal.Text = oFactura.Total.ToString();
            lblSubTotal.Text = ((Factura)oFactura).SubTotal.ToString();
            lblIGV.Text = ((Factura)oFactura).IGV.ToString();
        }
    }
}
