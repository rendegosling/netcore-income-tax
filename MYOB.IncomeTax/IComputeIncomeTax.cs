using System;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.IncomeTax
{
  public interface IComputeIncomeTaxCommand
  {
    decimal Call();
  }
}