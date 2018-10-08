using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMngmt.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string bookName { get; set; }
        public Student Student { get; set; }
    }
}