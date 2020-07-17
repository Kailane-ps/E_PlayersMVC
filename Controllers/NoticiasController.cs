using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_PlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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

            //Upload da imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                n.Imagem   = file.FileName;
            }
            else
            {
                n.Imagem   = "padrao.png";
            }
            //Fim Upload Imagem

            noticiasModel.Create(n);

             return LocalRedirect("~/Noticias");
            
        }

        [Route("Noticias/{id}")]

        public IActionResult Excluir(int id)
        {
            noticiasModel.Delete(id);
            return LocalRedirect("~/Noticias");
        }

    }
}