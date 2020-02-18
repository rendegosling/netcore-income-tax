using Xunit;

namespace MYOB.IncomeTax.Tests
{
	public class TaxBracketTest
	{
		[Fact]
		public void MinimumRangeOperand_ReturnsDifferenceMinAndOffset()
		{
			var taxBracket = new TaxBracket(20001, 40000, 0.1m, 2000.0m);
			var actual = taxBracket.MinimumRangeOperand();
			Assert.Equal(20000, actual);
		}

		[Fact]
		public void TaxableAmount_ReturnsDifferenceOfAnnualSalaryAndMinimumOperand()
		{
			var taxBracket = new TaxBracket(20001, 40000, 0.1m, 2000.0m);
			var actual = taxBracket.TaxableAmount(20100);
			Assert.Equal(100, actual);
		}

		[Fact]
		public void IncomeTax_ReturnsProductOfTaxableAmountAndRate()
		{
			var taxBracket = new TaxBracket(0, 20000, 0.0m, 0.0m);
			var actual = taxBracket.IncomeTax(50);
			Assert.Equal(0, actual);

			taxBracket = new TaxBracket(20001, 40000, 0.1m, 2000.0m);
			actual = taxBracket.IncomeTax(20001);
			Assert.Equal(0.1m, actual);

			taxBracket = new TaxBracket(180001, null, 0.4m, null);
			actual = taxBracket.IncomeTax(200000);
			Assert.Equal(8000.0m, actual);

			taxBracket = new TaxBracket(40001, 80000, 0.2m, 8000.0m);
			actual = taxBracket.IncomeTax(60000);
			Assert.Equal(4000.0m, actual);
		}
	}
}