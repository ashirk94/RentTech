using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentTech.Models.DataLayer;
using RentTech.Models.DomainModels;
using RentTech.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace RentTech.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ITechRepository _techRepository;
        private readonly IBraintreeService _braintreeService;
        private readonly IConfiguration _configuration;

        public CheckoutController(ITechRepository techRepository, IBraintreeService braintreeService, IConfiguration configuration)
        {
            _techRepository = techRepository;
            _braintreeService = braintreeService;
            _configuration = configuration;
        }
        public async Task<IActionResult> Purchase(int id)
        {
            //braintree payment gateway with paypal

            var item = await _techRepository.GetById(id);
            if (item == null) return NotFound();

            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _configuration.GetValue("MerchantId", ""),
                PublicKey = _configuration.GetValue("PublicKey", ""),
                PrivateKey = _configuration.GetValue("PrivateKey", "")
            };
            var clientToken = gateway.ClientToken.Generate();
            ViewBag.ClientToken = clientToken;

            var data = new TechItemVM
            {
                ItemId = id,
                Title = item.Title,
                Description = item.Description,
                Price = item.Price,
                Thumbnail = item.Thumbnail,
                Nonce = ""
            };

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TechItemVM model)
        {
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _configuration.GetValue("MerchantId", ""),
                PublicKey = _configuration.GetValue("PublicKey", ""),
                PrivateKey = _configuration.GetValue("PrivateKey", "")
            };
            var item = await _techRepository.GetById(model.ItemId);

            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(item.Price),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                return View("Success");
            }
            else
            {
                return View("Failure");
            }
        }
    }
}
