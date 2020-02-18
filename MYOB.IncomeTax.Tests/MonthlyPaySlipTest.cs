using Moq;
using Xunit;

namespace MYOB.IncomeTax.Tests
{
	public class MonthlyPaySlipTest
	{
		[Fact]
		public void EmployeeName_ReturnsEmployeeName()
		{
			var mockEmployee = new Mock<IEmployee>();
            mockEmployee.SetupGet(e => e.Name).Returns("Ren");
			mockEmployee.SetupGet(e => e.AnnualSalary).Returns(120000);

			var mockTaxTable = new Mock<ITaxTable>();
			mockTaxTable.Setup(t => t.ComputeIncomeTax()).Returns(12000);

			var monthlyPaySlip = new MonthlyPaySlip(mockEmployee.Object, mockTaxTable.Object);

			Assert.Equal("Ren", monthlyPaySlip.EmployeeName);
			Assert.Equal(10000, monthlyPaySlip.GrossMonthlyIncome);
			Assert.Equal(1000, monthlyPaySlip.MonthlyIncomeTax);
			Assert.Equal(9000, monthlyPaySlip.NetMonthlyIncome);
		}
	}
}