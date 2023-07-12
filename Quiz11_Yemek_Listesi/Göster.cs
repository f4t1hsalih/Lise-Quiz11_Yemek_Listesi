using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Quiz11_Yemek_Listesi
{
    public partial class Göster : Form
    {
        public Göster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection cnn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + @"\\Data.accdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();

            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM Kayıt WHERE Tarih=@Tarih";
            cmd.Parameters.Add("@Tarih", OleDbType.VarChar).Value = dateTimePicker1.Text;

            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Göster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
