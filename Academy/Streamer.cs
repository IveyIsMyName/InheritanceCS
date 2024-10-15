using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	//Single responsibility principle
	internal class Streamer
	{
		internal static void Print(Human[] group)
		{
			foreach (Human human in group)
			{
				Console.WriteLine(human);
			}
			Console.WriteLine();
		}
		internal static void Save(Human[] group, string fileName)
		{
			StreamWriter sw = new StreamWriter(fileName);
			foreach (Human human in group)
			{
				sw.WriteLine(human.ToFileString());
			}
			sw.Close();
			Process.Start("notepad", fileName);
		}
		internal static void Load(string fileName)
		{
			StreamReader sr = new StreamReader(fileName);
			while (!sr.EndOfStream)
			{
				string buffer = sr.ReadLine();
				Console.WriteLine(buffer);
			}
			sr.Close();
		}
		internal static Human[] LoadToArray(string fileName)
		{
			List<Human> list = new List<Human>();
			StreamReader sr = new StreamReader(fileName);
			while (!sr.EndOfStream)
			{
				string buffer = sr.ReadLine();

				string[] parts = buffer.Split(',');
				Human human = HumanFactory(parts[0]);
				human.Init(parts);
				list.Add(human);
			}
				sr.Close();
			return list.ToArray();
		}
		internal static Human HumanFactory(string name)
		{
			Human human = null;
			switch (name)
			{
				case "Human": human = new Human("", "", 0); break;
				case "Teacher": human = new Teacher("", "", 0, "", 0); break;
				case "Student": human = new Student("", "", 0, "", "", 0, 0); break;
				case "Graduate": human = new Graduate("", "", 0, "", "", 0, 0, ""); break;
			}
			return human;
		}
		//CSV - Comma Separated Values (Значение, разделенные запятой)

	}
}
