using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace db_connectivity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-NCEDVHBS;Initial Catalog=c_sharpdb;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into info values(@uname , @reg_date, @iname, @quant , @price,@p_type) ", con);
                cmd.Parameters.AddWithValue("@uname", txt_uname.Text);
                cmd.Parameters.AddWithValue("@reg_date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@iname", txt_Item.Text);
                cmd.Parameters.AddWithValue("@quant", int.Parse(txt_Quantity.Text));
                cmd.Parameters.AddWithValue("@price", float.Parse(txt_Price.Text));
                if (simple_rb.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@p_type", simple_rb.Text);
                }
                else if (rb_variable.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@p_type", rb_variable.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_type", "Unknown");
                }
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New item inserted");
            }
            catch (Exception)
            {
                MessageBox.Show("connection not established!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-NCEDVHBS;Initial Catalog=c_sharpdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from info",  con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-NCEDVHBS;Initial Catalog=c_sharpdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = 
                new SqlCommand("update info set uname= @uname,reg_date= @reg_date, iname = @iname, quant = @quant, price = @price, p_type = @p_type where iname = @iname ", con);
            cmd.Parameters.AddWithValue("@uname", txt_uname.Text);
            cmd.Parameters.AddWithValue("@reg_date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@iname", txt_Item.Text);
            cmd.Parameters.AddWithValue("@quant", int.Parse(txt_Quantity.Text));
            cmd.Parameters.AddWithValue("@price", float.Parse(txt_Price.Text));
            if (simple_rb.Checked == true)
            {
                cmd.Parameters.AddWithValue("@p_type", simple_rb.Text);
            }
            else if (rb_variable.Checked == true)
            {
                cmd.Parameters.AddWithValue("@p_type", rb_variable.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@p_type", "Unknown");
            }
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Item Updated");
        }
    }
}