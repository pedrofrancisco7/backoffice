using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Backoffice.Domain.Model;
using Backoffice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Api.Controllers;

[Route("api/[controller]")]
public class EnderecoController : Controller
{
    private readonly IMapper _mapper;
    private readonly IExternalServices _externalServices;
    private readonly IEnderecoServices _enderecoService;

    public EnderecoController(IMapper mapper,
                              IEnderecoServices enderecoService,
                              IExternalServices externalServices)
    {
        _mapper = mapper;
        _enderecoService = enderecoService;
        _externalServices = externalServices;
    }


    [HttpGet("{cep}")]
    public async Task<IActionResult> GetCep(string cep)
    {
        try
        {
            var endereco = await _externalServices.GetEndereco(cep);
            return Ok(endereco);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost("SaveEndereco")]
    public async Task<IActionResult> SaveEndereco([FromBody] EnderecoModel enderecoModel)
    {
        try
        {
            var enderecoEntity = _mapper.Map<EnderecoEntity>(enderecoModel);
            var endereco = await _enderecoService.InsertAsync(enderecoEntity);
            return Ok(endereco);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpPost("GetEndereco")]
    public async Task<IActionResult> GetEndereco([FromBody] string cep)
    {
        try
        {
            if (cep == null)
            {
                return Json("Cep vazio");
            }

            var endereco = await _externalServices.GetEndereco(cep);
            return Json(endereco);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

}

