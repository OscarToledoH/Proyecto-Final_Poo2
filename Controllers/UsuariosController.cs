using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerAvancePOO2.Models;
using PrimerAvancePOO2.Services;

namespace PrimerAvancePOO2.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;

        private readonly ApplicationDbContext _context;

        public UsuariosController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager ,ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
        }


        [AllowAnonymous]
        public IActionResult Registros()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Registros(RegistroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var Usuario = new IdentityUser(){Email = modelo.Email, UserName = modelo.Email};

            var resultado = await userManager.CreateAsync(Usuario, password: modelo.Password);
            if(resultado.Succeeded)
            {
                await signInManager.SignInAsync(Usuario, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach(var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(modelo);
            }
        }

        
        [AllowAnonymous]
        public IActionResult InicioSesion(string mensaje = null)
        {
            if(mensaje is not null)
            {
                ViewData["mensaje"] = mensaje;
            }

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> InicioSesion(LoginViewModel modelo)
        {
            if(!ModelState.IsValid)
            {
                return View(modelo);
            }

            var resultado = await signInManager.PasswordSignInAsync(modelo.Email,modelo.Password, modelo.Recuerdame, lockoutOnFailure: false);

            if(resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o password incorrecto");
                return View(modelo);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }




        public async Task<IActionResult> UsuariosList(string confirmed = null, string remove = null)
        {
            var userList =  await this._context.Users.ToListAsync();
            var userRoleList = await this._context.UserRoles.ToListAsync();

            var userDtoList = userList.GroupJoin(userRoleList, u => u.Id, ur => ur.UserId, 
                (u, ur) => new UsuarioViewModel  {
                    Email = u.Email,
                    Confirmed = u.EmailConfirmed,
                    IsAdmin = ur.Any(ur => ur.UserId == u.Id)
                })
                .ToList();


            var modelo = new UsuarioListViewModel();
            modelo.UserList = userDtoList;
            modelo.MessageConfirmed = confirmed;
            modelo.MessageRemoved = remove;

            return View(modelo);
        }





        [HttpPost]
        [Authorize(Roles = MyConstants.RolAdmin)]
        public  async Task<IActionResult> HacerAdmin(string email)
        {
            var usuario = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario is null)
            {
                return NotFound();
            }

            await userManager.AddToRoleAsync(usuario, MyConstants.RolAdmin);

            return RedirectToAction("UsuariosList",
                routeValues: new { confirmed = "Rol asignado correctamente a " + email , remove = ""  });
        }

        [HttpPost]
        [Authorize(Roles = MyConstants.RolAdmin)]
        public async Task<IActionResult> RemoverAdmin(string email)
        {
            var usuario = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario is null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(usuario, MyConstants.RolAdmin);

            return RedirectToAction("UsuariosList",
                routeValues: new { confirmed = "", remove = "Rol removido correctamente a " + email });
        }
        /*----------*/

        

        
        
    }
}