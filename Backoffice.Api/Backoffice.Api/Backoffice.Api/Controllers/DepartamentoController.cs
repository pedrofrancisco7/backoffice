using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Model;
using Backoffice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Api.Controllers;

[Route("api/[controller]")]
public class DepartamentoController : Controller
{
    private readonly IDepartamentoServices _departamentoServices;
    private readonly IMapper _mapper;
    public DepartamentoController(IMapper mapper,
                                  IDepartamentoServices departamentoServices)
    {
        _mapper = mapper;
        _departamentoServices = departamentoServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartamentos()
    {
        return Ok();
    }

    [HttpPost("SaveDepartamento")]
    public async Task<IActionResult> SaveDepartamento([FromBody] DepartamentoModel departamentoModel)
    {
        try
        {
            var departamentoEntity = _mapper.Map<DepartamentoEntity>(departamentoModel);

            if(await _departamentoServices.Exists(departamentoModel?.Nome))
            {
                return BadRequest("Usuário já cadastrado");
            }


            var departamento = await _departamentoServices.InsertAsync(departamentoEntity);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}

