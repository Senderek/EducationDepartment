using EducationDepartment.Domain.Core.Domain.Enums;
using EducationDepartment.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Dto.UseCaseResponses
{
    public class ReportResponse : UseCaseResponseMessage
    {
        public readonly byte[] Content;
        public readonly FileType Type;

        public ReportResponse(byte[] _content, FileType _type, bool success = false, string message = null) : base(success, message)
        {
            this.Content = _content;
            Type = _type;
        }
    }
}
