using MySql.Data.MySqlClient;
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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        public static bool isOpened = false;

        public void getData()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=password;database=users";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string query = "select * from users.user";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteData()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=password;database=users";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id"].Value);
                    string query = "delete from users.user where id='" + id + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Data Deleted", "Successfully!");
                    while (reader.Read())
                    {
                    }
                    conn.Close();
                    getData();
                }
                else
                {
                    MessageBox.Show("Please select a row first!", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!isOpened)
            {
                create form = new create();
                form.Show();
                isOpened = true;
            }
            getData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
