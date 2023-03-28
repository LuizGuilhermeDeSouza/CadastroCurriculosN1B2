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
                CurriculoViewModel curriculo = new CurriculoViewModel();
                return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Salvar(CurriculoViewModel curriculo)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Insert(curriculo);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }

        }
    }
}
