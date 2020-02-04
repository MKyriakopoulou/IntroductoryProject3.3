using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCViewIP3._1.Models
{
    public class Lawyer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        public short Gender { get; set; }
        public short Title { get; set; }
        public System.DateTime DateOfBirth { get; set; }
    }
}
