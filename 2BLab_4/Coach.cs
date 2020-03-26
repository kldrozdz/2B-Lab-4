using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace _2BLab_4
{
    public class Item
    {
        public string school { get; set; }

    }
    public class Coach
    {
        public List<Item> seasons { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
