using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal abstract class Triangle: Shape
	{
		
		public abstract double GetHeight();
		
		public Triangle
			( int startX, int startY, int lineWidth, Color color)
			: base(startX, startY, lineWidth, color){}
	}
}
