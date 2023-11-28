using AutoMapper;
using Gestor.APP.Models.ViewModels;
using Gestor.BLL.Interfaces;
using Gestor.ENTITY.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace Gestor.APP.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;
        public IActionResult Index()
        {
            return View();
        }

        public CategoriaController(IMapper mapper, ICategoriaService categoriaService)
        {
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<VMCategoria> vMCategorias = _mapper.Map<List<VMCategoria>>(await _categoriaService.Lista());

            return StatusCode(StatusCodes.Status200OK,
                new
                {
                    data = vMCategorias
                });
        }

        [HttpPost]
          public async Task<IActionResult> Crear([FromBody]VMCategoria model)
        {
            try
            {
                Categoria categoriaCreada = await _categoriaService.Crear(_mapper.Map<Categoria>(model));   

                modelo  =_mapper.MaptegoriaCreada);

            }
            catch( Exception ex)
            {
                gRespuesta.Estado = false;
                gRespuesta.objeto = ex.Message;
            }
        }
    }
}
