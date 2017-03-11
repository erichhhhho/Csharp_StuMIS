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
    public partial class InsertStudent : Form
    {
        string FLAG;
        public InsertStudent(string flag)
        {

            InitializeComponent();
            this.FLAG = flag;
            if (flag != "")
            {
                Student.StudentInfoData data = new Student.StudentInfoData();
                data.Sno = flag;
                DataSet ds = Student.StudentInfoOperation.getStudentInfo(data);
                this.textBox1.Text = flag;
                this.textBox2.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
                this.textBox3.Text = ds.Tables[0].Rows[0]["Sex"].ToString();
                this.textBox4.Text = ds.Tables[0].Rows[0]["Grade"].ToString();
                this.textBox5.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                this.textBox1.Enabled = false;
                this.Text = "Update";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Sno = textBox1.Text.Trim();
            string Sname = textBox2.Text;
            string Sex = textBox3.Text;
            string Grade = textBox4.Text;
            string Dept = textBox5.Text;

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text.Trim() == null || textBox2.Text.Trim() == null || textBox3.Text.Trim() == null || textBox4.Text.Trim() == null || textBox5.Text.Trim() == null)
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Student.StudentInfoData data = new Student.StudentInfoData();

            data.Sno = Sno;
            data.Sname = Sname;
            data.Sex = Sex;
            data.Grade = Grade;
            data.Dept = Dept;

            try
            {
                if (FLAG == "")
                {
                    if (Student.StudentInfoOperation.insertStudentInfo(data))
                    {
                        MessageBox.Show("添加成功", "提示");
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.textBox3.Text = "";
                        this.textBox4.Text = "";
                        this.textBox5.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("添加失败", "提示");
                    }
                }
                else
                {
                    if (Student.StudentInfoOperation.updateStudentInfo(data))
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
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
