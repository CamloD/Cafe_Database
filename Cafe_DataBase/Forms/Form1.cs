using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cafe_DataBase.Forms;

namespace Cafe_DataBase.Forms
{
    public partial class Form1 : Form
    {
        ConsultClients consultClients;
        public Form1()
        {
            InitializeComponent();
            consultClients = new ConsultClients();
            
        }
        #region "variables"
        internal static string val1, val2, val3;

        #endregion

        #region "procesos"
        internal void recogerdata (string dat1, string dat2, string dat3)
        {

            Form1.val1 = dat1.ToString();
            Form1.val2 = dat2.ToString();
            Form1.val3 = dat3.ToString();

            
           
                //textBox1.Text = Form1.val1.ToString();
                MostrarData();

            
        }

        internal void MostrarData()
        {
            textBox1.Text = val1;
            textBox2.Text = "Monday";
           // button2.PerformClick();
        }
        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
           
            /*textBox1.Text = "Hola";
            textBox2.Text = val1 ;*/
            textBox2.Update();
            MostrarData();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ConsultClients consultarClientes = new ConsultClients();
            consultClients.inicioCuadro(2);
            consultClients.ShowDialog();

        }
    }
}
