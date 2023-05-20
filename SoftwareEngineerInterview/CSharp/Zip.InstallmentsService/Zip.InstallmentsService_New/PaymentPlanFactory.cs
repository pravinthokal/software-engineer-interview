using System;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(decimal purchaseAmount)
        {
            int totalNoOfInstallment = 4;
            int installmentPeriod = 14;
            Installment installment = null;

            DateTime OrderDate = DateTime.UtcNow;            

            int emi = (int) purchaseAmount / totalNoOfInstallment;

            PaymentPlan paymentPlan = new PaymentPlan();
            paymentPlan.Id = Guid.NewGuid();
            paymentPlan.PurchaseAmount = purchaseAmount;
            paymentPlan.Installments = new Installment[totalNoOfInstallment];

            for (int installmentCounter =0; installmentCounter < totalNoOfInstallment; installmentCounter++)
            {
                installment = new Installment();
                installment.Id = Guid.NewGuid();
                installment.Amount = emi;
                installment.DueDate = OrderDate.AddDays(installmentPeriod * (installmentCounter + 1 ));
                paymentPlan.Installments[installmentCounter] = installment;                
            }

            paymentPlan.Installments[totalNoOfInstallment - 1].Amount = Math.Round(purchaseAmount - emi * (totalNoOfInstallment - 1),2) ;
            return paymentPlan;
        }
    }
}
