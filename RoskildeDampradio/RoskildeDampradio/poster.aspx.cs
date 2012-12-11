using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace RoskildeDampradio
{
    public partial class poster : System.Web.UI.Page
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

            Repeater_poster.DataSource = poster_dt();
            Repeater_poster.DataBind();
        }
        private DataTable poster_dt()
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM poster WHERE id = @id";

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}