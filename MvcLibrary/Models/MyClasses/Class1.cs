using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Models.MyClasses
{
    public class Class1
    {
        public IEnumerable<tbl_Books> value1 { get; set; }
        public IEnumerable<tbl_About> value2 { get; set; }
    }
}