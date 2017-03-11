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
    public partial class TCQuery : Form
    {
        DataSet ds = new DataSet();
        public TCQuery(string flag)
        {
            InitializeComponent();


            if (flag == "Update")
            {
                this.button2.Visible = true;
            }
            else if (flag == "Delete")
            {
                this.button3.Visible = true;
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            string Tno = this.TnoText.Text.Trim();
            string Cno = this.CnoText.Text.Trim();

            if (Tno == "" && Cno == "")
            {
                MessageBox.Show("教师号和课程号不能同时为空！请输入要查询条件", "提示");
                return;
            }
            else
            {

                TC.TCInfoData data = new TC.TCInfoData();

                data.Tno = Tno;
                data.Cno = Cno;

                try
                {
                    ds = TC.TCInfoOperation.getTCInfo(data);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
               
                //SqlConnection conn = new SqlConnection();
                //DataSet ds = new DataSet("MIS2");
                //conn.ConnectionString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
                //conn.Open();
                //SqlCommand cmd = new SqlCommand();
                //if (Tno == "")          
                //    cmd.CommandText = "select Teacher.Tname '教师姓名',Course.Cname '课程名',Teacher.Sal '薪水',Teacher.Age '年龄', Teacher.Prof '职称' ,Teacher.Dept '所教专业' from TC, Teacher, Course where TC.Cno = Course.Cno AND TC.Tno = Teacher.Tno AND TC.Cno = '" + Cno + "'";
                //else if (Cno == "")
                //    cmd.CommandText = "select Teacher.Tname '教师姓名',Course.Cname '课程名',Teacher.Sal '薪水',Teacher.Age '年龄', Teacher.Prof '职称' ,Teacher.Dept '所教专业' from TC, Teacher, Course where TC.Cno = Course.Cno AND TC.Tno = Teacher.Tno AND TC.Tno = '" + Tno + "'";
                //else
                //    cmd.CommandText = "select Teacher.Tname '教师姓名',Course.Cname '课程名',Teacher.Sal '薪水',Teacher.Age '年龄', Teacher.Prof '职称' ,Teacher.Dept '所教专业' from TC, Teacher, Course where TC.Cno = Course.Cno AND TC.Tno = Teacher.Tno AND TC.Tno = '" + Tno + "' AND TC.Cno='" + Cno + "'";
                //cmd.Connection = conn;
                //SqlDataAdapter sda = new SqlDataAdapter();
                //sda.SelectCommand = cmd;
                //SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                //sda.Fill(ds, "TC");
                //dataGridView1.DataSource = ds.Tables["TC"];
                //if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)
                //    MessageBox.Show("抱歉！找不到相关记录！没有满足条件的记录，请确认查询条件", "提示");
                //conn.Close();

            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TCQuery_Load(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            string sql1 = "select * from TC";
            ds = dataAccess.GetDataSet(sql1, "TC");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            if (index < 0)
            {
                MessageBox.Show("请选择要修改的记录！", "提示");
                return;
            }
            else
            {
                string tno = ds.Tables[0].Rows[index]["教师号"].ToString();
                string cno = ds.Tables[0].Rows[index]["课程号"].ToString();
                TCItem.InsertTC f = new TCItem.InsertTC(tno, cno);
                f.ShowDialog();
                TCQuery_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            if (index < 0)
            {
                MessageBox.Show("请选择要删除的记录", "提示");
                return;
            }
            else
            {
                if (MessageBox.Show("确定要删除吗？", "删除后无法撤回", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string tno = ds.Tables[0].Rows[index]["教师号"].ToString();
                    string cno = ds.Tables[0].Rows[index]["课程号"].ToString();
                    try
                    {
                        if (TC.TCInfoOperation.deleteTCInfo(tno, cno))
                        {
                            MessageBox.Show("删除成功!", "提示");
                            //binddatagrid
                            string Tno = this.TnoText.Text.Trim();
                            string Cno = this.CnoText.Text.Trim();
                            TC.TCInfoData data = new TC.TCInfoData();
                            data.Tno = Tno;
                            data.Cno = Cno;

                            try
                            {
                                ds = TC.TCInfoOperation.getTCInfo(data);
                                this.dataGridView1.DataSource = ds.Tables[0];
                            }
                            catch (Exception ex)
                            {
                                ex.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "错误");
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        MessageBox.Show("删除失败", "错误");
                    }
                    finally
                    {
                        TCQuery_Load(sender, e);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCQuery_Load(sender, e);   
        }
    }
}
