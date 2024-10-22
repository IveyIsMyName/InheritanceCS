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
		double triangleBase;
		public double TriangleBase
		{
			get => triangleBase; 
			set => triangleBase = SizeFilter(value);
		}
		protected double height;
		public double Height
		{
			get => height;
			set => height = SizeFilter(value);
		}
		public Triangle(double triangleBase, double height, 
			int startX, int startY, int lineWidth, Color color)
			: base(startX, startY, lineWidth, color)
		{
			Height = height;	
			TriangleBase = triangleBase;
		}
		public virtual double GetLeftSide() => Math.Sqrt(Math.Pow(TriangleBase / 2, 2) + Math.Pow(Height , 2));
		public virtual double GetRightSide() => GetLeftSide();
		public double GetLeftSin() => Height / GetLeftSide();
		public double GetRightSin() => Height / GetRightSide();
		public double GetTopSin() => Math.Sin(GetTopAngle()); 
		public double GetLeftAngle() => Math.Asin(GetLeftSin()) * 180 / Math.PI;
		public double GetRightAngle() => Math.Asin(GetRightSin()) * 180 / Math.PI;
		public double GetTopAngle() => 180 - GetRightAngle() - GetLeftAngle();
		public double GetLeftCos()
		{
			double radians = GetLeftAngle() * (Math.PI/180);
			return Math.Cos(radians);
		}
		public double GetRightCos()
		{
			double radians = GetRightAngle() * (Math.PI / 180);
			return Math.Cos(radians);
		}
		public double GetTopCos() => Math.Cos(GetTopAngle());
		public override double GetArea() => triangleBase / 2 * Height;
		public override double GetPerimeter() => TriangleBase + GetLeftSide() + GetRightSide();
		public override void Draw(PaintEventArgs e)
		{
			Point[] points = new Point[]
			{
				new Point(StartX, StartY),
				new Point((int)(StartX - GetLeftSide() * GetLeftCos()), StartY + (int)Height),
				new Point((int)(StartX + GetRightSide() * GetRightCos()), StartY + (int)Height)
			};
			e.Graphics.DrawPolygon(new Pen(Color, LineWidth), points);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine(this.GetType());
			Console.WriteLine($"База: {TriangleBase}");
			Console.WriteLine($"Высота: {Height}");
			base.Info(e);
		}
	}
}
