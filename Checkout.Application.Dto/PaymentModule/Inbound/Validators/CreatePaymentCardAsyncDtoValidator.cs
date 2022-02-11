using System;
using FluentValidation;

namespace Checkout.Application.Dto.PaymentModule.Inbound.Validators
{
    public class CreatePaymentCardAsyncDtoValidator : AbstractValidator<CreatePaymentCardAsyncDto>
    {
        public CreatePaymentCardAsyncDtoValidator()
        {
            RuleFor(x => x.CardholderName)
                .NotEmpty();

            RuleFor(x => x.ExpiresOnMonth)
                .Length(2)
                .Must(x => int.TryParse(x, out int value) && value > default(int) && value <= 12);

            RuleFor(x => x.ExpiresOnYear)
                .Length(2)
                .Must(x =>
                    int.TryParse(x, out int value) &&
                    value >= int.Parse(DateTime.UtcNow.ToString("yy")) &&
                    value <= int.Parse(DateTime.UtcNow.ToString("yy")) + 5);

            RuleFor(x => x.CardVerificationValue)
                .Length(3)
                .Must(x => int.TryParse(x, out int value));

            RuleFor(x => x.PermanentAccountNumber)
                .Length(16)
                .Must(x => long.TryParse(x, out long value));
        }
    }
}
