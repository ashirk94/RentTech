using Braintree;
using Microsoft.AspNetCore.Mvc;
using RentTech.Models.DataLayer;
using RentTech.Models.DomainModels;
using RentTech.Models.ViewModels;

namespace RentTech.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ITechRepository _techRepository;
        private readonly IBraintreeService _braintreeService;

        public CheckoutController(ITechRepository techRepository, IBraintreeService braintreeService)
        {
            _techRepository = techRepository;
            _braintreeService = braintreeService;
        }
        public async Task<IActionResult> Purchase(int id) 
        {
            var item = await _techRepository.GetById(id);
            if (item == null) return NotFound();

            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            ViewBag.ClientToken = clientToken;

            var data = new TechItemVM
            {
                ItemId = id,
                Title = item.Title,
                Description = item.Description,
                Nonce = ""
            };

            return View(data);
        }
        public async Task<IActionResult> Create(TechItemVM model)
        {
            var gateway = _braintreeService.GetGateway();
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
