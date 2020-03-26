using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace _2BLab_4
{
    public class Team
    {
        public int id { get; set; }
        public string school { get; set; }
        public string mascot { get; set; }
        public virtual CoachTB CoachNavigation { get; set; }
    }
}
