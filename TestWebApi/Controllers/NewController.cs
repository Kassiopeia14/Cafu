using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NewController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Yo";
    }
}