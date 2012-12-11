using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace RoskildeDampradio
{
    public partial class program_oversigt : System.Web.UI.Page
    {
        SqlConnection Conn;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        string info;

        protected void Page_Load(object sender, EventArgs e)
        {
            info = Request.QueryString["id"];
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            Repeater_genre_kategori.DataSource = program_oversigt_dt(0);
            Repeater_genre_kategori.DataBind();
            Repeater_info.DataSource = program_oversigt_info();
            Repeater_info.DataBind();
            Repeater_titel.DataSource = program_oversigt_titel();
            Repeater_titel.DataBind();
        }
        private DataTable program_oversigt_dt(int parent)
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT        
                                    genre.id
                                    , genre.navn
                                    , genre_struktur.id
                                    , genre_struktur.genre_id
                                    , genre_struktur.parent
                                FROM
                                    genre INNER JOIN
                                    genre_struktur ON genre.id = genre_struktur.genre_id
                                WHERE genre_struktur.parent = @parent";

            cmd.Parameters.Add("@parent", SqlDbType.Int).Value = parent;
            
            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public void Repeater_genre_Item_Data_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                sub_genre(e, "Repeater_genre");
            }
        }
        public void Repeater_genre_program_Item_Data_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                sub_genre(e, "Repeater_genre_program");
            }
        }
        private void sub_genre(RepeaterItemEventArgs e, string repeater)
        {
            DataRowView row = e.Item.DataItem as DataRowView;
            DataTable sub_genre_dt = program_oversigt_dt((int)row[0]);
            if(sub_genre_dt.Rows.Count > 0)
            {
                Repeater rep_sub_genre = e.Item.FindControl(repeater) as Repeater;
                rep_sub_genre.DataSource = sub_genre_dt;
                rep_sub_genre.DataBind();
            }
        }
        private DataTable program_oversigt_info()
        {
            if (Request.QueryString["id"] != null)
            {
                cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT        
                                        id
                                        , navn
                                        , beskrivelse
                                    FROM
                                        genre
                                    WHERE id = @info";

                cmd.Parameters.Add("@info", SqlDbType.Int).Value = info;

                dt = new DataTable();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        private DataTable program_oversigt_titel()
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT overskrift FROM poster WHERE id = 15";

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}