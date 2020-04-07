using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contatos.api.Dto;
using Contatos.Domain;
using Contatos.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly IContatosRepository _contatoRepository;
        private readonly IMapper _map;
        public ContatosController(IContatosRepository contatoRepository, IMapper map)
        {
            this._map = map;
            this._contatoRepository = contatoRepository;

        }

        [HttpGet("{page}/{size}")]
        public async Task<ActionResult> Get(int page, int size)
        {
            try
            {   
                var pag = new PaginacaoDto() { Page = page , Size = size };

                var contato = await _contatoRepository.GetContatoAsyncAll(pag.Page, pag.Size);

                var resultado =  _map.Map<IEnumerable<ContatoDto>>(contato);

                return Ok(resultado);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("id/{ContatoId}")]
        public async Task<ActionResult> Get(int ContatoId)
        {
            try
            {
                var contato = await _contatoRepository.GetContatoAsyncById(ContatoId);

                var resultado = _map.Map<ContatoDto>(contato);

                return Ok(resultado);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpGet("Nome/{Name}")]
        public async Task<ActionResult> Get(string Name)
        {
            try
            {
                var contato = await _contatoRepository.GetContatoAsyncByName(Name);

                var resultado = _map.Map<IEnumerable<ContatoDto>>(contato);

                return Ok(resultado);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ContatoCreate")]
        public async Task<ActionResult> Post(ContatoDto contatoModel)
        {
            try
            {

               var contato = _map.Map<Contato>(contatoModel);

               _contatoRepository.Add(contato);

                if (await _contatoRepository.SaveChangesAsync())
                {
                    return Created($"/Get/{contato.Id}",  _map.Map<ContatoDto>(contato));
                }


            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        [HttpPut("ContatoUpdate/{Contatoid}")]
        public async Task<ActionResult> Put(int Contatoid, ContatoDto contatoModel)
        {
            try
            {
                var contato = await _contatoRepository.GetContatoAsyncById(Contatoid);
                if (contato == null) return NotFound();

                _contatoRepository.Delete(contato);

                _map.Map(contatoModel, contato);

                _contatoRepository.Update(contato);

                if (await _contatoRepository.SaveChangesAsync())
                {
                    return Created($"/contatos/{contatoModel.Id}", _map.Map<ContatoDto>(contato));
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }

        [HttpDelete("{Contatoid}")]
        public async Task<ActionResult> Delete(int Contatoid)
        {
            try
            {
                var contato = await _contatoRepository.GetContatoAsyncById(Contatoid);
                if (contato == null) return NotFound();

                _contatoRepository.Delete(contato);

                if (await _contatoRepository.SaveChangesAsync())
                {
                    return Ok("Deletado com sucesso.");
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }
        

    }
}