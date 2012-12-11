using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RoskildeDampradio
{
    public partial class sider : System.Web.UI.Page
    {
        SqlConnection Conn;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            Repeater_sider.DataSource = program_oversigt_sider();
            Repeater_sider.DataBind();
        }
        private DataTable program_oversigt_sider()
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM sider WHERE id = @id";

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}