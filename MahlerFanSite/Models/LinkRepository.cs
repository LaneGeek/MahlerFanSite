using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public static class LinkRepository
    {
        private static List<Link> _links = new List<Link>();

        public static List<Link> Links => _links;

        public static void AddLink(Link link) => Links.Add(link);

        public static bool IsEmpty => Links.Count == 0;
    }
}
