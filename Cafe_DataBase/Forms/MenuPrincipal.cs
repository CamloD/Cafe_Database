using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_DataBase.Forms
{
    public partial class MenuPrincipal : Form
    {
        Totalcafe totalProductos;
        Clientes Clientes;
        RegistrarClientes RegClient;


        public MenuPrincipal()
        {
            InitializeComponent();
            customizeDesign();
            AdjustForm();

            RegClient = new RegistrarClientes();
            Clientes = new Clientes();
            totalProductos = new Totalcafe();

            this.BackColor = Color.FromArgb(23, 32, 42);
            this.Padding = new Padding(BorderSize);

            /*
            this.Text = null;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = (Screen.FromHandle(this.Handle).WorkingArea);
            */
        }

        #region "Variables"
        private int BorderSize = 0;
        private Size formSize;
        //private Size sizess;

        #endregion

        #region "procesos"


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void customizeDesign()
        {
            sub_menu.Visible = false;
            AbrirFormH1(new Home());
        }
        private void hideSubMenu()
        {
            if (sub_menu.Visible == true)
            {
                sub_menu.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    Btn_Normal.Visible = true;
                    Btn_Maximizar.Visible = false;
                    break;
                case FormWindowState.Normal: //Restored form (After)

                    Btn_Maximizar.Visible = true;
                    Btn_Normal.Visible = false;
                    break;
            }
        }

        internal void AbrirFormH1(object formH1)
        {
            if (this.panel_centro.Controls.Count > 0)
            {
                this.panel_centro.Controls.RemoveAt(0);
            }
            Form fh = formH1 as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_centro.Controls.Add(fh);
            this.panel_centro.Tag = fh;
            fh.Show();
        }
        #endregion //_____________________________________________________________________________________________

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* if (MessageBox.Show("Quieres salir de la Aplicación?", "Cerrar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            { e.Cancel = true; }*/
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Btn_minimizar_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }


        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
                Btn_Maximizar.Visible = false;
                Btn_Normal.Visible = true;
            }
        }
        private void Btn_Normal_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
                Btn_Normal.Visible = false;
                Btn_Maximizar.Visible = true;
            }
        }

        private void House_button_Click(object sender, EventArgs e)
        {
            AbrirFormH1(new Home());
        }

        private void Reg_CLient_Click(object sender, EventArgs e)
        {
            AbrirFormH1(new RegistrarClientes());
            //RegClient.ShowDialog();
        }

        private void Clients_Click(object sender, EventArgs e)
        {
            AbrirFormH1(new Clientes());
            //Clientes.Show();
            //Clientes.ShowDialog();
        }

        private void Cant_product_Click(object sender, EventArgs e)
        {
            showSubMenu(sub_menu);
        }

        private void cafe_verde_Click(object sender, EventArgs e)
        {
    
            //...
            //AbrirFormH1(new Form1());
            //..
            hideSubMenu();
        }

        private void cafe_seco_Click(object sender, EventArgs e)
        {
        
            //...
            //AbrirFormH1(new Form1());
            //...
            //Code
            //..
            hideSubMenu();
        }

        private void cafe_pasilla_Click(object sender, EventArgs e)
        {
            //...
            //Code
            //..
            hideSubMenu();
        }

        private void Total_cafe_Click(object sender, EventArgs e)
        {
            AbrirFormH1(new Totalcafe());
            //totalProductos.ShowDialog();
        }

        private void panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void WindowState_StyleChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 8);
                    Btn_Normal.Visible = true;
                    Btn_Maximizar.Visible = false;
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != BorderSize)
                        this.Padding = new Padding(BorderSize);
                    Btn_Maximizar.Visible = true;
                    Btn_Normal.Visible = false;
                    break;
            }
        }

        private void Cant_Hover(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToString("T");
            Fecha.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
        }
    }
}
