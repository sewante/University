using System;
namespace UniversityService
{
    public class Student
    {
        /// student properties
        /// 
        private string firstName;
        private string lastName;
        private string courseName;
        private string courseID;
        private string studentnuber;
        private string password;

        /**
            Strudent's costructor
         */
        public Student()
        {
            this.courseID = "";
            this.courseName = "";
            this.firstName = "";
            this.lastName = "";
            this.password = "";
            this.studentnuber = "";
        }

        /**
            Set and get the student lastName
         */
        public string LastName
        {
            set
            {
                lastName = value;
            }

            get
            {
                return lastName;
            }
        }

        /**
            Set and get the student firstName
         */
        public string FirstName
        {
            set
            {
                firstName = value;

            }

            get
            {
                return firstName;
            }
        }

        /**
            Set and get the student number
         */
        public string StudentNumber
        {
            set
            {
                studentnuber = value;

            }

            get
            {
                return studentnuber;
            }
        }

        /**
            Get the student course Name
         */
        public string CourseName
        {

            get
            {
                return courseName;
            }
        }

        /**
            Set and get the student course code
         */
        public string CourseCode
        {
            set
            {
                courseID = value;

            }

            get
            {
                return courseID;
            }
        }

        /**
            Set and get the student password
         */
        public string Password
        {
            set
            {
                password = value;

            }

            get
            {
                return password;
            }
        }
        /**
           get student's full name 
        */
        public string getFullName()
        {
            if (String.IsNullOrEmpty(this.firstName) && String.IsNullOrEmpty(this.lastName))
            {
                return "Provide both Names of student!";
            }

            return this.firstName + " " + this.lastName;
        }
    }
}