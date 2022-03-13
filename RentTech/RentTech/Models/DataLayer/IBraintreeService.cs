using Braintree;

namespace RentTech.Models.DataLayer
{
    public interface IBraintreeService
    {
        IBraintreeGateway CreateGateway(); 
        IBraintreeGateway GetGateway();
    }
}
