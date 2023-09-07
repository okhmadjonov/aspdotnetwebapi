using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Filters;

public class IdValidationAttribute : TypeFilterAttribute
{
    public IdValidationAttribute() : base(typeof(IdCheckAttribute)) { }
}