using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Quiz11_Yemek_Listesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Data.accdb");

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Data.accdb");
            OleDbCommand cmd = new OleDbCommand("select * from Yemekler", cnn);
            OleDbDataReader dr;
            cnn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Anayemek"].ToString());
                comboBox2.Items.Add(dr["Yardimciyemek1"].ToString());
                comboBox3.Items.Add(dr["Yardimciyemek2"].ToString());
                comboBox4.Items.Add(dr["Tamamlayiciyemek"].ToString());
            }
            cnn.Close();

            //OleDbCommand cmd = new OleDbCommand("select Anayemek,Anayemekcal from Yemekler", conn);
            //conn.Open();
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //comboBox1.DataSource = dt;
            //comboBox1.DisplayMember = "Anayemek";
            //comboBox1.ValueMember = "Anayemekcal";

            //OleDbCommand cmd1 = new OleDbCommand("select Yardimciyemek1,Yardimciyemek1cal from Yemekler", conn);
            //DataTable dt1 = new DataTable();
            //dt1.Load(cmd.ExecuteReader());
            //comboBox2.DataSource = dt1;
            //comboBox2.DisplayMember = "Yardimciyemek1";
            //comboBox2.ValueMember = "Yardimciyemek1cal";

            //OleDbCommand cmd2 = new OleDbCommand("select Yardimciyemek2cal,Yardimciyemek2 from Yemekler", conn);
            //DataTable dt2 = new DataTable();
            //dt2.Load(cmd.ExecuteReader());
            //comboBox3.DataSource = dt2;
            //comboBox3.DisplayMember = "Yardımcıyemek2";
            //comboBox3.ValueMember = "Yardimciyemek2cal";


            //OleDbCommand cmd3 = new OleDbCommand("select Tamamlayiciyemekcal,Tamamlayiciyemek from Yemekler", conn);
            //DataTable dt3 = new DataTable();
            //dt3.Load(cmd.ExecuteReader());
            //comboBox4.DataSource = dt3;
            //comboBox4.DisplayMember = "Tamamlayiciyemek";
            //comboBox4.ValueMember = "Tamamlayiciyemekcal";

            //conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Data.accdb");

            OleDbCommand komut = new OleDbCommand();
            komut.CommandText = "INSERT INTO Kayıt(Tarih,Anayemek,Yardimciyemek1,Yardimciyemek2,Tamamlayiciyemek) values (@Tarih,@Anayemek,@Yardimciyemek1,@Yardimciyemek2,@Tamamlayiciyemek)";
            komut.Parameters.Add("@Tarih", OleDbType.VarChar).Value = dateTimePicker1.Text;
            komut.Parameters.Add("@Anayemek", OleDbType.VarChar).Value = comboBox1.Text;
            komut.Parameters.Add("@Yardimciyemek1", OleDbType.VarChar).Value = comboBox2.Text;
            komut.Parameters.Add("@Yardimciyemek2", OleDbType.VarChar).Value = comboBox3.Text;
            komut.Parameters.Add("@Tamamlayiciyemek", OleDbType.VarChar).Value = comboBox4.Text;

            komut.Connection = bağlantı;
            bağlantı.Open();
            komut.ExecuteNonQuery();
            bağlantı.Close();

            MessageBox.Show("Kaydınınz Başarıyla Gerçekleştirildi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            Göster göster = new Göster();
            frm.Close();
            göster.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
