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
    }
}