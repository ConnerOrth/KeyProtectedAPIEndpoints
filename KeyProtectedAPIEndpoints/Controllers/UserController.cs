using KeyProtectedAPIEndpoints.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KeyProtectedAPIEndpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.HasAPIKey)]
    public class UserController : ControllerBase
    {
        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult CreateKey(string owner, string roles)
        {
            var inMemoryStore = new InMemoryGetApiKeyQuery();
            owner ??= "internal-only";
            roles ??= "";
            ApiKey key = new ApiKey(inMemoryStore.GetNextId, owner, APIKeyGenerator.Instance.Next, DateTime.Now, roles.Split(';'));
            new InMemoryGetApiKeyQuery().AddKey(key);
            return new JsonResult(key);
        }

        [HttpGet("anyone")]
        public IActionResult Anyone()
        {
            var message = $"Hello from {nameof(Anyone)}";
            return new ObjectResult(message);
        }

        [HttpGet("only-authenticated")]
        public IActionResult OnlyAuthenticated()
        {
            var message = $"Hello from {nameof(OnlyAuthenticated)}";
            return new ObjectResult(message);
        }

        [HttpGet("only-employees")]
        public IActionResult OnlyEmployees()
        {
            var message = $"Hello from {nameof(OnlyEmployees)}";
            return new ObjectResult(message);
        }

        [HttpGet("only-managers")]
        public IActionResult OnlyManagers()
        {
            var message = $"Hello from {nameof(OnlyManagers)}";
            return new ObjectResult(message);
        }

        [HttpGet("only-third-parties")]
        [HttpGet("key")]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public IActionResult OnlyThirdParties()
        {
            var message = $"Hello from {nameof(OnlyThirdParties)}";
            return new ObjectResult(message);
        }
    }
}
