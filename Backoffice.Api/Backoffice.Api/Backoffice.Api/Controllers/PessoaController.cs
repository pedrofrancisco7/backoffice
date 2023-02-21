using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using AutoMapper;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Interfaces;
using Backoffice.Domain.Model;
using Backoffice.Services;
using Backoffice.Services.Interfaces;
using Backoffice.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Api.Controllers;

[Route("api/[controller]")]
public class PessoaController : Controller
{
    private readonly IMapper _mapper;
    private readonly IPessoaServices _pessoaServices;
    private readonly IQualificacaoServices _qualificacaoServices;
    private readonly IPessoaQualificacaoServices _pessoaQualificacaoServices;
    private readonly IExternalServices _externalServices;
    private readonly IEnderecoServices _enderecoServices;
    public PessoaController(IPessoaServices pessoaServices,
                            IQualificacaoServices qualificacaoServices,
                            IEnderecoServices enderecoServices,
                            IPessoaQualificacaoServices pessoaQualificacaoServices,
                            IExternalServices externalServices,
                            IMapper mapper)
    {
        _mapper = mapper;
        _pessoaServices = pessoaServices;
        _enderecoServices = enderecoServices;
        _pessoaQualificacaoServices = pessoaQualificacaoServices;
        _externalServices = externalServices;
        _qualificacaoServices = qualificacaoServices;
    }

    [HttpGet("GetPessoas")]
    public async Task<IActionResult> Get()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _pessoaServices.SelectAsync());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PessoaModel pessoaModel)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {

            if (await _pessoaServices.Exists(pessoaModel?.Documento))
            {
                return BadRequest("Usuário já existe na base");
            }

            var pessoaMap = _mapper.Map<PessoaEntity>(pessoaModel);
            var enderecoMap = _mapper.Map<EnderecoEntity>(pessoaModel.Endereco);

            pessoaMap.Endereco = enderecoMap;

            var idPessoa = Guid.NewGuid();
            var idEndereco = Guid.NewGuid();
            pessoaMap.Id = idPessoa;
            pessoaMap.IdEndereco = idEndereco;
            pessoaMap.Endereco.Id = idEndereco;
            pessoaMap.Endereco.IdPessoa = idPessoa;
            pessoaMap.Endereco.logradouro = $"{pessoaModel.Endereco.logradouro} {pessoaModel.Endereco.num}";


            await _pessoaServices.InsertAsync(pessoaMap);

            foreach (var idQualificacao in pessoaModel.Qualificacoes)
            {
                await _pessoaQualificacaoServices.InsertPessoaQualificacao(idPessoa, idQualificacao);
            }

            return Ok(pessoaModel);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("GetResponsavel")]
    public async Task<IActionResult> GetResponsavel()
    {
        try
        {
            var pessoas = await _pessoaServices.SelectAsync();
            var qualificacoes = await _qualificacaoServices.SelectAsync();
            var pessoasQualificacoes = await _pessoaQualificacaoServices.SelectAsync();


            var responsaveis = (from pessoa in pessoas
                                join pq in pessoasQualificacoes on pessoa.Id equals pq.IdPessoa
                                join qualificacao in qualificacoes on pq.IdQualificacao equals qualificacao.Id
                                where qualificacao.Nome == "Colaborador"
                                select new ResponsavelModel
                                {
                                    Id = pessoa.Id,
                                    Nome = pessoa.Nome
                                }).ToList();            


            //        Data[] cats = listObject
            //.GroupBy(i => new { i.category_id, i.category_name })
            //.OrderByDescending(g => g.Key.category_name)
            //.Select(g => g.First())
            //.ToArray();

            //.Where(qualificacooes.Select(q => q.Id))

            //var studentNames = studentList.Where(s => s.Age > 18)
            //              .Select(s => s)
            //              .Where(st => st.StandardID > 0)
            //              .Select(s => s.StudentName);
            return Ok(responsaveis);

        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }


}

