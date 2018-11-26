using EducationDepartment.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Dto.UseCaseResponses
{
    public class SendNotificationResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }

        public SendNotificationResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
