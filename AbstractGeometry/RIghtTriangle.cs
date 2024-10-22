using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class RightTriangle :Triangle
	{
		double sideA;
		double sideB;
		public double SideA
		{
			get => sideA; 
			set => sideA = SizeFilter(value);
		}
		public double SideB
		{
			get => sideB;
			set => sideB = SizeFilter(value);
		}
		public RightTriangle
			(double sideA, double sideB, int startX, int startY,
			int lineWidth, Color color)
			: base(startX, startY, lineWidth, color)
		{
			SideA = sideA;
			SideB = sideB;
		}
		public double GetHypotenuse() => Math.Sqrt(SideA * SideA + SideB * SideB);
		public override double GetHeight() => SideB;
		public override double GetArea() => SideA * SideB / 2;
		public override double GetPerimeter() => SideA + SideB + GetHypotenuse();
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			Point[] points = new Point[]
			{
				new Point(StartX, StartY),
				new Point(StartX, StartY + (int)GetHeight()),
				new Point(StartX + (int)SideA, StartY + (int)GetHeight())
			};
			e.Graphics.DrawPolygon(pen, points);
		}



	}
}
