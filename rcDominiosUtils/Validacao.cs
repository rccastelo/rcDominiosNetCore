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
        E = especiais (\!"#\$%'\(\)\*\+´-\./:;<=>\?@\[\]\^\\_`\{\}\|~)
        N = números (0-9)
        T = traços = sublinhado e hífen (_\-)
        */
        static string mai = "A-Z";
        static string min = "a-z";
        static string bra = @"\s";
        static string ama = "ÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ";
        static string ami = "áàâãéèêíïóôõöúçñ";
        static string esp = @"\!""#\$%'\(\)\*\+´-\./:;<=>\?@\[\]\^\\_`\{\}\|~";
        static string num = "0-9";
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
    }
}
