using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data.OleDb;
using System.Data;

public static class Conexiones
{
    public static OleDbConnection Conexion;

    public static void ABrirCOnexion()
    {
        Conexion = new OleDbConnection();
        Conexion.ConnectionString = "Provider=Microsoft.ACE.Oledb.16.0;Data Source=DataAcess/basedatos.accdb;";
        Conexion.Open();
    }


    public static int RegistroPersonas(int IDPersona)
    {
        int Entradas = 0;
        int Salidas = 0;

        OleDbDataAdapter da = new OleDbDataAdapter("select IIF(SUM(CANTIDAD) IS NULL,0,SUM(CANTIDAD)) AS CANTIDAD from entrada_productos where ID_PRODUCTO=" + IDPersona, Conexion);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
            Entradas = Convert.ToInt32(ds.Tables[0].Rows[0]["CANTIDAD"]);

        da = new OleDbDataAdapter("select IIF(SUM(CANTIDAD) IS NULL,0,SUM(CANTIDAD)) AS CANTIDAD from salida_productos where ID_PRODUCTO=" + IDPersona, Conexion);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
            Salidas = Convert.ToInt32(ds.Tables[0].Rows[0]["CANTIDAD"]);

        return Entradas - Salidas;
    }
}
