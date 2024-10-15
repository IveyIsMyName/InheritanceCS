using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Human
	{
		static readonly int TYPE_WIDTH = 10;
		static readonly int LAST_NAME_WIDTH = 12;
		static readonly int FIRST_NAME_WIDTH = 12;
		static readonly int AGE_WIDTH = 5;
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }

		//			Constructors:
		public Human(string lastName, string firstName, int age)
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
			Console.WriteLine($"HConstructor:{GetHashCode()}");
		}
		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;
			Console.WriteLine($"HCopyConstructor:{GetHashCode()}");
		}
		~Human()
		{
			Console.WriteLine($"HDestructor:{GetHashCode()}");
		}
		public virtual void Print()
		{
			Console.WriteLine($"{LastName} {FirstName} {Age}");
		}
		public override string ToString()
		{
			return (base.ToString().Split('.').Last()+ ":").PadRight(TYPE_WIDTH) + $"{LastName.PadRight(LAST_NAME_WIDTH)} {FirstName.PadRight(FIRST_NAME_WIDTH)} {Age.ToString().PadRight(AGE_WIDTH)}";
		}
		public virtual string ToFileString()
		{
			return GetType().ToString().Split('.').Last() + $", {LastName}, {FirstName}, {Age}";
		}
		public virtual Human Init(string[] parts)
		{
			LastName = parts[1];
			FirstName = parts[2];
			Age = Convert.ToInt32(parts[3]);
			return this;
		}
	}
}
