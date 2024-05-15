using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_OprationSP_Con
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DEESHRI;Initial Catalog=CRUD_SP_DB;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string status = "";
            if (radioButton1.Checked == true)
            {
                status = radioButton1.Text;
            }
            else
            {
                status = radioButton2.Text;
            }
            SqlCommand com = new SqlCommand("exec dbo.SP_Product_Insert'" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + status + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sucessfully saved");
            LoadRecords();
        }
        void LoadRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.SP_Product_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string status = "";
            if (radioButton1.Checked == true)
            {
                status = radioButton1.Text;
            }
            else
            {
                status = radioButton2.Text;
            }
            SqlCommand com = new SqlCommand("exec dbo.SP_Product_Update'" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + status + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sucessfully updated");
            LoadRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (MessageBox.Show("Are you confirm to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand com = new SqlCommand("exec dbo.SP_Product_Delete'" + int.Parse(textBox1.Text) + "' ", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sucessfully deleted");
                LoadRecords();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("exec dbo.SP_Product_search'"+int.Parse(textBox1.Text)+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
