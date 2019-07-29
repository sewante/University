using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace UniversityService
{
    /// <summary>
    /// Web service to handle the university requests
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class University : System.Web.Services.WebService
    {
        private string message;
        private DataBaseManager dbConnection;

        [WebMethod(Description ="returns the Hello world Message")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "Handles Student Registration Data")]
        public string RegisterStudent(Student student)
        {
            if(student == null)
            {
                message = "student data has not been set. Student not registered";
            }
            else
            {
                if(registerStudet(student))
                {
                    // do the saving to the database here
                    message = "Student " + student.getFullName() + " registered successfully.";
                }
                else
                {
                    message = "Student Registration Failed";
                }
            }

            return message;
        }
        /// <summary>
        /// Rgisters the Student into the system
        /// </summary>
        /// <param name="firstName"> The first name of the student</param>
        /// <param name="lastName"> The last name of the student</param>
        /// <param name="userName"> The user name of the student</param>
        /// <param name="studentNumber"> The automatically generated student number</param>
        /// <param name="password"> The studen't password(encrypted)</param>
        /// <param name="course"> The course to be offered by the student</param>

        private bool registerStudet(Student student)
        {
            SqlConnection connection = null;
            dbConnection = new DataBaseManager();
            bool registered = false;

            try
            {
                connection = dbConnection.GetDBConnection();

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }


                string studentsSql = "INSERT INTO students(studentID,firstName,lastName,password,courseID) " +
                                     "VALUES('" + student.StudentNumber + "','" + student.FirstName + "','" + student.LastName + "','" + student.Password + "','" + student.CourseCode + "')";
                //debug.Text = studentsSql;
                SqlCommand studentCommand = new SqlCommand(studentsSql, connection);


                if (studentCommand.ExecuteNonQuery() > 0)
                {
                    registered = true;

                }
                else
                {
                    registered = false;
                }
            }
            catch (Exception e)
            {
                registered = false;
            }
            finally
            {

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return registered;
        }

        //Return courses
        [WebMethod(Description ="Returns the courses from which students can pick during registration")]
        public string[] GetCourses()
        {
            SqlDataReader coursesDataReader = null;
            SqlConnection connection = null;

            string[] coursesData = null;
            string coursesSql = "";

            try
            {
                dbConnection = new DataBaseManager();

                connection = dbConnection.GetDBConnection();
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                coursesSql = "SELECT courseID, courseName FROM courses";

                SqlCommand coursesResult = new SqlCommand(coursesSql, connection);

                coursesDataReader = coursesResult.ExecuteReader();

                if(coursesDataReader == null)
                {
                    connection.Close();
                    return null;
                }

                if(coursesDataReader.HasRows)
                {
                    int index = 0;
                    while(coursesDataReader.Read())
                    {
                        coursesData[index] = Convert.ToString(coursesDataReader.Read());
                        index++;
                    }
                }

            }
            finally
            {

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return coursesData;

        }
    }
    
}
