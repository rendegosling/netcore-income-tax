using System;

namespace MYOB.IncomeTax
{
	public class TaxBracket
	{
		private const int MINIMUM_OPERAND_OFFSET = -1;

		public TaxBracket(int min = 0, int? max = 0, decimal rate = default(decimal), decimal? maxIncomeTax = 0)
		{
			Min = min;
			Max = max;
			Rate = rate;
			MaxIncomeTax = maxIncomeTax;
		}

		public int Min { get; set; }
		public int? Max { get; set; }
		public decimal Rate { get; set; }
		public decimal? MaxIncomeTax { get; set; }

		public decimal? IncomeTax(decimal annualSalary)
		{
			decimal? result = 0.0m;
			result = (Max == null | annualSalary < Max) ? TaxableAmount(annualSalary) * Rate : MaxIncomeTax;
			return result;
		}

		public decimal MinimumRangeOperand()
		{
			return Min + MINIMUM_OPERAND_OFFSET;
		}

		public decimal TaxableAmount(decimal annualSalary)
		{
			return annualSalary - MinimumRangeOperand();
		}


	}
}