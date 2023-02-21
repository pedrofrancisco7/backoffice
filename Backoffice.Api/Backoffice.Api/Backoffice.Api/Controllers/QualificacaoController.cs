using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backoffice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Api.Controllers;

[Route("api/[controller]")]
public class QualificacaoController : Controller
{
    private readonly IQualificacaoServices _qualificacaoServices;

    public QualificacaoController(IQualificacaoServices qualificacaoServices)
    {
        _qualificacaoServices = qualificacaoServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _qualificacaoServices.SelectAsync());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    //[Route("{id}", Name = "GetById")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _qualificacaoServices.SelectAsync(id));
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}

