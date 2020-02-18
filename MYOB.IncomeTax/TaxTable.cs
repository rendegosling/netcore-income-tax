using System;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.IncomeTax
{
	public class TaxTable : ITaxTable
	{
		public TaxTable(decimal annualSalary)
		{
			_annualSalary = annualSalary;
			RegisterTaxBrackets();
		}

		private List<TaxBracket> _taxBrackets;
		private decimal _annualSalary;
		public decimal AnnualSalary {
			get
			{
				return _annualSalary;
			}
		}

		public decimal ComputeIncomeTax()
		{
			var taxBrackets = FindTaxBracketRange();
			var totalIncomeTax = taxBrackets.Sum(taxBracket => taxBracket.IncomeTax(_annualSalary));
			return totalIncomeTax ?? 0.0m;
		}

		private List<TaxBracket> FindTaxBracketRange()
		{
			return _taxBrackets.FindAll(taxBracket => taxBracket.Min < _annualSalary);
		}

		private void RegisterTaxBrackets()
		{
			_taxBrackets = new List<TaxBracket>();
			_taxBrackets.Add(new TaxBracket(0, 20000, 0.0m,0.0m));
			_taxBrackets.Add(new TaxBracket(20001, 40000, 0.1m, 2000.0m));
			_taxBrackets.Add(new TaxBracket(40001, 80000, 0.2m, 8000.0m));
			_taxBrackets.Add(new TaxBracket(80001, 180000, 0.3m, 30000.0m));
			_taxBrackets.Add(new TaxBracket(180001, null, 0.4m, null));
		}
	}
}
