using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turbo.Models;

namespace Turbo.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Announcement> VIPAnnouncements { get; set; }
        public IEnumerable<Announcement> RecentAnnouncements { get; set; }
    }
}
