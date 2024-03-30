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

        #endregion

        #region "procesos"
        
        #endregion


        internal void nombress(string name, string nombres2)
        {
            label1.Text = name;
            textBox1.Text = nombres2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultClients.ShowDialog();
        }
    }
}
