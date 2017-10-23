using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Helpers
{
    internal static class ASCIIReplacer
    {
        private static Dictionary<char, List<char>> _replacements = new Dictionary<char, List<char>> {
            {'a', new List<char> { 'á', 'à', 'ä', 'â', 'ª' } },
            {'A', new List<char> { 'A', 'A', 'A', 'A' } },
            {'e', new List<char>{ 'é', 'è', 'ë', 'ê' } },
            {'E', new List<char>{ 'É', 'È', 'Ê', 'Ë' } },
            {'i', new List<char>{ 'í', 'ì', 'ï', 'î' } },
            {'I', new List<char>{ 'Í', 'Ì', 'Ï', 'Î' } },
            {'o', new List<char>{ 'ó', 'ò', 'ö', 'ô' } },
            {'O', new List<char>{ 'Ó', 'Ò', 'Ö', 'Ô' } },
            {'u', new List<char>{ 'ú', 'ù', 'ü', 'û' } },
            {'U', new List<char>{ 'Ú', 'Ù', 'Û', 'Ü' } },
            {'n', new List<char>{ 'ñ' } },
            {'N', new List<char>{ 'Ñ' } },
            {'c', new List<char>{ 'ç' } },
            {'C', new List<char>{ 'Ç' } },
        };

        public static string Replace(string sourceString)
        {
            var outputString = sourceString;

            foreach (var replacement in _replacements)
            {
                foreach (var charToFind in replacement.Value)
                {
                    outputString = outputString.Replace(charToFind, replacement.Key);
                }
                
            }

            return outputString;
        }
    }
}
