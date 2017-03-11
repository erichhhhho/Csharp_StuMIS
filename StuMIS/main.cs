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

namespace StuMIS
{
    public partial class main : Form
    {

        DataSet ds = new DataSet();

        public main()
        {
            InitializeComponent();

            User.UserInfoData data = new User.UserInfoData();
            data.UserName = User.Constants.UserName;
            ds = User.UserInfoOperation.getUserInfoAll(data);
            if (ds.Tables[0].Rows.Count > 0)
            {
                User.Constants.UserRight = ds.Tables[0].Rows[0]["用户权限"].ToString();
                string str = "Welcome Back! \n" + "Dear:" + User.Constants.UserName + "\n Your Authority: " + User.Constants.UserRight;
                MessageBox.Show(str, "Welcome to WestWorld", MessageBoxButtons.OK);
            }
            if (User.Constants.UserRight.Trim() == "学生")
            {
                this.teacherUpdateToolStripMenuItem.Enabled = false;
                this.teacherInsertToolStripMenuItem1.Enabled = false;
                this.teacherDeleteToolStripMenuItem.Enabled = false;
                this.scoreUpdateToolStripMenuItem.Enabled = false;
                this.scoreDeleteToolStripMenuItem.Enabled = false;
                this.scoreInsertToolStripMenuItem.Enabled = false;
                this.courseUpdateToolStripMenuItem.Enabled = false;
                this.courseDeleteToolStripMenuItem.Enabled = false;
                this.courseInsertToolStripMenuItem.Enabled = false;
                this.TCUpdateToolStripMenuItem.Enabled = false;
                this.TCDeleteToolStripMenuItem.Enabled = false;
                this.studentDeleteToolStripMenuItem.Enabled = false;
                this.studentUpdateToolStripMenuItem.Enabled = false;
                this.TCInsertToolStripMenuItem.Enabled = false;
                this.userInfoToolStripMenuItem.Enabled = false;
                this.overviewToolStripMenuItem.Enabled = false;
                this.editRightToolStripMenuItem.Enabled = false;
                
            }
            if (User.Constants.UserRight.Trim() == "教师")
            {
                this.userInfoToolStripMenuItem.Enabled = false;
                this.editRightToolStripMenuItem.Enabled = false;
                this.overviewToolStripMenuItem.Enabled = false;
                this.teacherUpdateToolStripMenuItem.Enabled = false;
                this.teacherDeleteToolStripMenuItem.Enabled = false;
                this.TCInsertToolStripMenuItem.Enabled = false;
                this.TCDeleteToolStripMenuItem.Enabled = false;
                this.scoreInsertToolStripMenuItem.Enabled = false;
                this.scoreQueryToolStripMenuItem.Enabled = false;
                this.studentUpdateToolStripMenuItem.Enabled = false;
                this.studentQueryToolStripMenuItem.Enabled = false;
                this.studentDeleteToolStripMenuItem.Enabled = false;
            }
        }

        private void studentQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new StudentQuery();
            f.Show();

        }

        private void courseQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CourseQuery();
            f.Show();

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Help();
            f.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Quit？", "Quit", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            this.Close();
            this.Dispose();
            f.Show();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllTable f = new AllTable();
            f.Show();
        }

        private void courseInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseItem.Insert_Course f = new CourseItem.Insert_Course("");
            f.ShowDialog();
        }

        private void courseOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseItem.Course_overview f = new CourseItem.Course_overview("");
            f.ShowDialog();
        }

        private void courseDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseItem.Course_overview f = new CourseItem.Course_overview("Delete");
            f.ShowDialog();
        }

        private void courseUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseItem.Course_overview f = new CourseItem.Course_overview("Update");
            f.ShowDialog();
        }

        private void studentInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentItem.InsertStudent f = new StudentItem.InsertStudent("");
            f.ShowDialog();
        }

        private void studentUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentItem.Student_overview f = new StudentItem.Student_overview("Update");
            f.ShowDialog();
        }

        private void studentDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentItem.Student_overview f = new StudentItem.Student_overview("Delete");
            f.ShowDialog();
        }

        private void studentOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentItem.Student_overview f = new StudentItem.Student_overview("");
            f.ShowDialog();
        }

        private void teacherQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherQuery f = new TeacherQuery();
            f.ShowDialog();
        }

        private void teacherInsertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TeacherItem.InsertTeacher f = new TeacherItem.InsertTeacher("");
            f.ShowDialog();
        }

        private void teacherUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherItem.Teacher_overview f = new TeacherItem.Teacher_overview("Update");
            f.ShowDialog();
        }

        private void teacherDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherItem.Teacher_overview f = new TeacherItem.Teacher_overview("Delete");
            f.ShowDialog();
        }

        private void teacherOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherItem.Teacher_overview f = new TeacherItem.Teacher_overview("");
            f.ShowDialog();
        }

        private void scoreQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCItem.SCQuery f = new SCItem.SCQuery("");
            f.Show();
        }

        private void scoreInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCItem.InsertSC f = new SCItem.InsertSC("", "");
            f.ShowDialog();
        }

        private void scoreUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCItem.SCQuery f = new SCItem.SCQuery("Update");
            f.ShowDialog();
        }

        private void scoreDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCItem.SCQuery f = new SCItem.SCQuery("Delete");
            f.ShowDialog();
        }

        private void scoreOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCItem.SCQuery f = new SCItem.SCQuery("");
            f.ShowDialog();

        }

        private void TCQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TCItem.TCQuery f = new TCItem.TCQuery("");
            f.ShowDialog();

        }

        private void TCInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TCItem.InsertTC f = new TCItem.InsertTC("", "");
            f.ShowDialog();

        }

        private void TCUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TCItem.TCQuery f = new TCItem.TCQuery("Update");
            f.ShowDialog(); 
        }

        private void TCDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TCItem.TCQuery f = new TCItem.TCQuery("Delete");
            f.ShowDialog();
        }

        private void TCOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TCItem.TCQuery f = new TCItem.TCQuery("");
            f.ShowDialog();

        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserItem.UserQuery f = new UserItem.UserQuery();
            f.ShowDialog();
        }

        private void editPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserItem.User_Password_Edit f = new UserItem.User_Password_Edit();
            f.ShowDialog();
        }

        private void editRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserItem.User_Right_Edit f = new UserItem.User_Right_Edit();
            f.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {
            timer1.Start();
            toolStripStatusLabel3.Text =   User.Constants.UserRight.Trim();
            toolStripStatusLabel4.Text = "||Current User: " + User.Constants.UserName.Trim();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "||Current Time: "+System.DateTime.Now.ToString();
        }
    }
}
