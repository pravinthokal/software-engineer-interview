using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService;

namespace InstallmentCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the order amount\n");
            decimal orderAmount = 0;
            try
            {
                orderAmount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           

            PaymentPlanFactory paymentPlanFactory = new PaymentPlanFactory();
            PaymentPlan paymentPlan = paymentPlanFactory.CreatePaymentPlan(orderAmount);

            Console.WriteLine("\nPaymentPlan Id => {0}", paymentPlan.Id);
            Console.WriteLine("\nOrder Amount => {0}", Math.Round(paymentPlan.PurchaseAmount,2));
            Console.WriteLine("\nFollowing are installment details =>");
            foreach (Installment installment in paymentPlan.Installments)
            {
                Console.WriteLine("\n Installment Id => {0}", installment.Id);
                Console.WriteLine("\n Installment Amount => {0}", installment.Amount);
                Console.WriteLine("\n Installment Due Date => {0}", installment.DueDate);
                Console.WriteLine("\n");
            }

            Console.ReadLine();
        }
    }
}
