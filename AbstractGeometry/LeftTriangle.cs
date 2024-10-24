using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class LeftTriangle : RightTriangle
	{
		public LeftTriangle(double sideA, double sideB, int startX,
			int startY, int lineWidth, Color color)
			:base(sideA, sideB, startX, startY, lineWidth, color) { }
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			Point[] points = new Point[]
			{
				new Point(StartX, StartY),
				new Point(StartX - (int)SideA, StartY),
				new Point(StartX, StartY + (int)GetHeight())
			};
			e.Graphics.DrawPolygon(pen, points);
		}
	}
}
