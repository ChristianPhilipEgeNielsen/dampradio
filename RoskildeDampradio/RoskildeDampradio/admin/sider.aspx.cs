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
    public partial class sider : System.Web.UI.Page
    {
        SqlConnection Conn;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        SqlDataAdapter kategori;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            kategori = new SqlDataAdapter("SELECT * FROM kategori", Conn);
            DataSet datamenu = new DataSet();
            kategori.Fill(datamenu, "data");
            DropDownList_kategori.Items.Add(new ListItem("Vælg kategori", " "));
            foreach (DataRow row in datamenu.Tables["data"].Rows)
            {
                DropDownList_kategori.Items.Add(new ListItem(row["type"].ToString(), row["id"].ToString()));
            }

            Repeater_sider.DataSource = sider_dt();
            Repeater_sider.DataBind();
        }
        private DataTable sider_dt()
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT id, overskrift FROM poster WHERE kategori_id = 3";

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        private DataTable sider_dt_ret()
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT id, overskrift FROM poster WHERE kategori_id = 3";

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        protected void Repeater_sider_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString(); // trækker id ud af menu som skal rettes
            int boxid = int.Parse(id); // laver string om til en integer

            if (e.CommandName == "ret")
            {
                
            }

            //TextBox MyTextBox = (TextBox)e.Item.FindControl("Text_ret_produkt_info");

            // finder aktuel textbox

            //string boxText = MyTextBox.Text.ToString(); // hent teksten fra den rettede textbox

            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE forside SET overskrift=@Value1, info=@Value2 WHERE id=@id";

            //cmd.Parameters.AddWithValue("@Value1", boxText);
            cmd.Parameters.AddWithValue("@id", id);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

            Response.Redirect(Request.RawUrl);
        }
    }
}