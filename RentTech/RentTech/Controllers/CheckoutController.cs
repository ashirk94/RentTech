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
        public IActionResult Purchase() //int id
        {
            //var item = _techRepository.GetById(id);
            //if (item == null) return NotFound();

            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            ViewBag.ClientToken = clientToken;

            var data = new TechItemVM
            {
                ItemId = 1,
                Title = "thing",
                Description = "a thing",
                OwnerId = 1,
                Nonce = ""
            };

            return View(data);
        }
    }
}
