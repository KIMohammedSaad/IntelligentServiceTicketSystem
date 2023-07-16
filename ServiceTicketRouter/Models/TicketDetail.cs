using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Models
{
    public class TicketDetail
    {
        [Key]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Plz mention the specified format")]
        //[Required]
        //[Range(10000, 99999)]
        public int TicketNo { get; set; }
        public string IssueType { get; set; }
        public string TicketStatus { get; set; }
        public string CustomerName { get; set; }
        public string ServicerName { get; set; }
        public string ServicerEmail { get; set; }
        public string ServicerMobile { get; set; }
        public string ServicerComment { get; set; }
        public string UserComment { get; set; }
        public string IPAddress { get; set; }
        
    }
}
