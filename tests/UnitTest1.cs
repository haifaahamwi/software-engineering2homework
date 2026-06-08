using Xunit;
using MathLibrary;
using System;

namespace MathLibrary.Tests
{
    public class BillingServiceTests
    {
        private readonly BillingService _billingService = new BillingService();

        [Fact]
        public void CalculateBill_VIPWithCash_ReturnsCorrectAmount()
        {
            double result = _billingService.CalculateBill("VIP", "Cash", 100, false);
            Assert.Equal(80, result);
        }

        [Fact]
        public void CalculateBill_RegularWithApprovedInsurance_ReturnsHalfAmount()
        {
            double result = _billingService.CalculateBill("Regular", "Insurance", 100, true);
            Assert.Equal(50, result);
        }

        [Fact]
        public void CalculateBill_InsuranceNotApproved_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => 
                _billingService.CalculateBill("Regular", "Insurance", 100, false));
        }
    }
}