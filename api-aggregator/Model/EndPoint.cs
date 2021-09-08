namespace apiaggregator.Model
{
    public class EndPoint
    {
        public string Name { get; set; }
        public string RelativeUrl { get; set; }
        public ApiMethod Method { get; set; }
        public ParameterType ParameterType { get; set; }
        public string ContentType { get; set; }
    }
}