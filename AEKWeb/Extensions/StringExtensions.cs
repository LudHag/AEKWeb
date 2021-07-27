namespace AEKWeb.Extensions
{
    public static class StringExtensions
    {
        public static string Englify(this string swedisShtring) =>
            swedisShtring
            .Replace('ö', 'o')
            .Replace('å', 'a')
            .Replace('ä', 'a');
    }
}
