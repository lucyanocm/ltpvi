using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LTPVI.API.Models;

namespace LTPVI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly ILogger<AlunoController> _logger;
        private List<Aluno> _alunos;

        public AlunoController(ILogger<AlunoController> logger)
        {
            _logger = logger;

            _alunos = new List<Aluno>();

            _alunos.Add(new Aluno(1, "João", new DateTime(2001, 1, 1), "Sistemas de Informação"));
            _alunos.Add(new Aluno(2, "José", new DateTime(2005, 5, 5), "Direito"));
            _alunos.Add(new Aluno(3, "Maria", new DateTime(2004, 4, 4), "Medicina"));
            _alunos.Add(new Aluno(4, "Ana", new DateTime(2003, 3, 3), "Administração"));
            _alunos.Add(new Aluno(5, "Lucyano", new DateTime(1985, 6, 20), "Sistemas de Informação"));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _alunos.Where(a => a.Id == id).FirstOrDefault();

            if (aluno == null)
            {
                //Não foi encontrado
                return NotFound(new { message = "Aluno não encontrado.", id = id });
            }

            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var aluno = _alunos.Where(a => a.Nome.Contains(nome)).ToList();

            if (aluno == null)
            {
                //Não foi encontrado
                return NotFound(new { message = "Aluno não encontrado.", nome = nome });
            }

            return Ok(aluno);
        }
    }
}