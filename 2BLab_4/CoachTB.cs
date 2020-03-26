using System;
using System.Collections.Generic;
using System.Text;

namespace _2BLab_4
{
    public class CoachTB
    {
        public int id { get; set; }
        public string School { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public virtual Team TeamNavigation { get; set; }
    }
}
