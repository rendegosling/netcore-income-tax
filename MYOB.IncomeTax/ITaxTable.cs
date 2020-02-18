using System;

namespace MYOB.IncomeTax
{
	public interface ITaxTable
	{
		decimal AnnualSalary { get; }

        decimal ComputeIncomeTax();
    }
}
