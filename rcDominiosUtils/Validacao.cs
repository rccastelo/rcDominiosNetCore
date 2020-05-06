using System;
using System.Text.RegularExpressions;

namespace rcDominiosUtils
{
    public static class Validacao
    {
        public static bool ValidarCharDescricao(string valor) {
            if (Regex.IsMatch(valor, @"^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ_\-\s]+$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharCodigoAlfanum(string valor) {
            if (Regex.IsMatch(valor, @"^[0-9A-Za-z_\-]+$")) {
                return true;
            } else {
                return false;
            }
        }
    }
}
