using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace socialMediaScrapper.Models
{
    public class scrappedUser
    {
        public string scrappedUserName { get; set; }
        public scrappedTwitterInfo _scrappedTwitterInfo { get; set; }
        public scrappedInstagramInfo _scrappedInstagramInfo { get; set; }
        public scrappedGithubInfo _scrappedGithubInfo { get; set; }
        public scrappedPinterestInfo _scrappedPinterestInfo { get; set; }

        public string messageFromAPI { get; set; }
    }
}