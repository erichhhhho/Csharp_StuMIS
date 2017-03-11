using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuMIS.TeacherItem
{
    public partial class Teacher_overview : Form
    {
        DataSet ds = new DataSet();
        public Teacher_overview(string flag)
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
                    TeacherItem.InsertTeacher f1 = new InsertTeacher(ds.Tables[0].Rows[index]["教师号"].ToString());
                    f1.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("一定要先按Search!!", "错误");
                }
            }
        }

        private void Teacher_overview_Load(object sender, EventArgs e)
        {
            Teacher.TeacherInfoData data = new Teacher.TeacherInfoData();
            ds = Teacher.TeacherInfoOperation.getTeacherInfo(data);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Tno = textBox1.Text.Trim();
            string Tname = textBox2.Text;
            string Sex = textBox3.Text;
            string Age = textBox4.Text;
            string Prof = textBox5.Text;
            string Sal = textBox6.Text;
            string Dept = textBox7.Text;
            Teacher.TeacherInfoData data = new Teacher.TeacherInfoData();

            data.Tno = Tno;
            data.Tname = Tname;
            data.Sex = Sex;
            data.Age = Age;
            data.Prof = Prof;
            data.Sal = Sal;
            data.Dept = Dept;

            try
            {
                ds = Teacher.TeacherInfoOperation.getTeacherInfo(data);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
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
                    string tno = ds.Tables[0].Rows[index]["教师号"].ToString();
                    try
                    {
                        if (Teacher.TeacherInfoOperation.deleteTeacherInfo(tno))
                        {
                            MessageBox.Show("删除成功!", "提示");
                            //binddatagrid
                            string Tno = textBox1.Text.Trim();
                            string Tname = textBox2.Text;
                            string Sex = textBox3.Text;
                            string Age = textBox4.Text;
                            string Prof = textBox5.Text;
                            string Sal = textBox6.Text;
                            string Dept = textBox7.Text;

                            Teacher.TeacherInfoData data = new Teacher.TeacherInfoData();


                            data.Tno = Tno;
                            data.Tname = Tname;
                            data.Sex = Sex;
                            data.Age = Age;
                            data.Prof = Prof;
                            data.Sal = Sal;
                            data.Dept = Dept;

                            try
                            {
                                ds = Teacher.TeacherInfoOperation.getTeacherInfo(data);
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
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
