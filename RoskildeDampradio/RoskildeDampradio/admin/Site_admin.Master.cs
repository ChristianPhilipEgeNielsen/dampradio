using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace RoskildeDampradio.admin
{
    public partial class Site_admin : System.Web.UI.MasterPage
    {
        SqlConnection Conn;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            Repeater_menu.DataSource = admin_menu();
            Repeater_menu.DataBind();
        }
        private DataTable admin_menu()
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT * FROM admin_menu ORDER BY  position";

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}