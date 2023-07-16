using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Models
{
    public class Register
    {

        [Key]
       
        //[MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Plz mention the specified format")]
        public string Username { get; set; }
        //[MaxLength(30)]
        public string Password { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Plz mention the specified format")]
        //[MaxLength(30)]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Plz mention the specified format")]
        //[MaxLength(30)]
        public string Alias { get; set; }
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Plz mention the specified format")]
        //[MaxLength(30)]
        public string Designation { get; set; }
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Plz mention the specified format")]
        //[MaxLength(30)]
        public string Department { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Plz mention the specified format")]
        //[MaxLength(30)]
        public string Email { get; set; }
        //[MaxLength(30)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Plz mention the specified format")]
        public string Mobile { get; set; }
        //[MaxLength(30)]
        public string UserType { get; set; }
        //[MaxLength(30)]
        public string GroupId { get; set; }
        //[MaxLength(30)]
        public string Location { get; set; }

    }
}
