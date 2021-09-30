using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Classes
{
    public class LocalizerSettings
    {
        public const string NeutralCulture = "en-US";

        public static readonly string[] SupportedCultures = { NeutralCulture, "ja-JP" };

        public static readonly (string, string)[] SupportedCulturesWithName = new[] { ("English", NeutralCulture), ("Japanese", "ja-JP") };
    }
}
