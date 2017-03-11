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

namespace StuMIS
{
    public partial class AllTable : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataSet ds = new DataSet("MIS");

        public AllTable()
        {
            InitializeComponent();
        }

        private void AllTable_Load(object sender, EventArgs e)
        {
            string connString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
            conn = new SqlConnection(connString);
            conn.Open();

            da = new SqlDataAdapter("select * from Student", connString);
            da.Fill(ds, "Student");
            da = new SqlDataAdapter("select * from Teacher", connString);
            da.Fill(ds, "Teacher");
            da = new SqlDataAdapter("select * from Course", connString);
            da.Fill(ds, "Course");
            da = new SqlDataAdapter(" select * from SC", connString);
            da.Fill(ds, "SC");
            da = new SqlDataAdapter("select * from TC", connString);
            da.Fill(ds, "TC");

            for (int i = 0; i < ds.Tables.Count; i++)
                comboBox1.Items.Add(ds.Tables[i].TableName);
            comboBox1.Text = ds.Tables[0].TableName;
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ds.Tables[comboBox1.Text];
        }
    }
}
