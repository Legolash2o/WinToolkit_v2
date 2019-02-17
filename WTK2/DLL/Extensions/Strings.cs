using System;
using System.Security.Cryptography;
using System.Text;

namespace WinToolkitDLL.Extensions
{
    public static class Strings
    {
        public const StringComparison DefaultComparison = StringComparison.OrdinalIgnoreCase;

        /// <summary>
        ///     Returns a value indicating whether a specified substring occurs within this string.
        /// </summary>
        /// <param name="source">A sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and value are compared.</param>
        /// <returns>true if the value parameter occurs within this string, or if value is the empty string (""); otherwise, false.</returns>
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            return source.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        ///     Returns a value indicating whether a specified substring occurs within this string.
        /// </summary>
        /// <param name="source">A sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <returns>true if the value parameter occurs within this string, or if value is the empty string (""); otherwise, false.</returns>
        public static bool ContainsIgnoreCase(this string source, string value,
            StringComparison comparisonType = DefaultComparison)
        {
            return source.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        ///     Determines whether the end of this string instance matches the specified string when compared using the specified
        ///     comparison option.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">The string to compare to the substring at the end of this instance.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and value are compared.</param>
        /// <returns>true if value matches the end of this instance; otherwise, false.</returns>
        public static bool EndsWithIgnoreCase(this string source, string value,
            StringComparison comparisonType = DefaultComparison)
        {
            return source.EndsWith(value, comparisonType);
        }

        /// <summary>
        ///     Determines whether two String objects have the same value.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">Determines whether two String objects have the same value.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and value are compared.</param>
        /// <returns>true if value matches the beginning of this instance; otherwise, false.</returns>
        public static bool EqualsIgnoreCase(this string source, string value,
            StringComparison comparisonType = DefaultComparison)
        {
            return string.Equals(source, value, comparisonType);
        }

        /// <summary>
        ///     Determines whether the beginning of this string instance matches the specified string when compared using the
        ///     specified comparison option.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">The string to compare to the substring at the end of this instance.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and value are compared.</param>
        /// <returns>true if value matches the beginning of this instance; otherwise, false.</returns>
        public static bool StartsWithIgnoreCase(this string source, string value,
            StringComparison comparisonType = DefaultComparison)
        {
            return source.StartsWith(value, comparisonType);
        }

        /// <summary>
        ///     Determines whether or not the input is numeric.
        /// </summary>
        /// <param name="value">The string you wish to check.</param>
        /// <returns>True if it is numeric.</returns>
        public static bool IsNumeric(this string value)
        {
            double num;
            return double.TryParse(value.Trim(), out num);
        }

        /// <summary>
        ///     Checks if the input has any non-ASCII characters.
        /// </summary>
        /// <param name="inputString">The string that needs to be checked.</param>
        /// <returns>True if none ascii characters detected.</returns>
        public static bool ContainsForeignCharacters(this string inputString)
        {
            var asAscii =
                Encoding.ASCII.GetString(Encoding.Convert(Encoding.UTF8,
                    Encoding.GetEncoding(Encoding.ASCII.EncodingName, new EncoderReplacementFallback(string.Empty),
                        new DecoderExceptionFallback()), Encoding.UTF8.GetBytes(inputString)));
            return !asAscii.Equals(inputString);
        }

        /// <summary>
        ///     Converts a string into an MD5 value.
        /// </summary>
        /// <param name="stringToConvert">The string you wish to be converted into an MD5 value.</param>
        /// <returns>A unique MD5 string.</returns>
        // ReSharper disable once InconsistentNaming
        public static string CreateMD5(this string stringToConvert)
        {
            // step 1, calculate MD5 hash from input
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(stringToConvert);
            var hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Converts a language name such as 'de-DE' to 'German'
        /// </summary>
        /// <param name="originalFilename">Short language name (de-DE)</param>
        /// <returns>Fulle language name (German)</returns>
        public static string GetLanguageName(this string originalFilename)
        {
            if (originalFilename.ContainsIgnoreCase("EN-US") || originalFilename.ContainsIgnoreCase("EN-GB"))
                return "English";

            if (originalFilename.ContainsIgnoreCase("LV-LV"))
                return "Latvian";

            if (originalFilename.ContainsIgnoreCase("AR-SA"))
                return "Arabic";

            if (originalFilename.ContainsIgnoreCase("BG-BG"))
                return "Bulgarian";

            if (originalFilename.ContainsIgnoreCase("CS-CZ"))
                return "Czech";

            if (originalFilename.ContainsIgnoreCase("DA-DK"))
                return "Danish";

            if (originalFilename.ContainsIgnoreCase("DE-DE"))
                return "German";

            if (originalFilename.ContainsIgnoreCase("EL-GR"))
                return "Greek";

            if (originalFilename.ContainsIgnoreCase("ES-ES"))
                return "Spanish";

            if (originalFilename.ContainsIgnoreCase("ET-EE"))
                return "Estonian";

            if (originalFilename.ContainsIgnoreCase("FI-FI"))
                return "Finnish";

            if (originalFilename.ContainsIgnoreCase("FR-FR"))
                return "French";

            if (originalFilename.ContainsIgnoreCase("HE-IL"))
                return "Hebrew";

            if (originalFilename.ContainsIgnoreCase("HR-HR"))
                return "Croatian";

            if (originalFilename.ContainsIgnoreCase("HU-HU"))
                return "Hungarian";

            if (originalFilename.ContainsIgnoreCase("IT-IT"))
                return "Italian";

            if (originalFilename.ContainsIgnoreCase("JA-JP"))
                return "Japanese";

            if (originalFilename.ContainsIgnoreCase("KO-KR"))
                return "Korean";

            if (originalFilename.ContainsIgnoreCase("LT-LT"))
                return "Lithuanian";

            if (originalFilename.ContainsIgnoreCase("NB-NO"))
                return "Norwegian";

            if (originalFilename.ContainsIgnoreCase("NL-NL"))
                return "Dutch";

            if (originalFilename.ContainsIgnoreCase("PL-PL"))
                return "Polish";

            if (originalFilename.ContainsIgnoreCase("PT-BR"))
                return "Brazilian Portuguese";

            if (originalFilename.ContainsIgnoreCase("PT-PT"))
                return "Portuguese";

            if (originalFilename.ContainsIgnoreCase("RO-RO"))
                return "Romanian";

            if (originalFilename.ContainsIgnoreCase("RU-RU"))
                return "Russian";

            if (originalFilename.ContainsIgnoreCase("SK-SK"))
                return "Slovak";

            if (originalFilename.ContainsIgnoreCase("SL-SI"))
                return "Slovenian";

            if (originalFilename.ContainsIgnoreCase("SR-LATN-CS"))
                return "Serbian-Latin";

            if (originalFilename.ContainsIgnoreCase("SV-SE"))
                return "Swedish";

            if (originalFilename.ContainsIgnoreCase("TH-TH"))
                return "Thai";

            if (originalFilename.ContainsIgnoreCase("TR-TR"))
                return "Turkish";

            if (originalFilename.ContainsIgnoreCase("UK-UA"))
                return "Ukrainian";

            if (originalFilename.ContainsIgnoreCase("ZH-CN"))
                return "Chinese (Simplified)";

            if (originalFilename.ContainsIgnoreCase("ZH-HK"))
                return "Chinese (Hong Kong)";

            if (originalFilename.ContainsIgnoreCase("ZH-TW"))
                return "Chinese (Traditional-Taiwan)";

            return "N/A";
        }

        /// <summary>
        ///     Replaces text ignoring case.
        /// </summary>
        /// <param name="input">Text to be inspected</param>
        /// <param name="replace">Text to search for</param>
        /// <param name="replaceWith">New text for 'replace'</param>
        /// <param name="trimEnds">Removes any spaces at end and beginning</param>
        /// <returns>Newly created string</returns>
        public static string ReplaceIgnoreCase(this string input, string replace, string replaceWith,
            bool trimEnds = false)
        {
            //Tries a standard string replace.
            var standardReplace = input.Replace(replace, replaceWith);
            if (!input.ContainsIgnoreCase(replace))
            {
                if (trimEnds)
                    return standardReplace.Trim();
                return standardReplace;
            }

            //If that fails. It will then try a more thorough method.
            try
            {
                var newString = input;
                var sb = new StringBuilder();

                var previousIndex = 0;
                var index = newString.IndexOf(replace, DefaultComparison);
                while (index != -1)
                {
                    sb.Append(newString.Substring(previousIndex, index - previousIndex));
                    sb.Append(replaceWith);
                    index += replace.Length;

                    previousIndex = index;
                    index = newString.IndexOf(replace, index, DefaultComparison);
                }
                sb.Append(newString.Substring(previousIndex));

                if (trimEnds)
                    return sb.ToString().Trim();
                return sb.ToString();
            }
            catch (Exception)
            {
                //new SmallError("String Replacement", Ex, string.Format("input: '{0}'\nReplace: '{1};\nReplaceWith: '{2}'\nOutPut: '{3}'", input, replace, replaceWith, NewString)).Upload();
            }
            return input;
        }
    }
}