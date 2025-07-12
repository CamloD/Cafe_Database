    using Bunifu.UI.WinForms;
    using Cafe_DataBase.logica;
    using Cafe_DataBase.Modelo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

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

            string dato = "";
            int EstadoGuardar = 0;
            int codigo_cliente = 0;
            DateTime fecha;
            int Suma_Ok = 0; // Variable para validar si se ha seleccionado un tipo de café y se ha ingresado el precio y cantidad
            #endregion


            #region "Procesos"
            private void Formato_clientes()
            {
                Dgv_Clientes.Columns[0].Width = 10;
                Dgv_Clientes.Columns[0].HeaderText = "ID";
                Dgv_Clientes.Columns[1].Width = 90;
                Dgv_Clientes.Columns[1].HeaderText = "Nombres";
                Dgv_Clientes.Columns[5].Visible = false;
                Dgv_Clientes.Columns[3].Visible = false;
                
                Dgv_Clientes.Columns[2].Width = 60;
                Dgv_Clientes.Columns[2].HeaderText = "Identificacion";
                /*
                Dgv_Clientes.Columns[3].Width = 65;
                Dgv_Clientes.Columns[3].HeaderText = "Telefono";
                */
                Dgv_Clientes.Columns[4].Width = 40;
                Dgv_Clientes.Columns[4].HeaderText = "Tipo Café";
                /*Dgv_Clientes.Columns[5].Width = 40;
                Dgv_Clientes.Columns[5].DefaultCellStyle.Format = "N2";
                Dgv_Clientes.Columns[5].HeaderText = "Precio";*/
                Dgv_Clientes.Columns[6].Width = 50;
                Dgv_Clientes.Columns[6].DefaultCellStyle.Format = "N2";
                Dgv_Clientes.Columns[6].HeaderText = "Cantidad(Kg)";
                Dgv_Clientes.Columns[7].Width = 50;
                Dgv_Clientes.Columns[7].DefaultCellStyle.Format = "N2";
                Dgv_Clientes.Columns[7].HeaderText = "Total";
                Dgv_Clientes.Columns[8].Width = 180;
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
                    Txt_Telefono.Enabled = false;

                    inicializado = 1;
                }
                else
                {
                    // InitializeComponent();
                    //txt_prueba.Text = name;

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

            private void Formato_clientes1()
            {

            }
            private void listado_registro(string texto)
            {
                L_Proceso_Registro Datos = new L_Proceso_Registro();

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


            private void Limpia_texto()
            {

                Desplegable.SelectedIndex = 0; // Resetea el desplegable a la opción "Seleccionar"
                Text_Cant.Text = "";
                Text_Price.Text = "";
                Txt_Total.Text = string.Empty;

            }

            private void Calcular()
            {
                if (!string.IsNullOrWhiteSpace(Text_Price.Text) && !string.IsNullOrWhiteSpace(Text_Cant.Text))
                {
                    var culture = new CultureInfo("en-US");

                    string precioTexto = Text_Price.Text.Replace(",", "").Trim();
                    string cantidadTexto = Text_Cant.Text.Replace(",", "").Trim();

                    if (decimal.TryParse(precioTexto, NumberStyles.Any, culture, out decimal precio) &&
                        decimal.TryParse(cantidadTexto, NumberStyles.Any, culture, out decimal cantidad))
                    {
                        decimal total = precio * cantidad;

                        if (total < 0)
                        {
                            MessageBox.Show("El total no puede ser negativo. Verifique los valores ingresados.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            Txt_Total.Text = "0";
                            return;
                        }

                        Txt_Total.Text = total.ToString("#,##0.####", culture);
                    }
                    else
                    {
                        Txt_Total.Text = "0";
                    }
                }
                else
                {
                    Txt_Total.Text = "0";
                }
            }


            #endregion  // ----------------------------------------------------------------------------------------------

            private void Clientes_Load(object sender, EventArgs e)
            {
                listado_clientes("%");

                this.listado_registro("%"); // Porcentaje para mostrar algo

            }

            private void Button_Limpiar_Click(object sender, EventArgs e)
            {
                Limpia_texto();
            }


            private void Text_Cant_TextChange(object sender, EventArgs e)
            {
                TextBox tb = sender as TextBox;
                if (tb == null || string.IsNullOrWhiteSpace(tb.Text))
                    return;

                var culture = new CultureInfo("en-US");

                int selectionStart = tb.SelectionStart;
                int originalLength = tb.Text.Length;

                string clean = tb.Text.Replace(",", "");

                if (decimal.TryParse(clean, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, culture, out decimal value))
                {
                    if (!clean.EndsWith("."))
                    {
                        string formatted = value.ToString("#,##0.####", culture);

                        if (tb.Text != formatted)
                        {
                            tb.Text = formatted;
                            int newLength = tb.Text.Length;
                            tb.SelectionStart = Math.Max(0, selectionStart + (newLength - originalLength));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Número inválido en la cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb.Text = "";
                }

                Calcular();

            }

           

            private void Text_Price_TextChange(object sender, EventArgs e)
            {
                TextBox tb = sender as TextBox;
                if (tb == null || string.IsNullOrWhiteSpace(tb.Text))
                    return;

                var culture = new CultureInfo("en-US");

                int selectionStart = tb.SelectionStart;
                int originalLength = tb.Text.Length;

                string clean = tb.Text.Replace(",", "");

                if (decimal.TryParse(clean, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, culture, out decimal value))
                {
                    if (!clean.EndsWith("."))
                    {
                        string formatted = value.ToString("#,##0.####", culture);

                        if (tb.Text != formatted)
                        {
                            tb.Text = formatted;
                            int newLength = tb.Text.Length;
                            tb.SelectionStart = Math.Max(0, selectionStart + (newLength - originalLength));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Número inválido en el precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb.Text = "";
                }

                Calcular();
            }


        private void Text_Cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void Text_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void Txt_Buscar_TextChange(object sender, EventArgs e)
        {
            string textoBusqueda = Txt_Buscar.Text.ToLower(); // Obtener el texto de búsqueda en minúsculas
            foreach (DataGridViewRow row in Dgv_Clientes.Rows)
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
                        Dgv_Clientes.CurrentCell = null; // Desseleccionar cualquier celda actualmente seleccionada
                        row.Visible = false; // Ocultar la fila si no coincide con la búsqueda
                    }
                }
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
            {
                using (ConsultClients consultarClientes = new ConsultClients())
                {
                    consultarClientes.inicioCuadro(1);
                    if (consultarClientes.ShowDialog() == DialogResult.OK)
                    {
                        Txt_Nombre.Text = consultarClientes.nombre;
                        Txt_Identificacion.Text = consultarClientes.identificacion;
                        Txt_Telefono.Text = consultarClientes.telefono;  
                    }
                    
                }
            }

            private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
            {

            }

            private void Btn_Agregar_Click(object sender, EventArgs e)
            {
                EstadoGuardar = 1; // Estado de Guardar
                if (Txt_Nombre.Text == String.Empty || Txt_Telefono.Text == string.Empty || Txt_Identificacion.Text == string.Empty)
                {
                    MessageBox.Show("Seleccione el cliente",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                #region "operaciones Guardar"
                string datas = Txt_Telefono.Text.Replace(" ", "");
                #endregion

                M_clientes oPro = new M_clientes();
                oPro.nombre = Txt_Nombre.Text.Trim();
                oPro.identificacion = int.Parse(Txt_Identificacion.Text);
                oPro.telefono = long.Parse(datas.Trim());

                if (Desplegable.Text == "Seleccionar")
                {
                    MessageBox.Show("Seleccione el Tipo de Café",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    oPro.tipo_cafe = Desplegable.SelectedItem.ToString();

                    if (string.IsNullOrWhiteSpace(Text_Price.Text))
                    {
                        MessageBox.Show("Debe poner el Precio del Café",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        var culture = new CultureInfo("en-US");

                        if (!decimal.TryParse(Text_Price.Text.Replace(",", ""), NumberStyles.Any, culture, out decimal precio))
                        {
                            MessageBox.Show("El precio ingresado no es válido.",
                                            "Error de formato",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return;
                        }

                        oPro.precio = precio;

                        if (string.IsNullOrWhiteSpace(Text_Cant.Text))
                        {
                            MessageBox.Show("Debe poner la Cantidad de Café",
                                            "Aviso del Sistema",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (!decimal.TryParse(Text_Cant.Text.Replace(",", ""), NumberStyles.Any, culture, out decimal cantidad))
                            {
                                MessageBox.Show("La cantidad ingresada no es válida.",
                                                "Error de formato",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                                return;
                            }

                            oPro.cantidad = cantidad;

                            oPro.total = decimal.Parse(Txt_Total.Text, NumberStyles.Number, culture);

                            Suma_Ok = 1;
                        }
                    }
                }

                
                    if (EstadoGuardar == 1)
                    {
                        oPro.fecha_proceso = DateTime.Now;
                    }
                    else
                    {
                        oPro.fecha_proceso = fecha;
                    }

                    if (Suma_Ok == 1)
                    {
                        string Rpta = "";
                        L_Proceso_Clientes Datos = new L_Proceso_Clientes();
                        Rpta = Datos.guarda_cliente(EstadoGuardar, oPro);
                        Limpia_texto();
                        if (Rpta.Equals("OK"))
                        {
                            this.listado_clientes("%");   // muestreme toda la informacion
                            EstadoGuardar = 0;
                            /*MessageBox.Show("Los Datos han sido Guardado Correctamente",
                                           "Aviso del Sistema",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);*/
                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }
                    
                        Suma_Ok = 0;
                    }
                }
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

                if (tip == string.Empty)
                {
                    Text_Cant.Enabled = false;
                    Text_Price.Enabled = false;
                    Text_Cant.PlaceholderText = "Escribe Cantidad en Kg";
                    Text_Price.PlaceholderText = "Escribe el Precio";

                }
            }
        }
    }