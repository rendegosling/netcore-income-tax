using System;

namespace MYOB.IncomeTax
{
	public class MonthlyPaySlip
	{
		private const decimal TWELVE_MONTHS = 12.0m;

		public MonthlyPaySlip(IEmployee employee, ITaxTable taxTable)
		{
			_employee = employee;
			_taxTable = taxTable;
		}

		private IEmployee _employee;
		private ITaxTable _taxTable;

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
			return _taxTable.ComputeIncomeTax() / TWELVE_MONTHS;
		}

		private decimal ComputeNetMonthlyIncome()
		{
			return GrossMonthlyIncome - MonthlyIncomeTax;
		}
	}
}