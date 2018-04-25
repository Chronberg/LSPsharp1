using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LSPsharp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database=library; user=root");
        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                connectLabel.Text = "Подключение к ДБ успешно";
            }
            else
            {
                connectLabel.Text = "Подключение к ДБ не удалось";
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            Hide();
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            Hide();
        }
    }
}
