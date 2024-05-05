using HospitalProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HospitalProje.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(UserSignInViewModel p)
        {
			if (ModelState.IsValid)
			{
				
				if (p.Username == "Duygu" && p.Password == "123")
				{
					
					return RedirectToAction("Index", "Doctor");
				}
				else
				{
					
					ModelState.AddModelError(string.Empty, "kullanıcı ile şifre uyuşmadı");
					return View(p);
				}
			}

			
			return View(p);
		}
       
    }
}

