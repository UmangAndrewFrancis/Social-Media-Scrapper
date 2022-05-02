using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace socialMediaScrapper.Models
{
    public class scrappedInstagramInfo
    {
        public string profile_image { get; set; }
        public string bio { get; set; }
        public int posts_count { get; set; }
        public int followers { get; set; }
        public int followings { get; set; }
        public bool is_private { get; set; }

    }
}