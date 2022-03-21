using System.Threading.Tasks;
using RentTech.Models.DomainModels;
using RentTech.Models.DataLayer;
using RentTech.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class ItemTest
    {
        [Fact]
        public async Task AddItemTestAsync()
        {
            var fakeTechRepo = new FakeTechRepo();
            var controller = new TechItemsController(null, null, null, fakeTechRepo);

            //example items
            var item1 = new TechItem()
            {
                Title = "hello",
                TechItemId = 1,
                Description = "test",
                Type = "none",
                Condition = "perfect",
                Price = 50.0
            };
            var item2 = new TechItem()
            {
                Title = "world",
                TechItemId = 2,
                Description = "test",
                Type = "none",
                Condition = "perfect",
                Price = 50.0
            };
            //add to repo
            await fakeTechRepo.Insert(item1);
            await fakeTechRepo.Insert(item2);

            //actions
            var viewResult = (ViewResult)controller.Index(null);

            //assert tests - checking that enumerable "list" is not empty and null
            //was unable to grab the items to test them but they do appear in the viewdata in the debugger
            Assert.NotNull(viewResult.ViewData.Model);
            Assert.IsAssignableFrom<IEnumerable<TechItem>>(viewResult.ViewData.Model);
        }
    }
}