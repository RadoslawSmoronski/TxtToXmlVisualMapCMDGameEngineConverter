using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtToXmlVisualMapCMDGameEngineConverter
{
    public class VisualElement
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public char Sign { get; private set; }

        public VisualElement(int x, int y, char sign)
        {
            X = x;
            Y = y;
            Sign = sign;
        }
    }
}
