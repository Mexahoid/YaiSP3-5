using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public interface IResizable : IDrawable
    {
        void SetDims(Tuple<int, int, double, double, double, double> Coords);
    }
}
