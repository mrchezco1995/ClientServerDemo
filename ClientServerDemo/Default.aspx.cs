using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;
using ClientServerDemo;

namespace ClientServerDemo
{
    public partial class _Default : Page
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;

        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["AppConnString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string query = "select `firstname`, `lastname`, `message`, `timeposted` from clientserverdemo.messages order by `timeposted` desc";

            try
            {

                conn = new MySqlConnection(connstring);
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {

                    //System.Diagnostics.Debug.WriteLine("There's no messages on the DB just yet");
                }
                else
                {
                    StringBuilder messagebuilder = new StringBuilder();
                    while(reader.HasRows && reader.Read())
                    {
                        messagebuilder.Append("<h3>" + reader.GetString(0) + " " + reader.GetString(1) + "</h3>  " + reader.GetString(3) + "<br /><br />");
                        messagebuilder.Append("<p>" + reader.GetString(2) + "</p><br /><br />");
                    }

                    litMessages.Text = messagebuilder.ToString();
                    conn.Close();
                }

            }
            catch(SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine("There's a problem with MySQL. Cannot populate data. Error details:" + ex.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string query = "insert into messages (`firstname`, `lastname`, `message`) values ('" + sqlescape.MySqlEscape(txtFirstName.Text.Trim()) + "', '" + sqlescape.MySqlEscape(txtLastName.Text.Trim()) + "', '" + sqlescape.MySqlEscape(txtMessage.Text.Trim()) + "')";

            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine("There's a problem with MySQL. Cannot write data. Error details:" + ex.Message);
            }

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMessage.Text = "";

            Response.Redirect(Request.RawUrl);

        }
    }
}