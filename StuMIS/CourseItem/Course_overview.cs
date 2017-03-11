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

namespace StuMIS.CourseItem
{
    public partial class Course_overview : Form
    {
        DataSet ds = new DataSet();

        public Course_overview(string flag)
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

        private void Course_overview_Load(object sender, EventArgs e)
        {
            Course.CourseInfoData data = new Course.CourseInfoData();
            ds = Course.CourseInfoOperation.getCourseInfo(data);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Cno = textBox1.Text.Trim();
            string Cname = textBox2.Text;
            string Chour = textBox3.Text;
            string Ccredit = textBox4.Text;

            Course.CourseInfoData data = new Course.CourseInfoData();

            data.Cno = Cno;
            data.Cname = Cname;
            data.Chour = Chour;
            data.Ccredit = Ccredit;

            try
            {
                ds = Course.CourseInfoOperation.getCourseInfo(data);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                Course_overview_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int index = this.dataGridView1.CurrentRow.Index;
            if(index<0)
            {
                MessageBox.Show("请选择要修改的记录！", "提示");
                return;
            }
            else
            {
                try { 
                CourseItem.Insert_Course f1 = new Insert_Course(ds.Tables[0].Rows[index]["课程号"].ToString());
                f1.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("先按Search进行查询!!", "错误");
                }
                finally
                {
                    Course_overview_Load(sender, e);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            if (index < 0)
            {
                MessageBox.Show("请选择要删除的记录！", "提示");
                return;
            }
            else
            {
                if (MessageBox.Show("确定要删除吗？", "删除后无法撤回", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string cno = ds.Tables[0].Rows[index]["课程号"].ToString();
                    try
                    {
                        if (Course.CourseInfoOperation.deleteCourseInfo(cno))
                        {
                            MessageBox.Show("删除成功!", "提示");
                            //binddatagrid
                            string Cno = textBox1.Text.Trim();
                            string Cname = textBox2.Text;
                            string Chour = textBox3.Text;
                            string Ccredit = textBox4.Text;

                            Course.CourseInfoData data = new Course.CourseInfoData();

                            data.Cno = Cno;
                            data.Cname = Cname;
                            data.Chour = Chour;
                            data.Ccredit = Ccredit;

                            try
                            {
                                ds = Course.CourseInfoOperation.getCourseInfo(data);
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
                        Course_overview_Load(sender, e);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Course_overview_Load(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
