using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; //permite usar el interaction.inputbox

namespace Clase_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            MessageBox.Show(cli.VarProperty.ToString());
            cli.VarProperty = 5; //asigna un valor
            MessageBox.Show(cli.VarProperty.ToString());

            cli.nombre = Interaction.InputBox("Ingrese el nombre:"); //input. resuiqre using Microsoft.VisualBasic;
            MessageBox.Show(cli.nombre.ToString());

            MessageBox.Show($"nombre: {cli.nombre} {Environment.NewLine}" + //salto de linea
                            $" Fecha y Hora:  { cli.Fecha_hora}"); //concatenar string

            cli.Nick = Interaction.InputBox("Ingrese el nick:"); //input. resuiqre using Microsoft.VisualBasic;


            MessageBox.Show($"nombre: {cli.NombreCompleto("Sra")}");
            MessageBox.Show($"nombre: {cli.NombreCompleto()}"); // sin parametro
        
        
        } //al finalizar la funcion los objetos que contienen se pierden

        #region "HERRAMIENTAS DEL FORMULARIO"
        Cliente c3;  // varibale objeto goblal
        private void button2_Click(object sender, EventArgs e)
        {
            c3 = new Cliente(32,"Mariano"); //crea onjeto
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            c3 = null; //limpia el objeto
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GC.Collect(); // fuerza la ejecucion del limpiar de memoria
        }
        #endregion
    }

    //clases
    public class Cliente
    {

        #region "Campos"
        //CAMPOS (o variables dentro de la clase)
        //siempre son privados (encapsulamiento)
        int codigo; // int campor = 0; //valor inicial
        string nick;

        #endregion

        #region " PROPIEDADES (GETTERS Y SETTERS)"
        //permiten controlar la accesibilidad
        //propfull <tab><tab> muestra un modelo de campo con propiedades
        private int myVar;
        public int VarProperty // declaracion explicita
        {
            get { return myVar; }
            set { myVar = value; }
        }

    //prop <tab><tab>
        public int Dni { get; set; }//declaracion implicita
        public string nombre { get; set; }
        public DateTime Fecha_hora { get { return DateTime.Now; } } //funcion dentro de el getter
        public string Nick {set { nick = value; } } // setter unicamente

        #endregion


        #region "METODO CONTRUCTOR"
        // metodo que se crea al crear al objeto
        // restringe la forma en que se crea el objeto
        
        public Cliente()
        {

        }

        //sobrecarga de metodos. permite varias formas de metodo contructor
        //es un metodo que tienen igual nombre pero distinta firma (paramtros)
        public Cliente(int _codigo, string nombre = "") //permite tomar 2 parametros o uno solo
        {
            this.codigo = _codigo; // asigna al campo
        }
        #endregion

        #region "METODOS"
        //determinan el comportamiento del objeto. son funciones que hacen cosas con los campos
        //los campos reciben o devuelven valores
        public string NombreCompleto(string prefijo = "Sr.") //valor por defecto 
        {
            return this.nick + this.nombre;
            //return $"{this.nombre}";
        }
        #endregion

        #region"METODO DESTRUCTOR"
        //finaliza el ciclo de vida de un objeto
        //existe un proceso que a los objetos que no apuntan a nadie el barvege colector lo borra
        // se ejecuta cuando se destruye, no lo destruye
        ~Cliente()
        {
            MessageBox.Show("Se ejecuto el destructor");
        }


        #endregion

        #region "EVENTOS"
        //reaccion frente a un elemento interno o externo
    

        #endregion
    }
}
