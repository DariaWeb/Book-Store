using System.Collections.Generic;

namespace BookStore.Models.Responses
{
    public class GoogleApiBookResponse
    {
        public IEnumerable<GoogleApiBookItem> Items { get; set; }
    }

    public class GoogleApiBookItem
    {
        public GoogleApiBookVolumeInfo VolumeInfo { get; set; }
    }

    public class GoogleApiBookVolumeInfo
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string PublishedDate { get; set; }

        public GoogleApiBookImageLinks ImageLinks { get; set; }
    }

    public class GoogleApiBookImageLinks
    {
        public string Thumbnail { get; set; }
    }
}
