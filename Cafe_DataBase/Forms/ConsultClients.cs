using Cafe_DataBase.logica;
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

        #region "Mis variables"
        int cont = 0;
        private bool formato_ar_ejecutado = false;

        #endregion

        #region "Procesos"
        private void Formato_clientes()
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
            if(!formato_ar_ejecutado)
            { 
                this.Formato_clientes();
                formato_ar_ejecutado = true;
            }

            cont++;

        }
        #endregion



        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultClients_Load(object sender, EventArgs e)
        {
            this.listado_registro("%"); // Porcentaje para mostrar algo
        }
    }
}
