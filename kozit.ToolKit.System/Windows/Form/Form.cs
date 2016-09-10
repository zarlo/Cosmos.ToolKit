using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozit.ToolKit.System.Windows.Form
{
    public class Form
    {

        public int Width { get; set; }
        public int Height { get; set; }

        public string Title { get; set; }
        public string Name { get; set; }

        public List<IControl> Controls { get; set; }

        public IControl controls()
        {

            return Controls[0];

        }

        public Form(string Title, string Name, int Width = 100, int Height = 100)
        {

            this.Width = Width;
            this.Height = Height;
            this.Title = Title;
            this.Name = Name;
            this.Controls = new List<IControl>();
        }

        public void Redraw(List<Graphics.Common.Pixel> GBuffer)
        {

            foreach (IControl Item in Controls)
            {

                Item.Redraw(GBuffer);

            }

        }


    }
}
