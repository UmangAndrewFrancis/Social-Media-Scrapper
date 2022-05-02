using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace socialMediaScrapper.Models
{
    public class scrappedPinterestInfo
    {
        public string id { get; set; }
        public string full_name { get; set; }
        public string profile_image { get; set; }
        public int followers { get; set; }
        public int followings { get; set; }
        public string bio { get; set; }
        public string country { get; set; }
        public string impressum_url { get; set; }
        public string website { get; set; }
        public int board_count { get; set; }
        public bool is_indexed { get; set; }
        public string location { get; set; }
        public int pin_count { get; set; }
        public bool is_verified { get; set; }
        public int profile_view { get; set; }
        public string interest_following_count { get; set; }
        public bool has_published_pins { get; set; }
        public bool video_pin_count { get; set; }
    }
}