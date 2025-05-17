namespace Global.News.Web.UI.Utilities
{
    public class StaticDetails
    {
        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }

        public static string? GlobalNewsApi { get; set; }
    }
}
