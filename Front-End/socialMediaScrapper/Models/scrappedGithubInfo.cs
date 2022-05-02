using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace socialMediaScrapper.Models
{
    public class scrappedGithubInfo
    {
        public string full_name { get; set; }
        public string bio { get; set; }
        public string location { get; set; }
        public string contributions { get; set; }
    }
}