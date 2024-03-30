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
using Cafe_DataBase.logica;
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
            DisenoPersonalizado();
            ProcesosIniciales();
        }

        #region "Variables"
        string name, ident, tel;

        #endregion


        #region "Procesos"
        private void Formato_clientes()
        {
            Dgv_Clientes.Columns[0].Width = 20;
            Dgv_Clientes.Columns[0].HeaderText = "ID";
            Dgv_Clientes.Columns[1].Width = 120;
            Dgv_Clientes.Columns[1].HeaderText = "Nombres";
            Dgv_Clientes.Columns[2].Visible = false;
            Dgv_Clientes.Columns[3].Visible = false;
            /*
            Dgv_Clientes.Columns[2].Width = 60;
            Dgv_Clientes.Columns[2].HeaderText = "Identificacion";
            Dgv_Clientes.Columns[3].Width = 65;
            Dgv_Clientes.Columns[3].HeaderText = "Telefono";
            */
            Dgv_Clientes.Columns[4].Width = 60;
            Dgv_Clientes.Columns[4].HeaderText = "Tipo Café";
            Dgv_Clientes.Columns[5].Width = 35;
            Dgv_Clientes.Columns[5].HeaderText = "Precio";
            Dgv_Clientes.Columns[6].Width = 60;
            Dgv_Clientes.Columns[6].HeaderText = "Cantidad(Kg)";
            Dgv_Clientes.Columns[7].Width = 40;
            Dgv_Clientes.Columns[7].HeaderText = "Total";
            Dgv_Clientes.Columns[8].Width = 200;
            Dgv_Clientes.Columns[8].HeaderText = "Fecha Proceso";
        }

        private void listado_clientes(string texto)
        {
            L_Proceso_Clientes Datos = new L_Proceso_Clientes();
            Dgv_Clientes.DataSource = Datos.Listado_Clientes(texto);
            this.Formato_clientes();
        }

        private void ProcesosIniciales()
        {
           // Txt_Nombre.Enabled = false;
           // Txt_Identificacion.Enabled = false;
           // Txt_Teléfono.Enabled = false;
        }

        private void DisenoPersonalizado()
        {
            Desplegable.Items.AddRange(
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

        #endregion  // ----------------------------------------------------------------------------------------------

        private void Clientes_Load(object sender, EventArgs e)
        {
            listado_clientes("%");   
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            consultClients.ShowDialog();
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {

        }

        private void Dropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string tip;
            tip = Desplegable.SelectedItem.ToString();

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
            
        }

        
    }
}
