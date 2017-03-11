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


namespace StuMIS.SCItem
{
    public partial class InsertSC : Form
    {
        SqlConnection conn;

        SqlCommand cmd;
  
        SqlDataAdapter sda;
        string sno;
        string cno;

        public InsertSC(string sno, string cno)
        {
            InitializeComponent();
            this.sno = sno;
            this.cno = cno;

            if (this.sno != "" && this.cno != "")
            {
                SC.StuGradeData data = new SC.StuGradeData();
                data.Sno = sno;
                data.Cno = cno;
                DataSet ds = SC.StuGradeOperation.getStuGrade(data);
                this.comboBox1.Text = sno;
                this.comboBox2.Text = cno;
                this.textBox1.Text = ds.Tables[0].Rows[0]["SCORE"].ToString();
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.Text = "修改成绩";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sno = this.comboBox1.Text;
            string cno = this.comboBox2.Text;
            string score = this.textBox1.Text;

            if (comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || textBox1.Text == "")
            {
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text.Trim() == null || comboBox2.Text.Trim() == null || textBox1.Text.Trim() == null)
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            SC.StuGradeData data = new SC.StuGradeData();
            data.Sno = sno;
            data.Cno = cno;
            data.SCORE = score;
            
            try
            {
                if (this.sno == "" || this.cno == "")
                {
                    if (SC.StuGradeOperation.insertStuGrade(data))
                    {
                        MessageBox.Show("添加成功", "提示");
                        this.textBox1.Text = "";
                        this.comboBox1.Text = "";
                        this.comboBox2.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("添加失败", "提示");
                    }
                }
                else
                {
                    if (SC.StuGradeOperation.updateStuGrade(data))
                    {
                        MessageBox.Show("修改成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show("修改失败", "错误");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("保存失败", "错误");
            }


            //string sql = "insert into SC(Sno,Cno,SCORE) values('" + comboBox1.Text + "','" + comboBox2.Text+ "',"+textBox1.Text+")";
            //DataAccess dataAccess = new DataAccess();
            //if(dataAccess.ExecuteSQL(sql))
            //{
            //    MessageBox.Show("添加成功!", "提示");
            //}else
            //{
            //    MessageBox.Show("添加失败!", "错误");
            //}
        }

        private void InsertSC_Load(object sender, EventArgs e)
        {
            if (this.sno != "" && this.cno != "")
                ;
            else
            {
                GetSnoInfo();
                GetCnoInfo();
            }
        }
        private void GetSnoInfo()
        {
            string connString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
            conn = new SqlConnection(connString);

            cmd = new SqlCommand();
            cmd.CommandText = "select * from Student";
            cmd.Connection = conn;
            sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Student");
            SqlDataReader sdr;
            conn.Open();
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            comboBox1.Items.Clear();
            while (sdr.Read())
            {
                comboBox1.Items.Add(sdr.GetValue(0));
            }
            sdr.Close();
            comboBox1.SelectedIndex = 0;


        }
        private void GetCnoInfo()
        {
            string connString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
            conn = new SqlConnection(connString);

            cmd = new SqlCommand();
            cmd.CommandText = "select * from Course";
            cmd.Connection = conn;
            sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Course");
            SqlDataReader sdr;
            conn.Open();
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            comboBox2.Items.Clear();
            while (sdr.Read())
            {
                comboBox2.Items.Add(sdr.GetValue(0));
            }
            sdr.Close();
            comboBox2.SelectedIndex = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }
    }
}
