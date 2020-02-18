using Xunit;

namespace MYOB.IncomeTax.Tests
{
	public class TaxTableTest
	{
		[Fact]
		public void ComputeIncomeTax_Returns6000On60000AnnualSalary()
		{
			var taxTable = new TaxTable(60000);
			var actual = taxTable.ComputeIncomeTax();
			Assert.Equal(6000.0m, actual);
		}

		[Fact]
		public void ComputeIncomeTax_Returns10000On80000AnnualSalary()
		{
			var taxTable = new TaxTable(80000);
			var actual = taxTable.ComputeIncomeTax();
			Assert.Equal(10000.0m, actual);
		}

		[Fact]
		public void ComputeIncomeTax_Returns48000On200000AnnualSalary()
		{
			var taxTable = new TaxTable(200000);
			var actual = taxTable.ComputeIncomeTax();
			Assert.Equal(48000.0m, actual);
		}

		[Fact]
		public void ComputeIncomeTax_Returns0On0AnnualSalary()
		{
			var taxTable = new TaxTable(0);
			var actual = taxTable.ComputeIncomeTax();
			Assert.Equal(0.0m, actual);
		}
	}
}