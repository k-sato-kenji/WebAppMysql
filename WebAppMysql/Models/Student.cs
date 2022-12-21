using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace WebAppMysql.Models
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }

        public string StdName { get; set; }

        public int StdAge { get; set; }

        public string StdAddress { get; set; }

    }

}
