using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Dto.UseCaseRequests
{
    public class FacebookLoginRequest : IUseCaseRequest<LoginResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Locale { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsSilhouette { get; set; }

        public FacebookLoginRequest(long id, string name, string email, string firstName, string lastName, string gender, string locale)
        {
            Id = id;
            Name = name;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Locale = locale;
        }

        public FacebookLoginRequest(long id, string name, string email, string firstName, string lastName, string gender, string locale, string url, int height, int width, bool isSilhouette)
        {
            Id = id;
            Name = name;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Locale = locale;
            Url = url;
            Height = height;
            Width = width;
            IsSilhouette = isSilhouette;
        }
    }
}
