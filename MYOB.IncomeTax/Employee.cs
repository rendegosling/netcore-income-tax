using System;

namespace MYOB.IncomeTax
{
	public class Employee : IEmployee
	{
		public Employee(string name, decimal annualSalary)
		{
			Name = name;
			AnnualSalary = annualSalary;
		}

		public string Name { get; set;}

		public decimal AnnualSalary { get; set; }
	}
}