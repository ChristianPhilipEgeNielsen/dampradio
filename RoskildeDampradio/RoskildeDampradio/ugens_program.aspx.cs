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
    public partial class ugens_program : System.Web.UI.Page
    {
        SqlConnection Conn;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            while(dt.DayOfWeek != DayOfWeek.Monday) dt = dt.AddDays(-1);

            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            Label_program_dag.Text = dt.ToShortDateString() + " - ";
            Label_program_sidste_dag.Text = dt.AddDays(6).ToShortDateString();

            Repeater_program_dag.DataSource = program_dag(dt, dt.AddDays(6));
            Repeater_program_dag.DataBind();
            Calendar_program.SelectionMode = CalendarSelectionMode.DayWeek;
        }
        protected void Calendar_program_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = Calendar_program.SelectedDate;
            while (dt.DayOfWeek != DayOfWeek.Monday) dt = dt.AddDays(-1);

            Label_program_dag.Text = dt.ToShortDateString() + " - ";
            Label_program_sidste_dag.Text = dt.AddDays(6).ToShortDateString();
            Repeater_program_dag.DataSource = program_dag(dt, dt.AddDays(6));
            Repeater_program_dag.DataBind();
        }
        private DataTable program_dag(DateTime start_dag, DateTime slut_dag)
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

                                WHERE tidsplan_for_programer.dag BETWEEN @start_dag AND @slut_dag 
                                ORDER BY  tidsplan_for_programer.start";

            //cmd.Parameters.AddWithValue("@dag", dag);
            cmd.Parameters.Add("@start_dag", SqlDbType.DateTime).Value = start_dag.ToShortDateString();
            cmd.Parameters.Add("@slut_dag", SqlDbType.DateTime).Value = slut_dag.ToShortDateString();

            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}