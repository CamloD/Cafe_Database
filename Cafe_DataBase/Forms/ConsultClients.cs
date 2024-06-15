using Cafe_DataBase.logica;
using Cafe_DataBase.Forms;
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
        private bool formato_ar_ejecutado = false;
        public int valor = 0;
        internal string nombre, telefono, identificacion;
        internal int accion = 0;
        int inicio_Valor = 0;
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
            if (!formato_ar_ejecutado)
            {
                this.Formato_clientes();
                formato_ar_ejecutado = true;
            }

        }

        internal void inicioCuadro(int dat)
        {
            inicio_Valor = dat;
        }
        #endregion  // ---------------------------------------------------------------------------------------------------------------------



        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Txt_buscar.Text = "";
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Txt_buscar.Text = "";
        }

        private void ConsultClients_Load(object sender, EventArgs e)
        {
            this.listado_registro("%"); // Porcentaje para mostrar algo
            Txt_buscar.PlaceholderText = "Buscar";
        }

        private void Txt_buscar_TextChange(object sender, EventArgs e)
        {
            string textoBusqueda = Txt_buscar.Text.ToLower(); // Obtener el texto de búsqueda en minúsculas
            foreach (DataGridViewRow row in Dgv_ClientesRegistrados.Rows)
            {
                bool coincide = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(textoBusqueda))
                    {
                        coincide = true; // Marcar la fila como coincidente si se encuentra la coincidencia en alguna celda
                        break;
                    }
                }

                if (coincide)
                {
                    row.Visible = true; // Mostrar la fila si coincide con la búsqueda
                }
                else
                {
                    if (!row.IsNewRow) // Verificar que no sea la fila de nuevo registro
                    {
                        Dgv_ClientesRegistrados.CurrentCell = null; // Desseleccionar cualquier celda actualmente seleccionada
                        row.Visible = false; // Ocultar la fila si no coincide con la búsqueda
                    }
                }
            }

        }

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            Clientes clientesForm = new Clientes();
            Form1 formulario1 = new Form1();
            Form2 formulario2 = new Form2();


            //clientesForm.Txt_Nombre.Text = Dgv_ClientesRegistrados.CurrentRow.Cells["nombre"].Value.ToString();
            //clientesForm.Txt_Identificacion.Text = Dgv_ClientesRegistrados.CurrentRow.Cells["identificacion"].Value.ToString();
            //clientesForm.Txt_Teléfono.Text = Dgv_ClientesRegistrados.CurrentRow.Cells["telefono"].Value.ToString();

            //clientesForm.txt_prueba.Text = Dgv_ClientesRegistrados.CurrentRow.Cells["nombre"].Value.ToString();

            nombre = Dgv_ClientesRegistrados.CurrentRow.Cells["nombre"].Value.ToString();
            identificacion = Dgv_ClientesRegistrados.CurrentRow.Cells["identificacion"].Value.ToString();
            telefono = Dgv_ClientesRegistrados.CurrentRow.Cells["telefono"].Value.ToString();


            if (inicio_Valor == 1)
            {
                //clientesForm.recogerData(nombre, identificacion, telefono);
            }
            if (inicio_Valor == 2)
            {
                formulario1.recogerdata(nombre, identificacion, telefono);
                formulario1.MostrarData();
                formulario1.textBox1.Text = nombre;
                formulario1.textBox1.Update();
                formulario1.textBox1.Refresh();

                formulario1.button2.PerformClick();
                formulario1.button2.PerformClick();
                formulario1.button2.PerformClick();




            }
            if (inicio_Valor == 3)
            {
               
            }

            // Cerrar el formulario actual
            this.Close();
        }
    }
}
