using System.Threading.Tasks;
using AutoMapper;
using Checkout.Application.Interfaces.PaymentModule;
using Checkout.PaymentGateway.Trigger.Models.Payment.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using Inbound = Checkout.Application.Dto.PaymentModule.Inbound;
using Outbound = Checkout.Application.Dto.PaymentModule.Outbound;

namespace Checkout.PaymentGateway.Trigger
{
    public class PaymentGatewayFunction
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentGatewayFunction(
            IMapper mapper,
            IPaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }

        [FunctionName(nameof(GetPaymentInformationAsync))]
        public async Task<IActionResult> GetPaymentInformationAsync(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                Helper.Constants.HttpMethods.Get,
                Route = "merchants/{merchantId}/payments/{paymentId}")]
            HttpRequest httpRequest,
            int merchantId,
            int paymentId)
        {
            _ = httpRequest;

            Inbound.GetPaymentInformationAsyncDto inboundGetPaymentInformationAsyncDto =
                new Inbound.GetPaymentInformationAsyncDto(
                    merchantId,
                    paymentId);

            Outbound.GetPaymentInformationAsyncDto outboundGetPaymentInformationAsyncDto =
                await _paymentService.GetAsync(inboundGetPaymentInformationAsyncDto);

            GetPaymentInformationAsyncResponse getPaymentInformationAsyncResponse =
                _mapper.Map<GetPaymentInformationAsyncResponse>(outboundGetPaymentInformationAsyncDto);

            return new OkObjectResult(getPaymentInformationAsyncResponse);
        }
    }
}
