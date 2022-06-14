using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class ListProducts : Entity
    {
        public string NameList { get; set; }
        public string Description { get; set; }
        public string TypeCampaing { get; set; }
    }
}
