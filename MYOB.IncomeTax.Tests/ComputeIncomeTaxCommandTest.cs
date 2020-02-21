using Xunit;

namespace MYOB.IncomeTax.Tests
{
  public class ComputeIncomeTaxCommandTest
  {
    [Theory]
    [InlineData(60000, 6000)]
    [InlineData(80000, 10000)]
    [InlineData(200000, 48000)]
    [InlineData(0, 0)]
    public void ComputeIncomeTaxCommand_ReturnsExpectedValue(decimal annual_salary, decimal expected_income_tax)
    {
      var taxTable = new TaxTable();
      var computeIncomeTaxCommand = new ComputeIncomeTaxCommand(taxTable, annual_salary);
      var actual = computeIncomeTaxCommand.Call();
      Assert.Equal(expected_income_tax, actual);
    }
  }
}