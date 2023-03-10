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

        #region "CLASE"
        public class Termostato
        {
            private int temperatura;
            
            //1. DECLARACION DEL EVENTO
            public event EventHandler Peligro;
            //



            public int Temperatura
            {
                get { return temperatura; }
                set { temperatura = value; 

                    //2. DESENCADENAR EVENTO
                      if (Temperatura > 100) 
                        Peligro?.Invoke(null,null);
                     }
                    //if (Temperatura !=null) Peligro.Invoke(null,null)
            }
            
        }
        #endregion

        #region "Herramientas"
        Termostato T; //crea variable global
        private void button1_Click(object sender, EventArgs e)
        {
            T = new Termostato(); //crea el objeto
            MessageBox.Show($"Termometro creado {T.Temperatura }");
            //3. suscripcion del evento
            T.Peligro += AltaTemperatura;
            /* si me suscribo varias veces efecuta varias veces*/
        }
        

        
        private void button2_Click(object sender, EventArgs e)
        {
            T.Temperatura = int.Parse(Interaction.InputBox("ingrese la temperatura: "));//pide cargar temperaura
        }
        #endregion

        #region "FUNCIONES"
        private void AltaTemperatura( object sender, EventArgs e) //muestra una notificacion
        {
            MessageBox.Show($"Alta temperatura: {T.Temperatura}");
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            T.Peligro -= AltaTemperatura; //desuscribirse
        }
    }
}
