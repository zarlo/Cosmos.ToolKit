using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozit.ToolKit.System.Windows.Form
{
    public interface IControl
    {
        int X { get; set; }
        int Y { get; set; }
        string Name { get; set; }

        void Redraw(List<Graphics.Common.Pixel> GBuffer);

    }
}
