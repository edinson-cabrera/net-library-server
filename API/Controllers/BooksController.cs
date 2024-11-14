using library_server.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_server.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    private readonly LoanService _loanService;

    public LoansController(LoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterLoan([FromBody] LoanRequest request)
    {
        await _loanService.RegisterLoanAsync(request.UserId, request.BookIds);
        return Ok("Loan registered successfully.");
    }
}

public class LoanRequest
{
    public Guid UserId { get; set; }
    public List<Guid> BookIds { get; set; }
}