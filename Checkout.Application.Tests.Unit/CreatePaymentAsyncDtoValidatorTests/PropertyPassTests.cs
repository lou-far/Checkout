using AutoFixture;
using AutoFixture.AutoMoq;
using Checkout.Application.Dto.PaymentModule.Inbound;
using Checkout.Application.Dto.PaymentModule.Inbound.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Checkout.Application.Tests.Unit.CreatePaymentAsyncDtoValidatorTests
{
    public class PropertyPassTests
    {
        private readonly IFixture _fixture;

        public PropertyPassTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1000)]
        public void Amount_WhenMoreThanZero_HasNoValidationError(
            int amount)
        {
            // Arrange
            CreatePaymentAsyncDto createPaymentAsyncDto = _fixture.Create<CreatePaymentAsyncDto>();
            CreatePaymentAsyncDtoValidator _createPaymentAsyncDtoValidator = _fixture.Create<CreatePaymentAsyncDtoValidator>();

            createPaymentAsyncDto.Amount = amount;

            // Act
            TestValidationResult<CreatePaymentAsyncDto> result =
                _createPaymentAsyncDtoValidator.TestValidate(createPaymentAsyncDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Amount);
        }
    }
}