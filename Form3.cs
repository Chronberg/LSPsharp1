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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        string connectionString = "server=localhost; database=library; user=root; Character Set=utf8";

        private void bindGrid()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                dataGridView2.AutoGenerateColumns = false;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT reader.FIO, reader.number, reader.address, reader.workplace FROM reader INNER JOIN outbook ON reader.id_reader = outbook.id_reader WHERE (DATEDIFF(outbook.date_return, outbook.fact_return) < 0)", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tbl2");
                dataGridView2.DataSource = ds.Tables["tbl2"];
                this.dataGridView2.Columns[0].Width = 150;
                this.dataGridView2.Columns[0].HeaderText="ФИО";
                this.dataGridView2.Columns[1].HeaderText = "Телефонный номер";
                this.dataGridView2.Columns[2].HeaderText = "Адрес";
                this.dataGridView2.Columns[3].HeaderText = "Место работы";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT reader.FIO, reader.number, reader.address, reader.workplace FROM reader INNER JOIN outbook ON reader.id_reader = outbook.id_reader WHERE outbook.fact_return = 0000-00-00", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tbl3");
                dataGridView2.DataSource = ds.Tables["tbl3"];
                this.dataGridView2.Columns[0].Width = 150;
                this.dataGridView2.Columns[0].HeaderText = "ФИО";
                this.dataGridView2.Columns[1].HeaderText = "Телефонный номер";
                this.dataGridView2.Columns[2].HeaderText = "Адрес";
                this.dataGridView2.Columns[3].HeaderText = "Место работы";
            }
        }

        private void btn_quick_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string buff = "";
                if(textBox2.Text.Trim() == "Номер" || textBox2.Text.Trim() == "Номер телефона" || textBox2.Text.Trim() == "Телефонный номер")
                {
                    buff = "Number";
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT " + buff + " FROM reader WHERE FIO='" + textBox1.Text.Trim() + "'", con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "tbl4");
                    dataGridView2.DataSource = ds.Tables["tbl4"];
                    this.dataGridView2.Columns[0].HeaderText = "Телефонный номер";

                }
                else if (textBox2.Text.Trim() == "Адрес" || textBox2.Text.Trim() == "Домашний дрес")
                {
                    buff = "Address";
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT " + buff + " FROM reader WHERE FIO='" + textBox1.Text.Trim() + "'", con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "tbl4");
                    dataGridView2.DataSource = ds.Tables["tbl4"];
                    this.dataGridView2.Columns[0].HeaderText = "Адрес";
                }
                else if (textBox2.Text.Trim() == "Работа" || textBox2.Text.Trim() == "Место работы")
                {
                    buff = "Workplace";
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT " + buff + " FROM reader WHERE FIO='" + textBox1.Text.Trim() + "'", con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "tbl4");
                    dataGridView2.DataSource = ds.Tables["tbl4"];
                    this.dataGridView2.Columns[0].HeaderText = "Место работы";
                }
                else
                {
                    MessageBox.Show("Указана неверная информация");
                }
                
                
                
            }
        }
    }

}
