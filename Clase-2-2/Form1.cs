using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Clase_2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //EVENTOS
        public class Termostato
        {
            private int temperatura;
            
            //1. DECLARACION DEL EVENTO
            public event EventHandler Peligro;
            
            public int Temperatura
            {
                get { return temperatura; }
                set { temperatura = value; 

                    //2. DESENCADENAR EVENTO
                      if (Temperatura > 100) 
                        Peligro?.Invoke(null,null);
                     }
            }
            
        }


        Termostato T; //crea variable global
        private void button1_Click(object sender, EventArgs e)
        {
            T = new Termostato(); //crea el objeto
            MessageBox.Show($"Termometro creado {T.Temperatura }");
            //3. suscripcion del evento
            T.Peligro += AltaTemperatura;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            T.Temperatura = int.Parse(Interaction.InputBox("ingrese la temperatura: "));//pide cargar temperaura
        }

        private void AltaTemperatura( object sender, EventArgs e) //muestra una notificacion
        {
            MessageBox.Show($"Alta temperatura: {T.Temperatura}");
        }

    }
}
