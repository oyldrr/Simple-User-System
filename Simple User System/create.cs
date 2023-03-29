using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_User_System
{
    public partial class create : Form
    {
        main mainRef;
        public create()
        {
            InitializeComponent();
        }

        public void createData()
        {
            string fullname = txtFullname.Text;
            string phone = txtPhone.Text;
            string department = txtDepartment.Text;
            string title = txtTitle.Text;
            string salary = txtSalary.Text;
  
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=password;database=users";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                string query = "INSERT INTO `users`.`user` (`fullname`, `phone`, `department`, `title`, `salary`) VALUES('"+ fullname +"', '"+ phone + "', '"+ department +"', '"+ title + "', '"+ salary +"')";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Data created", "Successfully!");
                while (reader.Read())
                {
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void create_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.isOpened = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            createData();
            this.Close();
        }
    }
}
