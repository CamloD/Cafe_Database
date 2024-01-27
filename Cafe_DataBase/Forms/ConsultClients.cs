using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_DataBase.Forms
{
    public partial class ConsultClients : Form
    {
        public ConsultClients()
        {
            InitializeComponent();
        }



        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
