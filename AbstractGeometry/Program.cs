using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle
				(
				Console.WindowLeft, Console.WindowTop,
				Console.WindowWidth, Console.WindowHeight
				);
			PaintEventArgs e = new PaintEventArgs( graphics, window_rect );
			
			Rectangle rectangle = new Rectangle(100, 40, 500, 200, 3, Color.Red);
			rectangle.Info(e);

			Square square = new Square (80, 500, 50, 3, Color.Aquamarine);
			square.Info(e);

			Circle circle = new Circle(100, 625, 100, 3, Color.LightYellow);
			circle.Info(e);

			IsoscelesTriangle isoTriangle = new IsoscelesTriangle(100, 60, 500, 250, 3, Color.Blue);
			isoTriangle.Info(e);

			EquilateralTriangle eqTriangle = new EquilateralTriangle(100, 500, 350, 3, Color.BlueViolet);
			eqTriangle.Info(e);

			RightTriangle rTriangle = new RightTriangle(150, 80, 650, 370, 3, Color.DarkGoldenrod);
			rTriangle.Info(e);

			LeftTriangle lTriangle = new LeftTriangle(150, 80, 805, 365, 3, Color.DarkGoldenrod);
			lTriangle.Info(e);
		}
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
