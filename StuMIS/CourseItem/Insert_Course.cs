using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuMIS.CourseItem
{
    public partial class Insert_Course : Form
    {
        string FLAG;

        public Insert_Course(string flag)
        {
            InitializeComponent();
           
            this.FLAG = flag;
            if (flag != "")
            {
                Course.CourseInfoData data = new Course.CourseInfoData();
                data.Cno = flag;
                DataSet ds = Course.CourseInfoOperation.getCourseInfo(data);
                this.textBox1.Text = flag;
                this.textBox2.Text = ds.Tables[0].Rows[0]["课程名"].ToString();
                this.textBox3.Text = ds.Tables[0].Rows[0]["课时"].ToString();
                this.textBox4.Text = ds.Tables[0].Rows[0]["学分"].ToString();
                this.textBox1.Enabled = false;
                this.Text = "Update";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Cno = textBox1.Text.Trim();
            string Cname = textBox2.Text;
            string Chour = textBox3.Text;
            string Ccredit = textBox4.Text;
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text.Trim() == null || textBox2.Text.Trim() == null || textBox3.Text.Trim() == null || textBox4.Text.Trim() == null)
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Course.CourseInfoData data = new Course.CourseInfoData();

            data.Cno = Cno;
            data.Cname = Cname;
            data.Chour = Chour;
            data.Ccredit = Ccredit;

            try
            {
                if (FLAG == "")
                {
                    if (Course.CourseInfoOperation.insertCourseInfo(data))
                    {
                        MessageBox.Show("添加成功", "提示");
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.textBox3.Text = "";
                        this.textBox4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "提示");
                    }
                }
                else
                {
                    if (Course.CourseInfoOperation.updateCourseInfo(data))
                    {
                        MessageBox.Show("修改成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show("修改失败", "提示");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("保存失败", "错误");
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
