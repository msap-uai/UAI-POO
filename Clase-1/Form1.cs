using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //ejecuacion al inicio del codigo
        {
            Cliente c1; // crea la variable cleinte
            Cliente c2 = new Cliente();//instancia el objeto ciente
            //tipo       objeto
            Object c12 = new ClienteInternacional();
            
            ClienteInternacional c3 = new ClienteInternacional();
            float nombre = c3.Descuento; // tiene nombre porque hereda de cliente


         //mesclando los tipos
            Cliente c4 = new ClienteInternacional();
            float nom4 = c4.Descuento;//solo tiene la propiedad descuentonombre y no telefono de cliente internaiconal

            //ClienteInternacional c5 = Cliente(); // no permite porque tiene mas propiedades

            //CONVERTIR OBJETO
            Object m = new ClienteInternacional();
            Cliente p = m as Cliente; // p es imagen de m
            ClienteInternacional r = p as ClienteInternacional;


        }

        private void button1_Click(object sender, EventArgs e)//boton al darle click
        {
            Cliente maria = new ClienteInternacional(); maria.Descuento = 10; 
            Cliente pablo = new ClienteNacional();  pablo.Descuento = 20;

            Persona2(maria); // llamo a la funcion y paso el objeto
            Persona2(pablo);
        }

        //funcion

        private void Persona2(Cliente a) // recibe un tipo Cliente no importa cual sea nacional o internacional
        {
            MessageBox.Show(a.Descuento.ToString());

        }
    }
    public class Cliente //crea el tipo de la clase cliente
    {
        private float descuento;

        public float Descuento { get => descuento; set => descuento = value; }
    }
    public class ClienteInternacional : Cliente // hereda de cliente
    {
        private string telefono;
        public string Telefono { get => telefono; set => telefono=value; }
    }
    public class ClienteNacional : Cliente // hereda de cliente
    {
        private string cuit;
        public string Cuit { get => cuit; set => cuit = value; }
    }
}
