using Xunit;

namespace MYOB.IncomeTax.Tests
{
  public class taxTableItemTest
  {
    [Fact]
    public void MinimumRangeOperand_ReturnsDifferenceMinAndOffset()
    {
      var taxTableItem = new TaxTableItem(20001, 40000, 0.1m, 2000.0m);
      var actual = taxTableItem.MinimumRangeOperand();
      Assert.Equal(20000, actual);
    }

    [Fact]
    public void TaxableAmount_ReturnsDifferenceOfAnnualSalaryAndMinimumOperand()
    {
      var taxTableItem = new TaxTableItem(20001, 40000, 0.1m, 2000.0m);
      var actual = taxTableItem.TaxableAmount(20100);
      Assert.Equal(100, actual);
    }

    [Fact]
    public void IncomeTax_ReturnsProductOfTaxableAmountAndRate()
    {
      var taxTableItem = new TaxTableItem(0, 20000, 0.0m, 0.0m);
      var actual = taxTableItem.IncomeTax(50);
      Assert.Equal(0, actual);

      taxTableItem = new TaxTableItem(20001, 40000, 0.1m, 2000.0m);
      actual = taxTableItem.IncomeTax(20001);
      Assert.Equal(0.1m, actual);

      taxTableItem = new TaxTableItem(180001, null, 0.4m, null);
      actual = taxTableItem.IncomeTax(200000);
      Assert.Equal(8000.0m, actual);

      taxTableItem = new TaxTableItem(40001, 80000, 0.2m, 8000.0m);
      actual = taxTableItem.IncomeTax(60000);
      Assert.Equal(4000.0m, actual);
    }
  }
}