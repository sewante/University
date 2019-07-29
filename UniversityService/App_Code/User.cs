using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityService.App_Code
{
    public class User
    {
        private string user;
        /**
            The User constuctor
         */

        /**
            Set username and get username
         */
         public string userName
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }
    }
}