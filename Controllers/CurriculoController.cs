using CadastroCurriculos.DAO;
using CadastroCurriculos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCurriculos.Controllers
{
    public class CurriculoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                List<CurriculoViewModel> curriculos = dao.Select();
                return View(curriculos);
            }
            catch(Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Imprimir()
        {
            try
            {
                CurriculoViewModel curriculo = new CurriculoViewModel();
                return View("Curriculo", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Create()
        {
            try
            {
                ViewBag.Bd = "I";
                CurriculoViewModel curriculo = new CurriculoViewModel();
                CurriculoDAO dao = new CurriculoDAO();
                curriculo.Curriculo_id = dao.ProximoId();
                return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Salvar(CurriculoViewModel curriculo, string viewBag)
        {
            try
            {
               
                CurriculoDAO dao = new CurriculoDAO();

                if (viewBag == "U")
                {
                    curriculo.Nivel_ingles = Request.Form["NivelIngles"];
                    curriculo.Nivel_espanhol = Request.Form["NivelEspanhol"];
                    dao.Update(curriculo);
                }
                else
                {
                    curriculo.Curriculo_id = dao.ProximoId();
                    dao.Insert(curriculo);
                }
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }

        }
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Bd = "U";
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.ConsultaId(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("error",
                    new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
