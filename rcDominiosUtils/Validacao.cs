using System;
using System.Text.RegularExpressions;

namespace rcDominiosUtils
{
    public static class Validacao
    {
        //-- A = letras maiúsculas (A-Z)
        static string mai = "A-Z";

        //-- a = letras minúsculas (a-z)
        static string min = "a-z";

        //-- B = espaço em branco (\s)
        static string bra = @"\s";

        //-- C = acentuação maiúscula (ÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ)
        static string ama = "ÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ";

        //-- c = acentuação minúscula (áàâãéèêíïóôõöúçñ)
        static string ami = "áàâãéèêíïóôõöúçñ";

        //-- E = especiais !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~´
        static string esp = @"\!""#\$%&'\(\)\*\+,\-\./:;<=>\?@\[\\\]\^_`\{\|\}~´";

        //-- N = números (0-9)
        static string num = "0-9";

        //-- T = traços = sublinhado e hífen (_\-)
        static string tra = @"_\-";

        public static bool ValidarCharAaBCcNT(string valor) {
            if (Regex.IsMatch(valor, $"^[{num}{mai}{min}{ami}{ama}{tra}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaNT(string valor) {
            if (Regex.IsMatch(valor, $"^[{num}{mai}{min}{tra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaBCc(string valor) {
            if (Regex.IsMatch(valor, $"^[{mai}{min}{ami}{ama}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaBEN(string valor) {
            if (Regex.IsMatch(valor, $"^[{num}{mai}{min}{bra}{esp}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaB(string valor) {
            if (Regex.IsMatch(valor, $"^[{mai}{min}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaBN(string valor) {
            if (Regex.IsMatch(valor, $"^[{num}{mai}{min}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaN(string valor) {
            if (Regex.IsMatch(valor, $"^[{num}{mai}{min}]+$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarBrancoIniFim(string valor) {
            if (valor.StartsWith(" ") || valor.EndsWith(" ")) {
                return false;
            } else {
                return true;
            }
        }
    }
}
