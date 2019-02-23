using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Entities.Events.Listeners; //los eventos son estaticos 
namespace App.Entities
{
    public class Forma
    {
        public event DespuesCalcular onDespuesCalcular;

        private const decimal PI = 3.14M;

        public decimal LadoX { get; set; }
        public decimal LadoY { get; set; }
        public decimal Area { get; set; }
        public string TipoForma { get; set; }

        public void calcularArea()
        {
            switch (TipoForma)
            {
                case "cuadrado":
                    Area = LadoX * LadoY;
                    break;
                case "triangulo":
                    Area = (LadoX * LadoY) / 2;
                    break;
                case "circulo":
                    Area = PI * LadoX;
                    break;
                default:
                    break;
            }
            if (onDespuesCalcular != null)
            {
                onDespuesCalcular(this);
            }
        }
    }
}
