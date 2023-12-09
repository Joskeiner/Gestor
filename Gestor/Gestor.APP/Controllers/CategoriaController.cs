using AutoMapper;
using Gestor.APP.Models.ViewModels;
using Gestor.APP.Utilidades;
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
        public async Task<IActionResult> Crear([FromBody]VMCategoria modelo)
        {
            GenericResponse<VMCategoria> gResponse = new GenericResponse<VMCategoria>();
            try
            {
                Categoria categoriaCreada = await _categoriaService.Crear(_mapper.Map<Categoria>(modelo));

                modelo = _mapper.Map<VMCategoria>(categoriaCreada);

                gResponse.Estado = true;
                gResponse.objeto = modelo;

            }
            catch( Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, gResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] VMCategoria modelo)
        {
            GenericResponse<VMCategoria> gResponse = new GenericResponse<VMCategoria>();
            try
            {
                Categoria editarCategoria = await _categoriaService.Editar(_mapper.Map<Categoria>(modelo));
                modelo = _mapper.Map<VMCategoria>(editarCategoria);

                gResponse.Estado = true;
                gResponse.objeto = modelo;  
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje= ex.Message;

            }
            return StatusCode(StatusCodes.Status200OK, gResponse);
        }

        [HttpDelete]

        public async Task<IActionResult> Eliminar(int Id)
        {
            GenericResponse<string> gResponse = new GenericResponse<string>();
            try
            {
                gResponse.Estado = await _categoriaService.Eliminar(Id);
            }
            catch ( Exception ex) 
            { 
                gResponse.Estado = false;
                gResponse.Mensaje=ex.Message;

            }
            return StatusCode(StatusCodes.Status200OK, gResponse);
        }
    }
}
