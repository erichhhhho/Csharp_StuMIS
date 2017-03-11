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
    public partial class InsertTeacher : Form
    {
        string FLAG;
        public InsertTeacher(string flag)
        {
            InitializeComponent();

            comboBox3.Items.Add("男");
            comboBox3.Items.Add("女");
            
            this.comboBox5.Items.Add("教授");
            this.comboBox5.Items.Add("副教授");
            this.comboBox5.Items.Add("讲师");
            this.comboBox5.Items.Add("助教");

            this.comboBox8.Items.Add("计算机");
            this.comboBox8.Items.Add("电子商务");
            this.comboBox8.Items.Add("信科");
            this.comboBox8.Items.Add("信管");
            this.comboBox8.Items.Add("信息");
            this.FLAG = flag;
            
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox3.Text = "";
            textBox4.Text = "";
            comboBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox8.Text = "";


            if (flag != "")
            {
                Teacher.TeacherInfoData data = new Teacher.TeacherInfoData();
                data.Tno = flag;
                DataSet ds = Teacher.TeacherInfoOperation.getTeacherInfo(data);
                this.textBox1.Text = flag;
                this.textBox2.Text = ds.Tables[0].Rows[0]["教师名"].ToString();
                this.comboBox3.Text = ds.Tables[0].Rows[0]["性别"].ToString();
                this.textBox4.Text = ds.Tables[0].Rows[0]["年龄"].ToString();
                this.comboBox5.Text = ds.Tables[0].Rows[0]["职称"].ToString();
                this.textBox6.Text = ds.Tables[0].Rows[0]["薪水"].ToString();
                this.textBox7.Text = ds.Tables[0].Rows[0]["津贴"].ToString();
                this.comboBox8.Text = ds.Tables[0].Rows[0]["所教专业"].ToString();
                this.textBox1.Enabled = false;
                this.Text = "Update";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Tno = textBox1.Text.Trim();
            string Tname = textBox2.Text;
            string Sex = comboBox3.Text;
            string Age = textBox4.Text;
            string Prof = comboBox5.Text;
            string Sal = textBox6.Text;
            string Comm = textBox7.Text;
            string Dept = comboBox8.Text;

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text.Trim() == null || textBox2.Text.Trim() == null || comboBox3.Text.Trim() == null || textBox4.Text.Trim() == null || comboBox5.Text.Trim() == null)
                MessageBox.Show("请输入完整信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Teacher.TeacherInfoData data = new Teacher.TeacherInfoData();

            data.Tno = Tno;
            data.Tname = Tname;
            data.Sex = Sex;
            data.Age = Age;
            data.Prof = Prof;
            data.Sal = Sal;
            data.Comm = Comm;
            data.Dept = Dept;

            try
            {
                if (FLAG == "")
                {
                    if (Teacher.TeacherInfoOperation.insertTeacherInfo(data))
                    {
                        MessageBox.Show("添加成功", "提示");
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.comboBox3.Text = "";
                        this.textBox4.Text = "";
                        this.comboBox5.Text = "";
                        this.textBox6.Text = "";
                        this.textBox7.Text = "";
                        this.comboBox8.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "提示");
                    }
                }
                else
                {
                    if (Teacher.TeacherInfoOperation.updateTeacherInfo(data))
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

