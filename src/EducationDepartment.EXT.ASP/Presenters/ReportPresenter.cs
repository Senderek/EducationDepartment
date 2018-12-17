using EducationDepartment.Domain.Core.Domain.Enums;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EducationDepartment.EXT.ASP.Presenters
{
    public class ReportPresenter : IOutputPort<ReportResponse>
    {
        public FileContentResult ContentResult { get; private set; }

        public ReportPresenter()
        {
        }

        public void Handle(ReportResponse response)
        {
            if (response.Success)
            {
                switch (response.Type)
                {
                    case FileType.docx:
                        ContentResult = new FileContentResult(response.Content, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                        break;
                    case FileType.pdf:
                        break;
                    case FileType.xlsx:
                        ContentResult = new FileContentResult(response.Content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        break;
                }
            }
        }
    }
}
