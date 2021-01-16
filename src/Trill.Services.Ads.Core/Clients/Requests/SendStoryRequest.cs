using System;
using System.Collections.Generic;

namespace Trill.Services.Ads.Core.Clients.Requests
{
    public class SendStoryRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public DateTime VisibleFrom { get; set; }
        public DateTime VisibleTo { get; set; }
        public bool Highlighted { get; set; }
    }
}