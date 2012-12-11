using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoskildeDampradio
{
    public partial class program : System.Web.UI.Page
    {
        SqlConnection Conn;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            Label_program_dag.Text = DateTime.Now.Date.ToShortDateString();
            
            Repeater_program_dag.DataSource = program_dag(DateTime.Now.Date);
            Repeater_program_dag.DataBind();
        }

        protected void Calendar_program_SelectionChanged(object sender, EventArgs e)
        {
            Label_program_dag.Text = Calendar_program.SelectedDate.ToShortDateString();

            Repeater_program_dag.DataSource = program_dag(Calendar_program.SelectedDate);
            Repeater_program_dag.DataBind();
        }
        private DataTable program_dag(DateTime dag)
        {
            cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT        
                                    program_genre.*
                                    , tidsplan_for_programer.*
                                    , program_oversigt.*
                                    , genre.*
                                FROM
                                    genre INNER JOIN program_genre 
                                    ON genre.id = program_genre.genre_id 
                                    INNER JOIN program_oversigt ON 
                                    program_genre.program_oversigt_id = program_oversigt.id 
                                    INNER JOIN tidsplan_for_programer ON 
                                    program_oversigt.id = tidsplan_for_programer.program_oversigt_id

                                WHERE dag = @dag 
                                ORDER BY  tidsplan_for_programer.start";

            //cmd.Parameters.AddWithValue("@dag", dag);
            cmd.Parameters.Add("@dag", SqlDbType.DateTime).Value = dag.ToShortDateString();

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}