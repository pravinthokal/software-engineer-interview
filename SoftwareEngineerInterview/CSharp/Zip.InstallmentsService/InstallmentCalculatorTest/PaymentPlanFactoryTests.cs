using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zip.InstallmentsService;

namespace InstallmentCalculatorTest
{
    [TestClass]
    public class PaymentPlanFactoryTests
    {
        [TestMethod]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();

            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            Assert.IsNotNull(paymentPlan);

            decimal exepctedAmount = 0;

            foreach (Installment installment in paymentPlan.Installments)
            {
                exepctedAmount += installment.Amount;               
            }

            Assert.AreEqual(exepctedAmount, 123.45M);
            // Assert
            
        }
    }
}
