namespace Explorer.Application.Utils
{
    public static class PathUtils
    {
        public static string MapPath(string path)
            => Properties.Resources.BaseDirectory + path;

        public static string ParsePath(string path)
            => path.Replace("%2F", @"\");
    }
}