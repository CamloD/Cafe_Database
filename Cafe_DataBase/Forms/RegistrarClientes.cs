using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Cafe_DataBase.Modelo;
using Cafe_DataBase.logica;


namespace Cafe_DataBase.Forms
{
    public partial class RegistrarClientes : Form
    {
        
        public RegistrarClientes()
        {
            InitializeComponent();
            LimpiarCasillas();
            procesos_iniciales();

        }

        #region "mis Variables"
        string dato = "";
        int EstadoGuardar = 0;
        int codigo_cliente = 0;
        DateTime fecha;
        #endregion //----------------------------------------------------------------------------------------------


        #region "procesos"
        void LimpiarCasillas()
        {
            TxtBuscar.Clear();
        }

        private void procesos_iniciales()
        {
            Txt_ID.ReadOnly = true;
            Txt_ID.Enabled = false;
            Txt_Telefono.MaxLength = 10;
            
        }

        private void Limpia_texto()
        {
            Txt_Nombres.Clear();
            Txt_Identificacion.Clear();
            Txt_Telefono.Clear();
            Txt_ID.Clear();
        }

        private void Formato_clientes()
        {
            Dgv_registro.Columns[0].Width = 25;
            Dgv_registro.Columns[0].HeaderText = "ID";
            Dgv_registro.Columns[1].Width = 120;
            Dgv_registro.Columns[1].HeaderText = "Nombres";
            Dgv_registro.Columns[2].Width = 60;
            Dgv_registro.Columns[2].HeaderText = "Identificacion";
            Dgv_registro.Columns[3].Width = 60;
            Dgv_registro.Columns[3].HeaderText = "Telefono";
            Dgv_registro.Columns[4].Width = 200;
            Dgv_registro.Columns[4].HeaderText = "Fecha Ingreso";
        }

        private void listado_registro(string texto)
        {
            L_Proceso_Registro Datos = new L_Proceso_Registro();
            Dgv_registro.DataSource = Datos.Listado_registro(texto);
            this.Formato_clientes();
            
        }

        private void Estado_texto(bool lEstado)
        {
            Txt_Nombres.Enabled = lEstado;
            Txt_Nombres.ReadOnly = !lEstado;
            Txt_Identificacion.Enabled = lEstado;
            Txt_Identificacion.ReadOnly = !lEstado;
            Txt_Telefono.Enabled = lEstado;
            Txt_Telefono.ReadOnly = !lEstado;
        }

        private void Estado_botoncesprocesos(bool lEstado)
        {
            Btn_nuevo.Enabled = !lEstado;
            Btn_Editar.Enabled = !lEstado;
            Btn_Guardar.Enabled = lEstado;
            Btn_Cancelar.Enabled = lEstado;
            Btn_Eliminar.Enabled = !lEstado;

            Dgv_registro.Enabled = !lEstado;   
        }
        private void Estado_botonesacciones(bool lEstado)
        {
            Btn_Cancelar.Visible = lEstado;
            Btn_Guardar.Visible = lEstado;
        }

        private void Seleccion_Item_RegClientes()
        {
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_registro.CurrentRow.Cells["cod_cliente"].Value)))
            {
                MessageBox.Show("Seleccione un Registro",
                               "Aviso del Sistema",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation);
            }
            else
            {
                codigo_cliente = Convert.ToInt32(Dgv_registro.CurrentRow.Cells["cod_cliente"].Value);
                Txt_ID.Text = Convert.ToString(Dgv_registro.CurrentRow.Cells["cod_cliente"].Value);
                Txt_Nombres.Text = Convert.ToString(Dgv_registro.CurrentRow.Cells["nombre"].Value);
                Txt_Identificacion.Text = Convert.ToString(Dgv_registro.CurrentRow.Cells["identificacion"].Value);
                Txt_Telefono.Text = Convert.ToString(Dgv_registro.CurrentRow.Cells["telefono"].Value);
                fecha = Convert.ToDateTime(Dgv_registro.CurrentRow.Cells["fecha_registro"].Value);
            }
        }



        #endregion  //--------------------------------------------------------------------------------------------


        private void RegistrarClientes_Load(object sender, EventArgs e)
        {            
            this.listado_registro("%"); // Porcentaje para mostrar algo
            this.Estado_botonesacciones(false);
            this.Estado_botoncesprocesos(false);
            Estado_texto(false);
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Fecha1.Text = DateTime.Now.ToString("G");
        }


        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadoGuardar = 1; //Nuevo Registro
            this.Limpia_texto();
            this.Estado_texto(true);
            this.Estado_botoncesprocesos(true);
            this.Estado_botonesacciones(true);

            Txt_Nombres.Focus();


        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            EstadoGuardar = 0;
            
            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_botoncesprocesos(false);
            this.Estado_botonesacciones(false);

        }
        private void Txt_Telefono_TextChange(object sender, EventArgs e)
        {
            string texto = Txt_Telefono.Text;
            int tama_text = texto.Length;
            int numero;

            if(tama_text <= 1)
            {
                if (!int.TryParse(Txt_Telefono.Text, out numero))
                {
                    // El texto del control no es un valor int válido
                    Txt_Telefono.Text = "";
                }
            }
            else
            {
                if (!int.TryParse(texto, out numero))
                {
                    // Ignorar los demás caracteres
                    texto = texto.Where(char.IsDigit).Aggregate("", (CadAcumulada, DigActual) => CadAcumulada + DigActual);
                    Txt_Telefono.Text = texto;
                    Txt_Telefono.SelectionStart = tama_text;
                }
            }   
        }
        private void Txt_Identificacion_TextChange(object sender, EventArgs e)
        {
            string texto = Txt_Identificacion.Text;
            int c = texto.Length;
            int tama_text = texto.Length;
            int numero;

            if (tama_text <= 1)
            {
                if (!int.TryParse(Txt_Identificacion.Text, out numero))
                {
                    // El texto del control no es un valor int válido
                    Txt_Identificacion.Text = "";
                }
            }
            else
            {
                if (!int.TryParse(texto, out numero))
                {
                    // Ignorar los demás caracteres
                    texto = texto.Where(char.IsDigit).Aggregate("", (CadAcumulada, DigActual) => CadAcumulada + DigActual);
                    Txt_Identificacion.Text = texto;
                    Txt_Identificacion.SelectionStart = tama_text;
                }
            }
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_Nombres.Text == String.Empty || Txt_Telefono.Text == string.Empty)
            {
                MessageBox.Show("Ingrese los datos Requeridos (*)",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                #region "operaciones Guardar"
                string datas = Txt_Telefono.Text.Replace(" ", "");
                #endregion

                M_clientes oPro = new M_clientes();
                oPro.cod_cliente = codigo_cliente;
                oPro.nombre = Txt_Nombres.Text.Trim();
                if (string.IsNullOrEmpty(Txt_Identificacion.Text))
                {
                    oPro.identificacion = 0;
                }
                else
                {
                    oPro.identificacion = int.Parse(Txt_Identificacion.Text);
                }

                oPro.telefono = long.Parse(datas.Trim());
                if (EstadoGuardar == 1)
                {
                    oPro.fecha_registro = DateTime.Now;
                }
                else
                {
                    oPro.fecha_registro = fecha;
                }

                string Rpta = "";
                L_Proceso_Registro Datos = new L_Proceso_Registro();
                Rpta = Datos.guarda_registro(EstadoGuardar, oPro);
                Limpia_texto();
                if (Rpta.Equals("OK"))
                {
                    this.Estado_texto(false);
                    this.Estado_botoncesprocesos(false);
                    this.Estado_botonesacciones(false);
                    this.listado_registro("%");   // muestreme toda la informacion
                    EstadoGuardar = 0;
                    MessageBox.Show("Los Datos han sido Guardado Correctamente",
                                   "Aviso del Sistema",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Rpta);
                }
            }
        }
        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Txt_ID.Text)))
            {
                MessageBox.Show("Seleccione un Registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                EstadoGuardar = 2;
                this.Estado_texto(true);
                this.Estado_botoncesprocesos(true);
                this.Estado_botonesacciones(true);
                Txt_Nombres.Focus();
            }
            
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if(Dgv_registro.Rows.Count > 0)
            {
                String Rpta = "";
                L_Proceso_Registro Datos = new L_Proceso_Registro();
                Rpta = Datos.Borrar_registro(codigo_cliente);
                if (Rpta.Equals("OK"))
                {
                    this.listado_registro("%");
                    codigo_cliente = 0;
                    this.Limpia_texto();
                    MessageBox.Show("El Registro ha sido Eliminado",
                                    "Aviso del Sistem",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(Rpta);
                }
            }

        }

        private void Dgv_registro_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Seleccion_Item_RegClientes();
        }

        private void Btn_nuevo1_Click(object sender, EventArgs e)
        {
            EstadoGuardar = 1; //Nuevo Registro
            this.Limpia_texto();
            this.Estado_texto(true);
            this.Estado_botoncesprocesos(true);
            this.Estado_botonesacciones(true);

            Txt_Nombres.Focus();
        }

        private void TxtBuscar_TextChange(object sender, EventArgs e)
        {
            string textoBusqueda = TxtBuscar.Text.ToLower(); // Obtener el texto de búsqueda en minúsculas
            foreach (DataGridViewRow row in Dgv_registro.Rows)
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
                        Dgv_registro.CurrentCell = null; // Desseleccionar cualquier celda actualmente seleccionada
                        row.Visible = false; // Ocultar la fila si no coincide con la búsqueda
                    }
                }
            }
        }

        private void Btn_BuscarGrid_Click(object sender, EventArgs e)
        {
            

        }

   
    }
}

/*
 * texto = texto.Where(char.IsDigit).Aggregate("", (s, c) => s + c);
 * La línea de código texto = texto.Where(char.IsDigit).Aggregate("", (s, c) => s + c); la procesaría de la siguiente manera:
 * 
 * 1. Primero, el método Where filtraría todos los caracteres de la cadena que son dígitos. 
 * En este caso, los caracteres filtrados serían "1", "2", "3", "4", y "5".
 * 
 * 2. A continuación, el método Aggregate combinaría los caracteres filtrados en una nueva cadena. 
 *    En este caso, la cadena acumulada sería "12345".
 * 
 * Por lo tanto, el resultado final de la línea de código sería la cadena "12345".
 * Aquí hay un diagrama que ilustra el proceso:
 * 
 * ---------------------------------------------------------------
 * s: Representa la cadena acumulada hasta ahora.
 * c: Representa el dígito actual que se está procesando.
 * s + c: Concatena el dígito actual a la cadena acumulada.
 * ---------------------------------------------------------------
 * 
 * --->
 * texto = "Hello123World45"
 * 
 * // Filtra los caracteres que son dígitos
 * texto.Where(char.IsDigit)
 * 
 * // Combina los caracteres filtrados en una nueva cadena
 * texto.Aggregate("", (s, c) => s + c)
 * 
 * // Resultado final
 * "12345"

 * 
 */