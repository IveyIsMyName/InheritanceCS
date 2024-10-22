using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Circle:Shape, IHaveDiameter
	{
		double radius;
		public double Radius
		{
			get => radius; 
			set => radius = SizeFilter(value);
		}
		public Circle 
			(double radius, 
			int startX, int startY, int lineWidth, Color color)
			:base(startX, startY, lineWidth, color)
		{
			Radius = radius;
		}
		public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
		
		public override double GetPerimeter() => 2 * Math.PI * Radius;
		public double GetDiameter() => 2 * Radius;
		public void DrawDiameter(PaintEventArgs e)
		{
			//int dx = (int)(Radius * (1 - 1 / Math.Sqrt(2)));
			float centerX = (float)(StartX + Radius);
			float centerY = (float)(StartY + Radius);
			e.Graphics.DrawLine(new Pen(Color, 1), (float)(centerX - Radius), centerY, (float)(centerX + Radius), centerY);
		}
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawEllipse(pen, StartX, StartY, (float)GetDiameter(),(float)GetDiameter() );
			DrawDiameter(e);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine(this.GetType());
            Console.WriteLine($"Радиус: {Radius}");
            Console.WriteLine($"Диаметр: {GetDiameter()}");
			base.Info(e);
		}
	}
}
