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

namespace StuMIS.TCItem
{
    public partial class InsertTC : Form
    {
        SqlConnection conn;

        SqlCommand cmd;

        SqlDataAdapter sda;
        string tno;
        string cno;
        string new_tno = "";
        string new_cno = "";
        TC.TCInfoData data = new TC.TCInfoData();

        public InsertTC(string tno, string cno)
        {

            InitializeComponent();
            //要修改的tno,cno
            this.tno = tno;
            this.cno = cno;

            if (this.tno == "" && this.cno == "")
                this.Text = "添加教学信息";
            else
            {
                data.Tno = tno;
                data.Cno = cno;
                //DataSet ds = TC.TCInfoOperation.getTCInfo(data);
                comboBox1.Text = this.tno;
                comboBox2.Text = this.cno;

                this.Text = "修改教学信息";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string str;
            new_tno = this.comboBox1.Text;
            new_cno = this.comboBox2.Text;

            if (comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text.Trim() == null || comboBox2.Text.Trim() == null)
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);


            try
            {
                if (this.tno == "" && this.cno == "")
                {


                    data.Cno = this.new_cno;
                    data.Tno = this.new_tno;
                    if (TC.TCInfoOperation.insertTCInfo(data))
                    {
                        MessageBox.Show("添加成功", "提示");

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

                    data.Tno = this.tno;
                    data.Cno = this.cno;
                    data.New_cno = this.new_cno;
                    data.New_tno = this.new_tno;
                   // str = data.Tno + " " + data.Cno + " " + data.New_cno + " " + data.New_tno;
                    if (TC.TCInfoOperation.updateTCInfo(data))
                    {
                        MessageBox.Show("修改成功", "提示");
                       // MessageBox.Show(str, "提示");
                    }
                    else
                    {
                        MessageBox.Show("修改失败", "错误");
                       // MessageBox.Show(str, "提示");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("保存失败", "错误");
            }
        }

        private void InsertTC_Load(object sender, EventArgs e)
        {

            GetTnoInfo();
            GetCnoInfo();
        }
        private void GetTnoInfo()
        {
            string connString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
            conn = new SqlConnection(connString);

            cmd = new SqlCommand();
            cmd.CommandText = "select * from Teacher";
            cmd.Connection = conn;
            sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Teacher");
            SqlDataReader sdr;
            conn.Open();
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            comboBox1.Items.Clear();
            while (sdr.Read())
            {
                comboBox1.Items.Add(sdr.GetValue(0));
            }
            sdr.Close();



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

        }
    }
}
