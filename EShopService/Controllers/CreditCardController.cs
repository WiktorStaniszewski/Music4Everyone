using EShop.Application;
using EShop.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopService.Controllers;

[Route("[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{

    protected ICreditCardService _creditCardService;

    public CreditCardController(ICreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }

    //z jakiegoś powodu nie łapie wyjątków i wyrzuca error 500. Nwm czemu

    // GET: api/<CreditCardController>
    [HttpGet("{creditCard}")]
    public async Task<ActionResult> CheckIfCardIsValid(string creditCard)
    {
        try
        {
            return Ok(_creditCardService.GetCardType(creditCard));
        }
        catch (CardNumberTooShortException)
        {
            return BadRequest(new { error = "Za krótki numer", code = HttpStatusCode.BadRequest });
        }
        catch (CardNumberTooLongException)
        {
            return BadRequest(new { error = "Za długi numer", code = HttpStatusCode.RequestEntityTooLarge });
        }
        catch (CardNumberInvalidException)
        {
            return BadRequest(new { error = "niepoprawny numer", code = HttpStatusCode.BadRequest });
        }
    }
}
