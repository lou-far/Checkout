using AutoFixture;
using AutoFixture.AutoMoq;
using Checkout.Application.Dto.PaymentModule.Inbound;
using Checkout.Application.Dto.PaymentModule.Inbound.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Checkout.Application.Tests.Unit.CreatePaymentCardAsyncDtoValidatorTests
{
    public class PropertyPassTests
    {
        private readonly IFixture _fixture;
        private readonly CreatePaymentCardAsyncDto _createPaymentCardAsyncDto;
        private readonly CreatePaymentCardAsyncDtoValidator _createPaymentCardAsyncDtoValidator;

        public PropertyPassTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());

            _createPaymentCardAsyncDto = _fixture.Create<CreatePaymentCardAsyncDto>();
            _createPaymentCardAsyncDtoValidator = _fixture.Create<CreatePaymentCardAsyncDtoValidator>();
        }

        [Theory]
        [InlineData("A")]
        [InlineData("MR JOE BLOGGS")]
        public void CardholderName_WhenLengthGreaterThanZero_HasNoValidationError(
            string cardholderName)
        {
            // Arrange
            _createPaymentCardAsyncDto.CardholderName = cardholderName;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CardholderName);
        }

        [Theory]
        [InlineData("01")]
        [InlineData("02")]
        [InlineData("03")]
        [InlineData("04")]
        [InlineData("05")]
        [InlineData("06")]
        [InlineData("07")]
        [InlineData("08")]
        [InlineData("09")]
        [InlineData("10")]
        [InlineData("11")]
        [InlineData("12")]
        public void ExpiresOnMonth_WhenValueIsNumericMonth_HasNoValidationError(
            string expiresOnMonth)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnMonth = expiresOnMonth;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ExpiresOnMonth);
        }

        [Theory]
        [InlineData("22")]
        [InlineData("23")]
        [InlineData("24")]
        [InlineData("25")]
        [InlineData("26")]
        [InlineData("27")]
        public void ExpiresOnYear_WhenValueIsNumericYearInValidRange_HasNoValidationError(
            string expiresOnYear)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnYear = expiresOnYear;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ExpiresOnYear);
        }

        [Theory]
        [InlineData("000")]
        [InlineData("001")]
        [InlineData("998")]
        [InlineData("999")]
        public void CardVerificationValue_WhenValueIsCorrectLength_HasNoValidationError(
            string cardVerificationValue)
        {
            // Arrange
            _createPaymentCardAsyncDto.CardVerificationValue = cardVerificationValue;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CardVerificationValue);
        }

        [Theory]
        [InlineData("0000000000000000")]
        [InlineData("9999999999999999")]
        public void PermanentAccountNumber_WhenValueIsCorrectLength_HasNoValidationError(
            string permanentAccountNumber)
        {
            // Arrange
            _createPaymentCardAsyncDto.PermanentAccountNumber = permanentAccountNumber;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.PermanentAccountNumber);
        }
    }
}