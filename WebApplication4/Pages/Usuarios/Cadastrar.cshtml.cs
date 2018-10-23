using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Pages.Usuarios
{
    public class CadastrarModel : PageModel
    {

       public static List<Usuario> usuarios = new List<Usuario>();


        [BindProperty(SupportsGet = true)]

        public Usuario usuario { get; set; }

        public void OnGet(string nome, string senha)
        {
            if (usuario == null)
            {
                usuario = new Usuario();
            }
        }
        WebApplication4Context _context;
        public CadastrarModel(WebApplication4Context context)
        {
            _context = context;
        }

        [HttpPost]
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
            }
        }

    }
}