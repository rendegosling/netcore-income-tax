using System;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.IncomeTax
{
  public class ComputeIncomeTaxCommand : IComputeIncomeTaxCommand
  {
    public ComputeIncomeTaxCommand(TaxTable taxTable, decimal annualSalary)
    {
      _taxTable = taxTable;
      _annualSalary = annualSalary;
    }

    private TaxTable _taxTable;
    private decimal _annualSalary;


    public decimal Call()
    {
      var taxTableItems = FindtaxTableItemRange();
      var totalIncomeTax = taxTableItems.Sum(taxTableItem => taxTableItem.IncomeTax(_annualSalary));
      return totalIncomeTax ?? 0.0m;
    }

    private List<TaxTableItem> FindtaxTableItemRange()
    {
      return _taxTable.taxTableItems.FindAll(taxTableItem => taxTableItem.Min < _annualSalary);
    }

  }
}