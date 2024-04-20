using AutoMapper;
using ListaTarefas.Entities;
using ListaTarefas.Models;
using ListaTarefas.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TarefasDBContext _context;
        private readonly IMapper _mapper;
        public TarefasController(TarefasDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Obter todas as tarefas
        /// </summary>
        /// <returns>Coleção de tarefas</returns>
        /// <response code="200">Sucesso</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var tarefaEventos = _context.TarefaEventos.Where(d => !d.Deletado).ToList();
            var viewModel = _mapper.Map<List<TarefaEventoViewModel>>(tarefaEventos);
            return Ok(viewModel);
        }

        /// <summary>
        /// Obter uma tarefa
        /// </summary>
        /// <param name="id">Identificador da tarefa</param>
        /// <returns>Somente uma tarefa</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não foi encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var tarefaEventos = _context.TarefaEventos.SingleOrDefault(d => d.id == id);

            if(tarefaEventos == null) 
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<TarefaEventoViewModel>(tarefaEventos);
            return Ok(viewModel);
        }

        /// <summary>
        /// Cadastrar uma tarefa
        /// </summary>
        /// <remarks>
        /// {"Titulo" = "Digite aqui", "Descricao" = "Digite aqui", StatusTarefa, "Digite aqui"}
        /// </remarks>
        /// <param name="tarefaEvento">Dados da tarefa</param>
        /// <returns>Objeto récem-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(TarefaEventoInputModel input)
        {
            var tarefaEvento = _mapper.Map<TarefaEvento>(input);
            _context.TarefaEventos.Add(tarefaEvento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = tarefaEvento.id}, tarefaEvento);
        }

        /// <summary>
        /// Atualizar um evento
        /// </summary>
        /// <remarks>
        /// {"Titulo" = "Digite aqui", "Descricao" = "Digite aqui", StatusTarefa, "Digite aqui"}
        /// </remarks>
        /// <param name="id">Identificador do evento</param>
        /// <param name="put">Dados da tarefa</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não foi encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(Guid id, TarefaEventoInputModel put)
        {
            var tarefaEventos = _context.TarefaEventos.SingleOrDefault(d => d.id == id);

            if (tarefaEventos == null)
            {
                return NotFound();
            }

            tarefaEventos.Update(put.Titulo, put.Descricao, put.StatusTarefa);

            _context.TarefaEventos.Update(tarefaEventos);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deletar uma tarefa
        /// </summary>
        /// <param name="id">Identificador da tarefa</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não foi encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(Guid id)
        {
            var tarefaEventos = _context.TarefaEventos.SingleOrDefault(d => d.id == id);

            if (tarefaEventos == null)
            {
                return NotFound();
            }

            tarefaEventos.Delete();
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
