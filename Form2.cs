using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LSPsharp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }
        
        string connectionString = "server=localhost; database=library; user=root; Character Set=utf8";

        private void Form2_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void bindGrid()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                dataGridView1.AutoGenerateColumns = false;
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM reader", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tbl");
                dataGridView1.DataSource = ds.Tables["tbl"];
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                int res;
                if (txtfio.Text.Trim() != string.Empty && txtnum.Text.Trim() != string.Empty && txtaddress.Text.Trim() != string.Empty && txtwork.Text.Trim() != string.Empty)
                {

                    if (!Int32.TryParse(txtnum.Text.Trim(), out res) && !Int32.TryParse(txtaddress.Text.Trim(), out res) || Int32.TryParse(txtfio.Text.Trim(), out res) || Int32.TryParse(txtwork.Text.Trim(), out res))
                    {
                        MessageBox.Show("Неверно заполнены поля");
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO reader(FIO, Number, Address, Workplace) VALUES ('" + txtfio.Text.Trim() + "', '" + txtnum.Text.Trim() + "', '" + txtaddress.Text.Trim() + "', '" + txtwork.Text.Trim() + "')", con);
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("Добавлено");
                            bindGrid();
                        }
                        else
                        {
                            MessageBox.Show("Возникла ошибка");
                        }
                        
                    }
                                        
                }
                
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM reader WHERE id_reader=" + txtid.Text.Trim(), con);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Удалено");
                        bindGrid();
                    }
                    else
                    {
                        MessageBox.Show("Возникла ошибка");
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtfio.Text = "";
            txtnum.Text = "";
            txtaddress.Text = "";
            txtwork.Text = "";
        }
    }
}
