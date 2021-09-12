namespace VeroneziVendas.Domain.Helper
{
    public static class StringHelper
    {
        public static string RemoveSimbolos(this string texto)
        {
            if (!string.IsNullOrWhiteSpace(texto))
            {
                texto = texto.Replace("-", "").Replace(".", "").Replace("/", "").Replace(",", "").Replace(@"\", "").Replace("–", "");
            }

            return texto;
        }
    }
}
