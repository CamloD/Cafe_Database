using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Cafe_DataBase.Forms
{
    public partial class Clientes : Form
    {
        ConsultClients consultClients;
        public Clientes()
        {
            InitializeComponent();
            consultClients = new ConsultClients();
            customizeDesign();
        }
        private void customizeDesign()
        {
            Dropdown1.Items.AddRange(
                new String[]
                {
                    "Café Verde",
                    "Café Seco",
                    "Café Pasilla",
                    
                });
            Text_Cant.PlaceholderText = "Escribe Cantidad en Kg";
            Text_Price.PlaceholderText = "Precio por Kg";

            Text_Cant.Enabled = false;
            Text_Price.Enabled = false;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            consultClients.ShowDialog();
        }

        private void Dropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string tip;
            tip = Dropdown1.SelectedItem.ToString();

            if (tip != "Seleccionar")
            {
                Text_Cant.Enabled = true;
                Text_Price.Enabled = true;

                if (tip == "Café Verde")
                {
                    Text_Cant.PlaceholderText = "Cantidad Café Verde";
                }
                if (tip == "Café Seco")
                {
                    Text_Cant.PlaceholderText = "Cantidad Café Seco";
                }
                if (tip == "Café Pasilla")
                {
                    Text_Cant.PlaceholderText = "Cantidad Pasilla";
                }
            }
            else
            { 
                Text_Cant.Enabled = false;
                Text_Price.Enabled = false;
                Text_Cant.PlaceholderText = "Escribe Cantidad en Kg";
                Text_Price.PlaceholderText = "Escribe el Precio";
            }

            if (tip == string.Empty )
            {
                Text_Cant.Enabled = false;
                Text_Price.Enabled = false;
                Text_Cant.PlaceholderText = "Escribe Cantidad en Kg";
                Text_Price.PlaceholderText = "Escribe el Precio";
                
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            //DataGrid1.
        }
    }
}
