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
    public partial class SCQuery : Form
    {
        StringBuilder sb = new StringBuilder();
        DataSet ds = new DataSet();

        public SCQuery(string flag)
        {
            InitializeComponent();
            if (User.Constants.UserRight == "学生")
            {
                //判断用户是学生
                this.SnoText.Text = User.Constants.UserName;
                this.SnoText.Enabled = false;
            }
            if (flag == "Update")
            {
                this.button2.Visible = true;
            }
            else if (flag == "Delete")
            {
                this.button3.Visible = true;
            }
        }

        private void SCQuery_Load(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            string sql1 = "select * from SC";
            ds = dataAccess.GetDataSet(sql1, "SC");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string Sno = this.SnoText.Text.Trim();
            string Cno = this.CnoText.Text.Trim();
            SC.StuGradeData data = new SC.StuGradeData();

            data.Sno = Sno;
            data.Cno = Cno;

            try
            {
                ds = SC.StuGradeOperation.getStuGrade(data);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


            //if (Sno == "" && Cno== "")
            //{
            //    MessageBox.Show("课程号和学号不能同时为空！请输入要查询条件", "提示");
            //}
            //else
            //{
            //    SqlConnection conn = new SqlConnection();
            //    DataSet ds = new DataSet("MIS");
            //    conn.ConnectionString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    if (Sno == "")
            //        cmd.CommandText = "select Student.Sname '学生姓名',SC.Cno '课程编号',Course.Cname '课程名',SC.SCORE '分数'  from SC, Student, Course where SC.Sno = Student.Sno AND Course.Cno = SC.Cno AND SC.Cno = '" + Cno + "'";
            //    else if (Cno == "")
            //        cmd.CommandText = "select Student.Sname '学生姓名',SC.Cno '课程编号',Course.Cname '课程名',SC.SCORE '分数'  from SC, Student, Course where SC.Sno = Student.Sno AND Course.Cno = SC.Cno AND SC.Sno = '" + Sno + "'";
            //    else
            //        cmd.CommandText = "select Student.Sname '学生姓名',SC.Cno '课程编号',Course.Cname '课程名',SC.SCORE '分数'  from SC, Student, Course where SC.Sno = Student.Sno AND Course.Cno = SC.Cno AND SC.Cno = '" + Cno + "' AND SC.Sno='" + Sno + "'";
            //    cmd.Connection = conn;
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    sda.SelectCommand = cmd;
            //    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            //    sda.Fill(ds, "Score");
            //    dataGridView1.DataSource = ds.Tables["Score"];
            //    conn.Close();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                try
                {
                    SCItem.InsertSC f1 = new SCItem.InsertSC(ds.Tables[0].Rows[index]["Sno"].ToString(), ds.Tables[0].Rows[index]["Cno"].ToString());
                    f1.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("先按Search进行查询!!", "错误");
                }
                
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
                    string sno = ds.Tables[0].Rows[index]["Sno"].ToString();
                    string cno = ds.Tables[0].Rows[index]["Cno"].ToString();
                    try
                    {
                        if (SC.StuGradeOperation.deleteStuGrade(sno, cno))
                        {
                            MessageBox.Show("删除成功!", "提示");
                            //binddatagrid
                            string Sno = this.SnoText.Text.Trim();
                            string Cno = this.CnoText.Text.Trim();
                            SC.StuGradeData data = new SC.StuGradeData();
                            data.Sno = Sno;
                            data.Cno = Cno;

                            try
                            {
                                ds = SC.StuGradeOperation.getStuGrade(data);
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
                        SCQuery_Load(sender, e);
                    }
                }
            }
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    int index = this.dataGridView1.CurrentRow.Index;
        //    if(index<0)
        //    {
        //        MessageBox.Show("请选择要删除的记录！！", "提示");
        //        return;
        //     }else
        //    {
        //        if(MessageBox.Show("确认要删除？","删除记录",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
        //        {
        //            string sno = ds.Tables[0].Rows[index]["学号"].ToString();
        //            string cno = ds.Tables[0].Rows[index]["课程号"].ToString();
        //            try
        //            {
        //                if (SC.StuGradeOperation.deleteStuGrade(sno,cno))
        //                {
        //                    MessageBox.Show("删除成功!", "提示");
        //                    //binddatagrid
        //                    string Sno = SnoText.Text.Trim();
        //                    string Cno = CnoText.Text;

        //                    SC.StuGradeData data = new SC.StuGradeData();


        //                    data.Sno = Sno;
        //                    data.Cno = Cno;


        //                    try
        //                    {
        //                        ds = SC.StuGradeOperation.getStuGrade(data);
        //                        this.dataGridView1.DataSource = ds.Tables[0];
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        ex.ToString();
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("删除失败", "错误");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ex.ToString();
        //                MessageBox.Show("删除失败", "错误");
        //            }

        //    }
        //    }
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            SCQuery_Load(sender,e);
        }

        private void SnoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CnoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
