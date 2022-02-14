using Checkout.Application.Interfaces.PaymentModule;
using Checkout.Domain;
using Checkout.Domain.AcquiringBankModule.Repositories;
using Checkout.Domain.PaymentModule.Entities;
using Checkout.Domain.PaymentModule.Interfaces;
using Checkout.Domain.PaymentModule.Repositories;
using Checkout.Domain.PaymentModule.ValueObjects;
using Checkout.Helper.Enums;
using FluentValidation;

using Inbound = Checkout.Application.Dto.PaymentModule.Inbound;
using Outbound = Checkout.Application.Dto.PaymentModule.Outbound;

namespace Checkout.Application.PaymentModule
{
    public class PaymentService : IPaymentGetService, IPaymentCreateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentInformationQueryHandler _paymentInformationQueryHandler;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAcquiringBankRepository _acquiringBankRepository;
        private readonly IValidator<Inbound.CreatePaymentAsyncDto> _createPaymentAsyncDtoValidator;

        public PaymentService(
            IUnitOfWork unitOfWork,
            IPaymentInformationQueryHandler paymentInformationQueryHandler,
            IPaymentRepository paymentRepository,
            IAcquiringBankRepository acquiringBankRepository,
            IValidator<Inbound.CreatePaymentAsyncDto> createPaymentAsyncDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _paymentInformationQueryHandler = paymentInformationQueryHandler;
            _paymentRepository = paymentRepository;
            _acquiringBankRepository = acquiringBankRepository;
            _createPaymentAsyncDtoValidator = createPaymentAsyncDtoValidator;
        }

        public async Task<Outbound.GetPaymentInformationAsyncDto> GetAsync(
            Inbound.GetPaymentInformationAsyncDto inboundPaymentInformation)
        {
            PaymentInformation paymentInformation =
                await _paymentInformationQueryHandler.GetAsync(
                    inboundPaymentInformation.MerchantId,
                    inboundPaymentInformation.PaymentId);

            Outbound.GetPaymentInformationAsyncDto outboundPaymentInformation = new Outbound.GetPaymentInformationAsyncDto(
                paymentInformation.Amount,
                paymentInformation.PaymentStatus,
                paymentInformation.Currency,
                new Outbound.GetPaymentCardInformationAsyncDto(
                    paymentInformation.PaymentCard.MaskedPermanentAccountNumber,
                    paymentInformation.PaymentCard.CardholderName,
                    paymentInformation.PaymentCard.ExpiresOnMonth,
                    paymentInformation.PaymentCard.ExpiresOnYear,
                    paymentInformation.PaymentCard.CardVerificationValue)
                );

            return outboundPaymentInformation;
        }

        public async Task<Outbound.CreatePaymentAsyncDto> CreateAsync(
            Inbound.CreatePaymentAsyncDto createPayment)
        {
            await _createPaymentAsyncDtoValidator.ValidateAndThrowAsync(createPayment);

            bool isSuccessful = await _acquiringBankRepository.CreatePaymentAsync(
                new Services.Dto.AquiringBank.PaymentDto(
                createPayment.Amount,
                createPayment.Currency.ToString(),
                new Services.Dto.AquiringBank.PaymentCardDto(
                    createPayment.PaymentCard.PermanentAccountNumber,
                    createPayment.PaymentCard.CardholderName,
                    createPayment.PaymentCard.ExpiresOnMonth,
                    createPayment.PaymentCard.ExpiresOnYear,
                    createPayment.PaymentCard.CardVerificationValue)
                )
            );

            Payment payment = new Payment(
                    createPayment.MerchantId,
                    createPayment.Amount,
                    isSuccessful ? PaymentStatus.Successful : PaymentStatus.Failed,
                    createPayment.Currency,
                    new PaymentCard(
                        createPayment.PaymentCard.PermanentAccountNumber,
                        createPayment.PaymentCard.CardholderName,
                        createPayment.PaymentCard.ExpiresOnMonth,
                        createPayment.PaymentCard.ExpiresOnYear,
                        createPayment.PaymentCard.CardVerificationValue)
                    );

            await _paymentRepository.InsertAsync(payment);
            await _unitOfWork.CommitAsync();

            return new Outbound.CreatePaymentAsyncDto(
                payment.Id,
                isSuccessful);
        }
    }
}
