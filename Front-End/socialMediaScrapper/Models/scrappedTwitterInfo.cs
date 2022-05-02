using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace socialMediaScrapper.Models
{
    public class scrappedTwitterInfo
    {
        public string full_name { get; set; }
        public string banner { get; set; }
        public string profile_image_link { get; set; }
        public bool account_verified { get; set; }
        public string birth_date { get; set; }
        public string location { get; set; }
        public string website { get; set; }
        public string bio { get; set; }
        public string followers { get; set; }
        public string following { get; set; }
        public string joined_date { get; set; }

    }
}