using System;

namespace rcDominiosUtils
{
    public static class Tratamento
    {
        public static string TratarStringNuloBranco(string valor) {
            string retorno;

            if (valor == null) {
                retorno = null;
            } else {
                retorno = valor.Trim();

                if (retorno == string.Empty) {
                    retorno = null;
                }
            }

            return retorno;
        }
    }
}
