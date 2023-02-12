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

namespace Clase_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //crea variable global
        Factura a1;
        private void Form1_Load(object sender, EventArgs e)
        {
            //instancia objeto alarma
            a1 = new Factura();
            a1.Precio = 0;
            a1.nombre = "t001";
            a1.NomFactura += Ref;//suscribe al evento
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //4. Desuscripcion del evento
            a1.Descuento -= Aviso;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //3. suscripcion del evento
            a1.Descuento += Aviso;
        }

        private void Aviso(object sender, EventArgs e)
        {
            a1.Off10();
            MessageBox.Show($"Se Aplicara un descuento del 10%" +
                $"Su factura era de {a1.Precio}");
        }

        private void Ref(object sender, EventArgs e)
        {
            MessageBox.Show($"Factua con nombre de " +
                $"{(sender as Factura).nombre}"); // se especifica que tipo de objeto es
            //es para saber que objeto es el que esta llamando la funcion

            //e es informacion relacionada a ese evento (ver mouse move)
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text=$"Mouse X: {e.X} Y: {e.Y }"; //valores del objeto
            //text es el recuadro del formulario
                }
        private void button3_Click(object sender, EventArgs e)
        {
            a1.Precio = int.Parse(Interaction.InputBox("ingrese valor de compra: "));//pide cargar temperaura
            textBox1.Text = a1.Precio.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        
    }

    //1. DECLARACION DEL EVENTO
    public class Factura
    {
        //1. DECLARACION EVENTO
        public event EventHandler Descuento;
        // eventhandler es quien maneda el evento
        // siempre lleva dos parametro object sender, EventArgs e

        public event EventHandler NomFactura;

        double precio;
        public double Precio {
            get { return precio; }
            set { precio += value;
                //2. DESENCADENAR EVENTO
                if (precio > 1000)
                {
                    Descuento?.Invoke(null, null); // solo se ejecuta su esta suscripto al evento
                    //se pueden pasar parametros
                    NomFactura?.Invoke(this, null); //envia el objeto
                }
                    

            } 
        }

        public string nombre { get; set; }





        public void Off10()
        {
            this.precio = this.precio*0.9;
            MessageBox.Show($"Ahora es de {this.precio}");
        }
        

    }
    //son los datos que se enviaran de tipo evenArgs
    public class DatosFacturaEvetArgs : EventArgs
    {
        
    }
    









    







    //CLASE ANIDADA
    public class A
    {
        public class B
        {
            //no es herencia.
        }
    }
}
