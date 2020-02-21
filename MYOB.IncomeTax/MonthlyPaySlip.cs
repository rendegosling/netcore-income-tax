using System;

namespace MYOB.IncomeTax
{
  public class MonthlyPaySlip
  {
    private const decimal TWELVE_MONTHS = 12.0m;

    public MonthlyPaySlip(IEmployee employee, IComputeIncomeTaxCommand computeIncomeTaxCommandCommand)
    {
      _employee = employee;
      _computeIncomeTaxCommandCommand = computeIncomeTaxCommandCommand;
    }
    private readonly IEmployee _employee;

    private readonly IComputeIncomeTaxCommand _computeIncomeTaxCommandCommand;

    public string EmployeeName
    {
      get
      {
        return _employee.Name;
      }
    }

    public decimal GrossMonthlyIncome
    {
      get
      {
        return ComputeGrossMonthlyIncome();
      }
    }

    public decimal MonthlyIncomeTax
    {
      get
      {
        return ComputeMonthlyIncomeTax();
      }
    }

    public decimal NetMonthlyIncome
    {
      get
      {
        return ComputeNetMonthlyIncome();
      }
    }

    private decimal ComputeGrossMonthlyIncome()
    {
      return _employee.AnnualSalary / TWELVE_MONTHS;
    }

    private decimal ComputeMonthlyIncomeTax()
    {
      return _computeIncomeTaxCommandCommand.Call() / TWELVE_MONTHS;
    }

    private decimal ComputeNetMonthlyIncome()
    {
      return GrossMonthlyIncome - MonthlyIncomeTax;
    }
  }
}