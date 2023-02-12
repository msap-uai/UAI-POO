using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase___3_Polimorfismo
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




        #region "Clases"
        public abstract class Operacion
        {
            public abstract decimal Ejecutar(decimal n1, decimal n2); // obliga a que se implemente en la herencia
            // metodo polimorfico
        }

        public class Suma : Operacion
        {
            public override decimal Ejecutar(decimal n1, decimal n2) //reescribe el metodo heredado
            {
                return n1 + n2;
            }
        }
        public class Restar : Operacion
        {
            public override decimal Ejecutar(decimal n1, decimal n2)
            {
                return n1 - n2;
            }
        }
        public class Multiplicar : Operacion
        {
            public override decimal Ejecutar(decimal n1, decimal n2)
            {
                return n1 * n2;
            }
        }
        #endregion

        #region "HERRAMIENTAS
        private void button1_Click(object sender, EventArgs e)
        {
            //Boton suma SUMA
            FuncionEjecutar(new Suma()); // paso un objeto de tipo suma
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FuncionEjecutar(new Restar());
        }

        #endregion

        #region"FUNCIONES"
        private void FuncionEjecutar(Operacion pOperacion)
        {
            
            textBox3.Text = pOperacion.Ejecutar(decimal.Parse(textBox1.Text), decimal.Parse(textBox2.Text)).ToString();
                //textobox3 es donde muestra los datos
        }
        #endregion

       
    }
}
