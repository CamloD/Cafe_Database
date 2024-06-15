using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cafe_DataBase.Forms
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        #region "variables"
        string name, ident, tel;
        #endregion

        #region "procesos"

        #endregion

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultClients consultarClientes = new ConsultClients();
            consultarClientes.inicioCuadro(3);
            consultarClientes.ShowDialog();
        }
    }
}
