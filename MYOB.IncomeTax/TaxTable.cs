
using System.Collections.Generic;

namespace MYOB.IncomeTax
{
  public class TaxTable
  {
    public TaxTable()
    {
      _taxTableItems = new List<TaxTableItem>()
      {
        new TaxTableItem(0, 20000, 0.0m, 0.0m),
        new TaxTableItem(20001, 40000, 0.1m, 2000.0m),
        new TaxTableItem(40001, 80000, 0.2m, 8000.0m),
        new TaxTableItem(80001, 180000, 0.3m, 30000.0m),
        new TaxTableItem(180001, null, 0.4m, null)
      };
    }

    private readonly List<TaxTableItem> _taxTableItems;
    public List<TaxTableItem> taxTableItems
    {
      get
      {
        return _taxTableItems;
      }
    }
  }
}
