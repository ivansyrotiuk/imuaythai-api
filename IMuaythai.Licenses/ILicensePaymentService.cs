using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Licenses;
using IMuaythai.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestEase;

namespace IMuaythai.Licenses
{
    public interface ILicensePaymentService
    {
        Task<LicensePayment> GetPayment(int licenseId, ApplicationUser user);
        Task ConfirmPayment(PaymentStatus paymentStatus);
    }

    public class LicensePaymentService : ILicensePaymentService
    {
        private readonly IPaymentSigner _paymentSigner;
        private readonly ILicensesRepository _licensesRepository;
        private readonly ILicenseTypesRepository _licenseTypesRepository;
        private readonly ILogger _logger;
        private readonly IPayments24Client _payments24Client;
        private readonly PaymentsConfiguration _paymentsConfiguration;

        public LicensePaymentService(PaymentsConfiguration configuration, ILoggerFactory loggerFactory, IPaymentSigner paymentSigner, ILicensesRepository licensesRepository, IPayments24Client payments24Client, ILicenseTypesRepository licenseTypesRepository)
        {
            _paymentSigner = paymentSigner;
            _licensesRepository = licensesRepository;
            _payments24Client = payments24Client;
            _licenseTypesRepository = licenseTypesRepository;
            _paymentsConfiguration = configuration;
            _logger = loggerFactory.CreateLogger<LicensePaymentService>();
        }

        public async Task<LicensePayment> GetPayment(int licenseId, ApplicationUser user)
        {
            var license = await _licensesRepository.GetLicense(licenseId);
            var licenseType = await _licenseTypesRepository.Get(license.LicenseTypeId);
            var amount = (int)(license.Price * 100);
            var payment = new LicensePayment
            {
                Currency = license.Currency,
                Address = "-",
                Amount = amount,
                City = "-",
                Client = $"{user.FirstName} {user.Surname}",
                Description = LicenseTypeNameResolver.ResolveLicenseTypeName(licenseType),
                Email = user.Email,
                Language = "pl",
                Country = "PL",
                MerchantId = _paymentsConfiguration.MerchantId,
                PosId = _paymentsConfiguration.PosId,
                UrlReturn = _paymentsConfiguration.UrlReturn,
                UrlStatus = _paymentsConfiguration.UrlStatus,
                SessionId = license.Id,
                Sign = _paymentSigner.SignPayment(license.Id, _paymentsConfiguration.MerchantId, amount, license.Currency, _paymentsConfiguration.CRC),
                ZipCode = "31-001",
                PaymentsUrl = _paymentsConfiguration.PaymentsUrl
            };

            return payment;
        }

        public async Task ConfirmPayment(PaymentStatus status)
        {
            var form = new Dictionary<string, object>
            {
                {"p24_merchant_id", status.p24_merchant_id},
                {"p24_pos_id", status.p24_pos_id},
                {"p24_session_id", status.p24_session_id},
                {"p24_amount", status.p24_amount},
                {"p24_currency", status.p24_currency},
                {"p24_order_id", status.p24_order_id},
                {"p24_sign", status.p24_sign}
            };

            var response = await _payments24Client.Pay(form);
            var message = $"{response.ResponseMessage.StatusCode} ({response.StringContent})";

            LogResponse(message);

            if (!response.ResponseMessage.IsSuccessStatusCode)
            {
                return;
            }

            var license = await _licensesRepository.GetLicense(int.Parse(status.p24_session_id));
            license.Paid = true;
            license.PaymentMethod = status.p24_method;
            license.OrderId = status.p24_order_id.ToString();
            await _licensesRepository.Save(license);
        }

        private void LogResponse(string message)
        {
            Console.WriteLine(message);
            _logger.Log(LogLevel.Debug, message);
        }
    }
}