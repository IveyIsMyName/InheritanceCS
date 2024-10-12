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
		//CSV - Comma Separated Values (Значение, разделенные запятой)

	}
}
