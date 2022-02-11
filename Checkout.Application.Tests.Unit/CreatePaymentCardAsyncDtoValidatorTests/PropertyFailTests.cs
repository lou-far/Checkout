using AutoFixture;
using AutoFixture.AutoMoq;
using Checkout.Application.Dto.PaymentModule.Inbound;
using Checkout.Application.Dto.PaymentModule.Inbound.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Checkout.Application.Tests.Unit.CreatePaymentCardAsyncDtoValidatorTests
{
    public class PropertyFailTests
    {
        private readonly IFixture _fixture;
        private readonly CreatePaymentCardAsyncDto _createPaymentCardAsyncDto;
        private readonly CreatePaymentCardAsyncDtoValidator _createPaymentCardAsyncDtoValidator;

        public PropertyFailTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());

            _createPaymentCardAsyncDto = _fixture.Create<CreatePaymentCardAsyncDto>();
            _createPaymentCardAsyncDtoValidator = _fixture.Create<CreatePaymentCardAsyncDtoValidator>();
        }

        [Fact]
        public void CardholderName_WhenEmptyString_HasValidationError()
        {
            // Arrange
            _createPaymentCardAsyncDto.CardholderName = string.Empty;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CardholderName);
        }

        [Theory]
        [InlineData("00")]
        [InlineData("13")]
        public void ExpiresOnMonth_WhenNotNumericMonthValue_HasValidationError(
            string expiresOnMonth)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnMonth = expiresOnMonth;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ExpiresOnMonth);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("111")]
        public void ExpiresOnMonth_WhenNotCorrectLength_HasValidationError(
            string expiresOnMonth)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnMonth = expiresOnMonth;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ExpiresOnMonth);
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("AB")]
        [InlineData("!!")]
        public void ExpiresOnMonth_WhenNotCorrectFormat_HasValidationError(
            string expiresOnMonth)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnMonth = expiresOnMonth;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ExpiresOnMonth);
        }

        [Theory]
        [InlineData("20")]
        [InlineData("21")]
        [InlineData("28")]
        [InlineData("29")]
        public void ExpiresOnYear_WhenNotInValidRange_HasValidationError(
            string expiresOnYear)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnYear = expiresOnYear;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ExpiresOnYear);
        }

        [Theory]
        [InlineData("")]
        [InlineData("2")]
        [InlineData("222")]
        public void ExpiresOnYear_WhenNotCorrectLength_HasValidationError(
            string expiresOnYear)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnYear = expiresOnYear;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ExpiresOnYear);
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("AB")]
        [InlineData("!!")]
        public void ExpiresOnYear_WhenNotCorrectFormat_HasValidationError(
            string expiresOnYear)
        {
            // Arrange
            _createPaymentCardAsyncDto.ExpiresOnYear = expiresOnYear;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ExpiresOnYear);
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("00")]
        [InlineData("0000")]
        public void CardVerificationValue_WhenNotCorrectLength_HasValidationError(
            string cardVerificationValue)
        {
            // Arrange
            _createPaymentCardAsyncDto.CardVerificationValue = cardVerificationValue;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CardVerificationValue);
        }

        [Theory]
        [InlineData("A11")]
        [InlineData("ABC")]
        [InlineData("!!!")]
        public void CardVerificationValue_WhenNotCorrectFormat_HasValidationError(
            string cardVerificationValue)
        {
            // Arrange
            _createPaymentCardAsyncDto.CardVerificationValue = cardVerificationValue;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CardVerificationValue);
        }

        [Theory]
        [InlineData("000000000000000")]
        [InlineData("00000000000000000")]
        public void PermanentAccountNumber_WhenNotCorrectLength_HasValidationError(
            string permanentAccountNumber)
        {
            // Arrange
            _createPaymentCardAsyncDto.PermanentAccountNumber = permanentAccountNumber;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.PermanentAccountNumber);
        }

        [Theory]
        [InlineData("A000000000000000")]
        [InlineData("ABCDEFGHIJKLMNOP")]
        [InlineData("!!!!!!!!!!!!!!!!")]
        public void PermanentAccountNumber_WhenNotCorrectFormat_HasValidationError(
            string permanentAccountNumber)
        {
            // Arrange
            _createPaymentCardAsyncDto.PermanentAccountNumber = permanentAccountNumber;

            // Act
            TestValidationResult<CreatePaymentCardAsyncDto> result =
                _createPaymentCardAsyncDtoValidator.TestValidate(_createPaymentCardAsyncDto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.PermanentAccountNumber);
        }
    }
}
