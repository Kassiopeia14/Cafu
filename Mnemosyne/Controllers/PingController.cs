using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Mnemosyne at your service.";
    }
}