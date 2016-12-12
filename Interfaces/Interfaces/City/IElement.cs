using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator.Interfaces
{
    public interface IElement
    {
        void SetPosition(int Row, int Col);

        Tuple<int, int> GetPosition();

        bool ContainsPosition(int y2, int x2, int Width, int Height);
    }
}
