using System;
using MYOB.IncomeTax;

namespace MYOB.IncomeTax.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Type GenerateMonthlyPayslip \"YOUR NAME\" ANNUAL_SALARY to start..");
        string line = Console.ReadLine();
        string[] words = line.Split(' ');
        if (words[0] == "GenerateMonthlyPayslip")
        {
          var employee = new Employee(words[1], Convert.ToDecimal(words[2]));
          var taxTable = new TaxTable();
          var computeIncomeCommand = new ComputeIncomeTaxCommand(taxTable, employee.AnnualSalary);
          MonthlyPaySlip monthlyPaySlip = new MonthlyPaySlip(employee, computeIncomeCommand);
          Console.WriteLine(string.Format("Monthly Payslip for: \"{0:#.00}\"", monthlyPaySlip.EmployeeName));
          Console.WriteLine(string.Format("Gross Monthly Income: ${0:#.00}", monthlyPaySlip.GrossMonthlyIncome));
          Console.WriteLine(string.Format("Monthly Income Tax: ${0:#.00}", monthlyPaySlip.MonthlyIncomeTax));
          Console.WriteLine(string.Format("Net Monthly Income: ${0:#.00}", monthlyPaySlip.NetMonthlyIncome));
          Console.ReadLine();
        }
        else
        {
          Console.WriteLine("Unrecognized command");
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}
