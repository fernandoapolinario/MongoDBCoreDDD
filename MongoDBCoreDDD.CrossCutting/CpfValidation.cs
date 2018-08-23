using System;
using System.Text.RegularExpressions;

namespace MongoDBCoreDDD.CrossCutting
{
    public static class CpfValidation
    {
        public static Boolean IsCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            string pat = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(cpf);
            return m.Success;
        }
    }
}
