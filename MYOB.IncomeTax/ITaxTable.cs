using System;

namespace MYOB.IncomeTax
{
  public interface ITaxTable
  {
    decimal ComputeIncomeTaxCommand();
  }
}
