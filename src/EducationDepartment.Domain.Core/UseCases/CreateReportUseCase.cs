using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EducationDepartment.Domain.Core.Domain.Enums;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Domain.Core.Interfaces.Services;
using EducationDepartment.Domain.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.UseCases
{
    public class CreateReportUseCase : IReportUseCase
    {
        private readonly IReportingArticlesRepository _userRepository;
        private readonly IExcelReportSrv _excelFactory;
        private readonly IWordReportSrv _wordFactory;

        public CreateReportUseCase(IReportingArticlesRepository userRepository, IExcelReportSrv excelFactory, IWordReportSrv wordFactory)
        {
            _userRepository = userRepository;
            _excelFactory = excelFactory;
            _wordFactory = wordFactory;
        }

        public async Task<bool> Handle(ReportRequest message, IOutputPort<ReportResponse> outputPort)
        {
            var articlesToReport = await _userRepository.GetReportingArticles(message.From, message.To);
            if (articlesToReport.Count > 0)
            {
                using (var stream = new MemoryStream())
                {
                    switch (message.FileType)
                    {
                        case FileType.docx:
                            _wordFactory.CreateReport(stream, articlesToReport);
                            stream.Position = 0;
                            outputPort.Handle(new ReportResponse(stream.ToArray(), message.FileType, true));
                            return true;
                        case FileType.pdf:
                            return false;
                        case FileType.xlsx:
                            _excelFactory.CreateReport(stream, articlesToReport);
                            outputPort.Handle(new ReportResponse(stream.ToArray(), message.FileType, true));
                            return true;
                    }
                }
            }
            return false;
        }
    }
}