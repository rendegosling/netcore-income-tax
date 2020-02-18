using System;
using MYOB.IncomeTax;

namespace MYOB.IncomeTax.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Type GenerateMonthlyPayslip \"YOUR NAME\" ANNUAL_SALARY to start..");
			string line = Console.ReadLine();
			string[] words = line.Split(' ');
			if (words[0] == "GenerateMonthlyPayslip")
			{
				IEmployee employee = new Employee(words[1], Convert.ToDecimal(words[2]));
				ITaxTable taxTable = new TaxTable(employee.AnnualSalary);
				MonthlyPaySlip monthlyPaySlip = new MonthlyPaySlip(employee, taxTable);

				Console.WriteLine(string.Format("Monthly Payslip for: \"{0}\"", monthlyPaySlip.EmployeeName));
				Console.WriteLine(string.Format("Gross Monthly Income: ${0}", monthlyPaySlip.GrossMonthlyIncome.ToString()));
				Console.WriteLine(string.Format("Monthly Income Tax: ${0}", monthlyPaySlip.MonthlyIncomeTax.ToString()));
				Console.WriteLine(string.Format("Net Monthly Income: ${0}", monthlyPaySlip.NetMonthlyIncome.ToString()));
				Console.ReadLine();
			}
			else
			{
				Console.WriteLine("Unrecognized command");
			}
		}
	}
}
