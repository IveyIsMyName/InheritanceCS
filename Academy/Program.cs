//#define INHERITANCE_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;

namespace Academy
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if INHERITANCE_CHECK
			Human human = new Human("Montana", "Antonio", 25);
			human.Print();
			Console.WriteLine(human);

			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96);
			student.Print();
			Console.WriteLine(student);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Print();
			Console.WriteLine(teacher);

			Graduate graduate = new Graduate("Ilyukhin", "Ivan", 33, "Software Engineering", "PV_319", 100, 100, "Telegram Bot");
			graduate.Print();
			Console.WriteLine(graduate);
#endif
			Human[] group = new Human[]
			{
			new Student ("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96),
			new Teacher("White", "Walter", 50, "Chemistry", 25),
			new Graduate("Ilyukhin", "Ivan", 33, "Software Engineering", "PV_319", 100, 100, "Telegram Bot"),
			new Student ("Vercetti", "Tommy", 30, "Theft", "Vice", 97, 98),
			new Teacher("Diaz", "Ricardo", 50, "Weapons distribution", 20),
			};
			Streamer.Print(group);
			Streamer.Save(group, "group.csv");

			//Save(group, "group.txt");
			//Load("group.txt");
		}
		
	}
}
