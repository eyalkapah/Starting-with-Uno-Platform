using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp.Shared.Models
{
    public class NavigationItem
    {
        public string Glyph { get; set; }
        public Type TargetType { get; set; }
        public string Title { get; set; }
    }
}