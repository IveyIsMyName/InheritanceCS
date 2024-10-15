using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	//Single responsibility principle
	internal class Streamer
	{
		internal static string SetDirectory()
		{
			string location = System.Reflection.Assembly.GetEntryAssembly().Location;
			string path = System.IO.Path.GetDirectoryName(location);
			Console.WriteLine(location);
			Console.WriteLine(path);
			Directory.SetCurrentDirectory($"{path}\\..\\..");
			Console.WriteLine(Directory.GetCurrentDirectory());
			Console.Write("\n------------------------------------------------------\n");
			return Directory.GetCurrentDirectory();
		}
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
			SetDirectory();
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
			SetDirectory();
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
			SetDirectory();
			List<Human> list = new List<Human>();
			StreamReader sr = new StreamReader(fileName);
			while (!sr.EndOfStream)
			{
				string buffer = sr.ReadLine();
				string[] parts = buffer.Split(',');
				//parts = parts.Where(s => s != "").ToArray() //удаляем пустые строки
				//if(parts.Length == 1) continue;
				//Human human = HumanFactory.Create(parts[0]);
				//human.Init(parts);
				//list.Add(human);
				list.Add(HumanFactory.Create(parts[0]).Init(parts));
			}
			sr.Close();
			return list.ToArray();
		}
		
		//CSV - Comma Separated Values (Значение, разделенные запятой)

	}
}
