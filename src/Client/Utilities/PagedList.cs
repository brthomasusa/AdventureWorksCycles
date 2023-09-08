namespace AWC.Client.Utilities
{
    public class PagedList<T> where T : class
    {
        public List<T>? Items { get; set; }
        public MetaData? MetaData { get; set; }
    }
}