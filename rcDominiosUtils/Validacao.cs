using System;
using System.Text.RegularExpressions;

namespace rcDominiosUtils
{
    public static class Validacao
    {
        /*
        A = letras maiúsculas (A-Z)
        a = letras minúsculas (a-z)
        B = espaço em branco (\s)
        C = acentuação maiúscula (ÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ)
        c = acentuação minúscula (áàâãéèêíïóôõöúçñ)
        E = especiais ()
        N = números (0-9)
        T = traços = sublinhado e hífen (_\-)
        */
        public static bool ValidarCharAaBCcNT(string valor) {
            if (Regex.IsMatch(valor, @"^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ_\-\s]+$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaNT(string valor) {
            if (Regex.IsMatch(valor, @"^[0-9A-Za-z_\-]+$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaBCc(string valor) {
            if (Regex.IsMatch(valor, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaN(string valor) {
            if (Regex.IsMatch(valor, @"^[0-9A-Za-z]+$")) {
                return true;
            } else {
                return false;
            }
        }
    }
}
