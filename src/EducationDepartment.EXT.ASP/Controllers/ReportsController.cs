using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Interfaces.UseCases;
using EducationDepartment.EXT.ASP.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace EducationDepartment.EXT.ASP.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportUseCase _reportUseCase;
        private readonly ReportPresenter _reportPresenter;

        public ReportsController(IReportUseCase reportUseCase, ReportPresenter reportPresenter)
        {
            _reportUseCase = reportUseCase;
            _reportPresenter = reportPresenter;
        }

        [HttpGet]
        public async Task<IActionResult> GetReport(ReportRequest request)
        {
            await _reportUseCase.Handle(request, _reportPresenter);
            return _reportPresenter.ContentResult;           
        }
    }
}