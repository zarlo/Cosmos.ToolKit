using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kozit.ToolKit.Graphics.Common;

namespace kozit.ToolKit.System.Windows.Form
{
    public class label : IControl
    {

        public string Name { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public string Content { get; set; }

        public void Redraw(List<Pixel> GBuffer)
        {
            
        

        }

    }
}
