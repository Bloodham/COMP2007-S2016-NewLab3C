using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are required to connect to the EF database
using COMP2007_S2016_Lab3C.Models;
using System.Web.ModelBinding;

namespace COMP2007_S2016_Lab3C
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate the student grid
            if(!IsPostBack)
            {
                //get the student data
                this.GetStudents();
            }
        }

        /**
         * <summary>
         * This method gets the student data from the database
         * </summary>
         * @method GetStudents
         * @returns void
         */
        protected void GetStudents()
        {
            //Connect to the EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the Students table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                //bind the result to the GridView
                StudentsGridView.DataSource = Students.ToList();
                StudentsGridView.DataBind();
            }
        }
        /**
         * <summary>
         * this event handler deletes a student from the database using EF
         * </summary>
         * @method StudentsGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
        protected void StudentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Store which row was clicked
            int selectedRow = e.RowIndex;

            //Get the selected studentID using the grid's Datakey collection
            int StudentID = Convert.ToInt32(StudentsGridView.DataKeys[selectedRow].Values["StudentID"]);

            //use EF to find the selected student in the DB and remove it

            using (DefaultConnection db = new DefaultConnection())
            {
                //create an object of the student class and store the query string inside of the object
                Student deletedStudent = (from studentRecords in db.Students
                                          where studentRecords.StudentID == StudentID
                                          select studentRecords).FirstOrDefault();

                //Remove the selected student from the db
                db.Students.Remove(deletedStudent);

                //save my changes back to the database
                db.SaveChanges();

                //refresh the grid
                this.GetStudents();
            }
        }
        /**
         * 
         * <summary>
         * This Event handler allows the pagination to occur for the students page
         * </summary>
         * @method StudentsGridView_PageIndexChanging
         * @Param {object} sender
         * @param
         * 
         */ 
        protected void StudentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            StudentsGridView.PageIndex = e.NewPageIndex;

            //Refresh the grid
            this.GetStudents();
        }
    }
}