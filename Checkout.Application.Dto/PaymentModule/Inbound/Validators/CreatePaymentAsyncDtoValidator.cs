using System;
using FluentValidation;

namespace Checkout.Application.Dto.PaymentModule.Inbound.Validators
{
    public class CreatePaymentAsyncDtoValidator : AbstractValidator<CreatePaymentAsyncDto>
    {
        public CreatePaymentAsyncDtoValidator(
            IValidator<CreatePaymentCardAsyncDto> createPaymentCardAsyncDtoValidator)
        {
            RuleFor(x => x.Amount)
                .GreaterThan(default(int));

            RuleFor(x => x.PaymentCard)
                .NotEmpty()
                .SetValidator(createPaymentCardAsyncDtoValidator);
        }
    }
}
