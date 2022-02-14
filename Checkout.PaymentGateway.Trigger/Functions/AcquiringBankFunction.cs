using System.Linq;
using Checkout.Trigger.Models.Bank.Requests;
using Checkout.Helper.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Checkout.Trigger.Functions
{
    public class AcquiringBankFunction
    {
        private const int PermanentAccountNumberPrefixLength = 3;

        [FunctionName(nameof(CreatePayment))]
        public IActionResult CreatePayment(
            [HttpTrigger(
                AuthorizationLevel.Anonymous, 
                HttpMethods.Post,
                Route = "payments")]
            CreateAcquiringBankRequest createAcquringBankRequest)
        {
            string permanentAccountNumberPrefix =
                new string(
                    createAcquringBankRequest
                    .PaymentCard
                    .PermanentAccountNumber
                    .ToString()
                    .Take(PermanentAccountNumberPrefixLength)
                    .ToArray()
                );

            switch (permanentAccountNumberPrefix)
            {
                case PermanentAccountNumberPrefixes.Ok:
                    return new OkResult();
                case PermanentAccountNumberPrefixes.Invalid:
                default:
                    return new BadRequestResult();
            }
        }
    }
}
