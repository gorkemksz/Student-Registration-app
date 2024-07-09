using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_registration_app
{
    public partial class StudentInformations : Form
    {
        SqlConnection con = new SqlConnection(@"Database Path");
        public StudentInformations()
        {
            InitializeComponent();
        }
        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbPlaceBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void StudentInfo()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Students", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DgStudents.DataSource = dt;
            con.Close();
        }
        private void StudentInformations_Load(object sender, EventArgs e)
        {
            StudentInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand ("insert into [Students] (ID,_Name,Surname,StudentID,Gender,Email,PhoneNumber,PlaceOfBirth,DateOfBirth) values('" + tbID.Text + "','" + tbName.Text + "','" + tbSurname.Text + "','" + tbStudentId.Text + "','" + cmbGender.Text + "','" + tbMail.Text + "','" + tbPhoneNumber.Text + "','" + tbPlaceBirth.Text + "','" + dtpDateBirth.Value.ToString("yyyy/MM/dd")+ "')",con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            StudentInfo();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from [Students] where ID = @ID ",con);
            cmd.Parameters.AddWithValue("@ID",int.Parse(txtSearch.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            StudentInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update [Students] set _Name=@_Name, Surname=@Surname, StudentID=@StudentID, Gender=@Gender, Email=@Email, PhoneNumber=@PhoneNumber, PlaceOfBirth=@PlaceOfBirth, DateOfBirth=@DateOfBirth where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(tbID.Text));
            cmd.Parameters.AddWithValue("@_Name",(tbName.Text));
            cmd.Parameters.AddWithValue("@Surname", (tbSurname.Text));
            cmd.Parameters.AddWithValue("@StudentID",int.Parse(tbStudentId.Text));
            cmd.Parameters.AddWithValue("@Gender",(cmbGender.Text));
            cmd.Parameters.AddWithValue("@Email",(tbMail.Text));
            cmd.Parameters.AddWithValue("@PhoneNumber", int.Parse(tbPhoneNumber.Text));
            cmd.Parameters.AddWithValue("@PlaceOfBirth", (tbPlaceBirth.Text));
            cmd.Parameters.AddWithValue("@DateOfBirth",dtpDateBirth.Value.ToString("yyyy/MM/dd"));
            cmd.ExecuteNonQuery();
            con.Close();
            StudentInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Students] where ID like '%" + txtSearch.Text + "%'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da .Fill(dt);
            DgStudents.DataSource = dt;
            con.Close();
        }
    }
}
