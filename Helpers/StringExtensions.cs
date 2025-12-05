namespace NotikaIdentityEmail.Helpers
{
    public static class StringExtensions
    {
        public static string KelimeBazliKisalt(this string metin, int karakterSayisi)
        {
            if (string.IsNullOrEmpty(metin)) return "";
            if (metin.Length <= karakterSayisi) return metin;

            int sonBosluk = metin.LastIndexOf(' ', karakterSayisi);

            return (sonBosluk > 0) ? metin.Substring(0, sonBosluk) + "..." : metin.Substring(0, sonBosluk) + "...";

        }
    }
}
