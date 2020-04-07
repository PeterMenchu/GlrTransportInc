using System;

namespace GlrTransportInc.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public int TypeOfEmployee { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }

        public bool LoggedIn { get; set; }
        public bool IsaFieldEmpty()
        {
            if (this.FirstName == null 
                || this.LastName == null
                || this.EmailAddress == null
                || this.Password == null)
            {
                return true;
            }return false;
        }
        
        public UserModel(){
            //this.TypeOfEmployee = -1;
        }
    }
}