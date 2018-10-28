using Microsoft.AspNetCore.Mvc;

namespace EducationDepartment.EXT.ASP.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
