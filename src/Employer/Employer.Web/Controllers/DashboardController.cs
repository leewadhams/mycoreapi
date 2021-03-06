using Esfa.Recruit.Employer.Web.Configuration;
using Esfa.Recruit.Employer.Web.Models;
using Esfa.Recruit.Employer.Web.Orchestrators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Esfa.Recruit.Employer.Web.Controllers
{
    [Route("accounts/{employerAccountId}")]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly DashboardOrchestrator _orchestrator;

        public DashboardController(ILogger<DashboardController> logger, DashboardOrchestrator orchestrator)
        {
            _logger = logger;
            _orchestrator = orchestrator;
        }

        [HttpGet("dashboard", Name = RouteNames.Dashboard_Index_Get)]
        public async Task<IActionResult> Index()
        {
            var employerDetail = (EmployerIdentifier)HttpContext.Items[ContextItemKeys.EmployerIdentifier];
            var vm = await _orchestrator.GetDashboardViewModelAsync(employerDetail);

            return View(vm);
        }
    }
}