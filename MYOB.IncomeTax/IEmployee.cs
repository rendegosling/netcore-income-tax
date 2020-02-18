using System;

namespace MYOB.IncomeTax
{
	public interface IEmployee
	{
        string Name { get; set;}

		decimal AnnualSalary { get; set; }
    }
}
