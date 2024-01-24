using System.Drawing;

namespace SRNotes.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Get the Hexcode (including #) from the current Colour Value
        /// </summary>
        /// <param name="col">The colour to convert</param>
        /// <returns>A # prefixed Colour code</returns>
        public static string ToHexCode(this Color col) => $"#{col.R:X2}{col.G:X2}{col.B:X2}";
    }
}
