using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_Lab3C.Models;
using System.Web.ModelBinding;

namespace COMP2007_S2016_Lab3C
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //use ef connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                //use the student model to create a new student object and
                // save a new record
                Student newStudent = new Student();

                //add data to the new student record
                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                //use LINQ to ADO.NET to add / insert new student into the database
                db.Students.Add(newStudent);

                //Save our changes
                db.SaveChanges();

                //Redirect to the updated Students Page
                Response.Redirect("~/Students.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirects back to Students
            Response.Redirect("~/Students.aspx");
        }
    }
}