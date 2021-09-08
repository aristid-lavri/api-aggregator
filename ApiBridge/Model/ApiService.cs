using System;
using System.Collections.Generic;

namespace ApiBridge.Model
{
    public class ApiService
    {
        public ApiService()
        {
            EndPoints = new List<EndPoint>();
        }
        public string Name { get; set; }
        public Uri BaseUrl { get; set; }
        public int? Port { get; set; }
        public ICollection<EndPoint> EndPoints { get; set; }

    }
}
