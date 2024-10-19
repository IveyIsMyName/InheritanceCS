using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Circle:Shape
	{
		double radius;
		public double Radius
		{
			get => radius; 
			set => radius = 
				value < MIN_SIZE ? MIN_SIZE :
				value > MAX_SIZE ? MAX_SIZE :
				value;
		}
		public Circle (double radius, int startX, int startY, int line_width, Color color)
			:base(startX, startY, line_width, color)
		{
			Radius = radius;
		}
		public double GetDiameter() => 2 * Radius;
		public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
		
		public override double GetPerimeter() => 2 * Math.PI * Radius;
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawEllipse(pen, StartX, StartY, (float)GetDiameter(),(float)GetDiameter() );
		}
		public override void Info(PaintEventArgs e)
		{
            Console.WriteLine($"Радиус: {Radius}");
            Console.WriteLine($"Диаметр: {GetDiameter()}");
			base.Info(e);
		}
	}
}
