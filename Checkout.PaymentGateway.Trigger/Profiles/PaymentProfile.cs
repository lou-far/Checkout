﻿using System;
using AutoMapper;
using Checkout.PaymentGateway.Trigger.Models.Payment.Requests;
using Checkout.PaymentGateway.Trigger.Models.Payment.Responses;

using Inbound = Checkout.Application.Dto.PaymentModule.Inbound;
using Outbound = Checkout.Application.Dto.PaymentModule.Outbound;

namespace Checkout.PaymentGateway.Trigger.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CreatePaymentAsyncRequest, Inbound.CreatePaymentAsyncDto>();
            CreateMap<CreatePaymentCardAsyncRequest, Inbound.CreatePaymentCardAsyncDto>();

            CreateMap<Outbound.CreatePaymentAsyncDto, CreatePaymentAsyncResponse>();

            CreateMap<Outbound.GetPaymentInformationAsyncDto, GetPaymentInformationAsyncResponse>();
            CreateMap<Outbound.GetPaymentCardInformationAsyncDto, GetPaymentCardInformationAsyncResponse>();
        }
    }
}
