﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Entities.Events.Listeners; //los eventos son estaticos
namespace App.Entities
{
    public class Documento
    {
        public event DespuesCalcular onDespuesCalcular;

        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        //Procedimiento
        public virtual void Calcular()
        {
            if (this.onDespuesCalcular != null)
            {
                onDespuesCalcular(this);
            }
        }
    }
}
