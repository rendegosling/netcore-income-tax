using System;

namespace MYOB.IncomeTax
{
  public class TaxTableItem
  {
    private const int MINIMUM_OPERAND_OFFSET = -1;

    public TaxTableItem(int min = 0, int? max = 0, decimal rate = default(decimal), decimal? maxIncomeTax = 0)
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

      // annualSalary = 20001
    }

    public decimal MinimumRangeOperand()
    {
      // 20001 + -1
      return Min + MINIMUM_OPERAND_OFFSET;
    }

    public decimal TaxableAmount(decimal annualSalary)
    {
      // 20001 - 2000 = 1
      return annualSalary - MinimumRangeOperand();
    }


  }
}