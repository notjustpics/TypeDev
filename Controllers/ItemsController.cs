using Microsoft.AspNetCore.Mvc;
using TypeDevApp.Interfaces;

namespace TypeDevApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        // Implement CRUD actions here
    }
}
