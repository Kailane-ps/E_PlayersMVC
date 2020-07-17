using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_PlayersMVC.Models;
using Microsoft.AspNetCore.Http;

namespace E_PlayersMVC.Controllers
{
    public class NoticiasController : Controller
    {
        
        Noticias noticiasModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }

        public IActionResult Publicar(IFormCollection form)
        {
            Noticias n   = new Noticias();
            n.IdNoticias = Int32.Parse(form["IdNoticias"]);
            n.Titulo     = form["Titulo"];
            n.Texto      = form["Texto"];
            n.Imagem     = form["Imagem"];

            noticiasModel.Create(n);

            ViewBag.Equipe = noticiasModel.ReadAll();
             return LocalRedirect("~/Noticias");

        }

    }
}