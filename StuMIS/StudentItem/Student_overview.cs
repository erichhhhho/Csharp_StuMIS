using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuMIS.StudentItem
{
    public partial class Student_overview : Form
    {
        DataSet ds = new DataSet();
        public Student_overview(string flag)
        {
            InitializeComponent();
            if (flag == "Update")
            {
                this.Text = "Update";
                this.button2.Visible = true;
            }
            else if (flag == "Delete")
            {
                this.Text = "Delete";
                this.button3.Visible = true;
            }
        }

        private void Student_overview_Load(object sender, EventArgs e)
        {
            Student.StudentInfoData data = new Student.StudentInfoData();
            ds = Student.StudentInfoOperation.getStudentInfo(data);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Sno = textBox1.Text.Trim();
            string Sname = textBox2.Text;
            string Sex = textBox3.Text;
            string Grade = textBox4.Text;
            string Dept = textBox7.Text;
            Student.StudentInfoData data = new Student.StudentInfoData();

            data.Sno = Sno;
            data.Sname = Sname;
            data.Sex = Sex;
            data.Grade = Grade;
            data.Dept = Dept;

            try
            {
                ds = Student.StudentInfoOperation.getStudentInfo(data);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
          
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
                    StudentItem.InsertStudent f1 = new InsertStudent(ds.Tables[0].Rows[index]["StudentNumber"].ToString());

                    f1.ShowDialog();

                }
                catch
                {
                    MessageBox.Show("一定要先按Search!!", "错误");
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
                    string sno = ds.Tables[0].Rows[index]["StudentNumber"].ToString();
                    try
                    {
                        if (Student.StudentInfoOperation.deleteStudentInfo(sno))
                        {
                            MessageBox.Show("删除成功!", "提示");
                            //binddatagrid
                            string Sno = textBox1.Text.Trim();
                            string Sname = textBox2.Text;
                            string Sex = textBox3.Text;
                            string Grade = textBox4.Text;
                            string Dept = textBox7.Text;

                            Student.StudentInfoData data = new Student.StudentInfoData();


                            data.Sno = Sno;
                            data.Sname = Sname;
                            data.Sex = Sex;
                            data.Grade = Grade;
                            data.Dept = Dept;

                            try
                            {
                                ds = Student.StudentInfoOperation.getStudentInfo(data);
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
                        Student_overview_Load(sender, e);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_overview_Load(sender, e);
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
    }
}
