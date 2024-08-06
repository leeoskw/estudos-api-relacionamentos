using estudos_api_relacionamentos.DataContext;
using estudos_api_relacionamentos.Entities;
using estudos_api_relacionamentos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace estudos_api_relacionamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CategoriasController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetCategorias()
        {
            var categoriasEntity =  await _context.Categorias
                .Include(c => c.Livros)
                .ToListAsync();

            var categoriasDto = categoriasEntity.Select(c => new CategoriaModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Livros = c.Livros.Select(l => new LivroModel
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    DataPublicacao = l.DataPublicacao,
                    CategoriaId = l.CategoriaId
                }).ToList()
            }).ToList();

            return Ok(categoriasDto);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEntity>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias
                .Include(c => c.Livros)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDto = new CategoriaModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Livros = categoria.Livros.Select(l => new LivroModel
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    DataPublicacao = l.DataPublicacao,
                    CategoriaId = l.CategoriaId
                }).ToList()
            };

            return categoria;
        }



    }
}
