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
        internal string name, ident, tel;
        int inicializado = 0;

        private bool formato_ar_ejecutado = false;
        public int valor = 0;
        internal string nombre, telefono, identificacion;
        internal int accion = 0;
        int inicio_Valor = 0;
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
            if (inicializado == 0)
            {
                Txt_Nombre.Enabled = false;
                Txt_Identificacion.Enabled = false;
                Txt_Teléfono.Enabled = false;

                inicializado = 1;
            }else
            {
               // InitializeComponent();
                //txt_prueba.Text = name;
                txt_prueba.Text = "name";

            }
             
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


        /* internal void recogerData(string data1, string data2, string data3)
         {
             name = data1;
             ident = data2;
             tel = data3;

             txt_prueba.Text = data1;
         }*/

        private void Formato_clientes1()
        {
            Dgv_ClientesRegistrados.Columns[0].Width = 25;
            Dgv_ClientesRegistrados.Columns[0].HeaderText = "ID";
            Dgv_ClientesRegistrados.Columns[1].Width = 120;
            Dgv_ClientesRegistrados.Columns[1].HeaderText = "Nombres";
            Dgv_ClientesRegistrados.Columns[2].Width = 60;
            Dgv_ClientesRegistrados.Columns[2].HeaderText = "Identificacion";
            Dgv_ClientesRegistrados.Columns[3].Width = 60;
            Dgv_ClientesRegistrados.Columns[3].HeaderText = "Telefono";
            Dgv_ClientesRegistrados.Columns[4].Width = 200;
            Dgv_ClientesRegistrados.Columns[4].HeaderText = "Fecha Ingreso";
        }
        private void listado_registro(string texto)
        {
            L_Proceso_Registro Datos = new L_Proceso_Registro();
            Dgv_ClientesRegistrados.DataSource = Datos.Listado_registro(texto);
            if (!formato_ar_ejecutado)
            {
                this.Formato_clientes1();
                formato_ar_ejecutado = true;
            }

        }

        internal void inicioCuadro(int dat)
        {
            inicio_Valor = dat;
        }

        #endregion  // ----------------------------------------------------------------------------------------------

        private void Clientes_Load(object sender, EventArgs e)
        {
            listado_clientes("%");

            this.listado_registro("%"); // Porcentaje para mostrar algo
            txt_Buscar2.PlaceholderText = "Buscar";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            /*ConsultClients consultarClientes = new ConsultClients();
            consultClients.inicioCuadro(1);
            consultClients.ShowDialog();*/

            ListCLientes.Visible = true;
            
        }

        private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            txt_prueba.Text = Dgv_ClientesRegistrados.CurrentRow.Cells[1].Value.ToString();
            Txt_Nombre.Text = Dgv_ClientesRegistrados.CurrentRow.Cells[1].Value.ToString();
            Txt_Identificacion.Text = Dgv_ClientesRegistrados.CurrentRow.Cells[2].Value.ToString();
            Txt_Teléfono.Text = Dgv_ClientesRegistrados.CurrentRow.Cells[3].Value.ToString();
            ListCLientes.Visible = false;

        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
           ListCLientes.Visible = false;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            ListCLientes.Visible = false;
            txt_Buscar2.Text = "";
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


        
    }
}
