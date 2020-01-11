using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicsBank.IdentityServer.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAdmin.Controllers
{
    [AllowAnonymous]
    public class ClientsController : Controller
    {
        private readonly IConfigurationService ConfigurationService;
        public ClientsController(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }
        public async Task<IActionResult> Search(string name, int page, int size)
        {
            var clients = await ConfigurationService.SearchClient(name, page, size);

            return View(clients);
        }
    }
}