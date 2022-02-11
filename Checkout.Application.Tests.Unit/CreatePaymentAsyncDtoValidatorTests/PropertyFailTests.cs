using AutoFixture;
using AutoFixture.AutoMoq;
using Checkout.Application.Dto.PaymentModule.Inbound;
using Checkout.Application.Dto.PaymentModule.Inbound.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Checkout.Application.Tests.Unit.CreatePaymentAsyncDtoValidatorTests
{
    public class PropertyFailTests
    {
        private readonly IFixture _fixture;

        public PropertyFailTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        public void Amount_WhenLessThanOne_HasValidationError(
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
            result.ShouldHaveValidationErrorFor(x => x.Amount);
        }
    }
}