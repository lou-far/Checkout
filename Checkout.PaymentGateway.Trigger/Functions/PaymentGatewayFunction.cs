using System.Threading.Tasks;
using AutoMapper;
using Checkout.Application.Interfaces.PaymentModule;
using Checkout.Trigger.Models.Payment.Requests;
using Checkout.Trigger.Models.Payment.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using Inbound = Checkout.Application.Dto.PaymentModule.Inbound;
using Outbound = Checkout.Application.Dto.PaymentModule.Outbound;

namespace Checkout.Trigger
{
    public class PaymentGatewayFunction
    {
        private readonly IPaymentCreateService _paymentCreateService;
        private readonly IPaymentGetService _paymentGetService;
        private readonly IMapper _mapper;

        public PaymentGatewayFunction(
            IMapper mapper,
            IPaymentCreateService paymentCreateService,
            IPaymentGetService paymentGetService)
        {
            _mapper = mapper;
            _paymentCreateService = paymentCreateService;
            _paymentGetService = paymentGetService;
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
                await _paymentGetService.GetAsync(inboundGetPaymentInformationAsyncDto);

            GetPaymentInformationAsyncResponse getPaymentInformationAsyncResponse =
                _mapper.Map<GetPaymentInformationAsyncResponse>(outboundGetPaymentInformationAsyncDto);

            return new OkObjectResult(getPaymentInformationAsyncResponse);
        }

        [FunctionName(nameof(CreatePaymentAsync))]
        public async Task<IActionResult> CreatePaymentAsync(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                Helper.Constants.HttpMethods.Post,
                Route = "merchants/{merchantId}/payments")]
            [FromBody] CreatePaymentAsyncRequest createPaymentAsyncRequest)
        {
            Inbound.CreatePaymentAsyncDto inboundCreatePaymentAsyncDto =
                _mapper.Map<Inbound.CreatePaymentAsyncDto>(createPaymentAsyncRequest);

            Outbound.CreatePaymentAsyncDto outboundCreatePaymentAsyncDto =
                await _paymentCreateService.CreateAsync(inboundCreatePaymentAsyncDto);

            CreatePaymentAsyncResponse createPaymentAsyncResponse =
                _mapper.Map<CreatePaymentAsyncResponse>(outboundCreatePaymentAsyncDto);

            return new OkObjectResult(createPaymentAsyncResponse);
        }
    }
}
