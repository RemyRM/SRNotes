using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRNotes.Extensions
{
    public static class ColorExtensions
    {
        public static string ToHexCode(this Color col) => $"#{col.R:X2}{col.G:X2}{col.B:X2}";
    }
}
