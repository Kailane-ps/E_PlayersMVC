using System.Collections.Generic;
using E_PlayersMVC.Models;

namespace E_PlayersMVC.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias n);
        List<Noticias> ReadAll();
        void Update(Noticias n);
        void Delete(int IdNoticias);
    }
}