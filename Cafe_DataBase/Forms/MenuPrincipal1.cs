using Cafe_DataBase.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_DataBase
{
    public partial class MenuPrincipal1 : Form
    {
        
        //TotalProductos totalProductos;
        Clientes Clientes;
        RegistrarClientes RegClient;


        public MenuPrincipal1()
        {
            InitializeComponent();
            customizeDesign();
            RegClient = new RegistrarClientes();
            Clientes = new Clientes(); 
            //totalProductos = new TotalProductos();

            

        }

        private const int tamañogrid = 10;
        private const int areamouse = 132;
        private const int botonizquierdo = 17;
        private Rectangle rectangulogrid;

        private void customizeDesign()
        {
            sub_menu.Visible = false;
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



        int ss;

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            
                Application.Exit();
            
        }

        private void Btn_minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Reg_CLient_Click(object sender, EventArgs e)
        {
            RegClient.ShowDialog();
        }

        private void Clients_Click(object sender, EventArgs e)
        {
            Clientes.ShowDialog();
        }

        private void Cant_product_Click(object sender, EventArgs e)
        {
            showSubMenu(sub_menu);
        }

        private void cafe_verde_Click(object sender, EventArgs e)
        {
            //...
            //Code
            //..
            hideSubMenu();
        }

        private void cafe_seco_Click(object sender, EventArgs e)
        {
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
            //totalProductos.ShowDialog();
        }

        
        
    }
}
