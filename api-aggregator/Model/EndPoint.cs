using System.Collections.Generic;

namespace apiaggregator.Model
{
    public class EndPoint
    {
        public EndPoint()
        {
            Parameters = new List<EndPointParameter>();
        }

        public string Name { get; set; }
        public string RelativeUrl { get; set; }
        public ApiMethod Method { get; set; }
        public ICollection<EndPointParameter> Parameters { get; set; }
    }
}