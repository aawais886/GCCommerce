using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GCCommerce.Entities;
using GCCommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GCCommerce.Controllers
{
    public class UserLoginController : Controller
    {
        GCCommerceContext OurDbContext = null;
        IHostingEnvironment env = null;

        public UserLoginController(GCCommerceContext _OurDbContext, IHostingEnvironment _env)
        {
            OurDbContext = _OurDbContext;
            env = _env;
        }
        [HttpGet]
        public IActionResult AddUpdateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUpdateUser(User U, ICollection<IFormFile> Image )
        {
            U.DateCreated = DateTime.Now;
            string wwwroothpath = env.WebRootPath;
            string ImageFolderPath = wwwroothpath + "/ProjectImages/";

            foreach(var file in Image)
            {
                string Name = file.Name;
                string FileName = file.FileName;
                long FileLenght = file.Length;

                string FileNameWithoutExtenstion = Path.GetFileNameWithoutExtension(FileName);
                Random r = new Random();

                FileNameWithoutExtenstion = DateTime.Now.ToString("ddmmyyyyhhmm") + r.Next(1, 1000).ToString();
                string Extenstion = Path.GetExtension(FileName);

                FileStream fs = new FileStream(ImageFolderPath + FileNameWithoutExtenstion + Extenstion, FileMode.CreateNew);
                file.CopyTo(fs);
                fs.Close();
                fs.Dispose();

                U.Image = ImageFolderPath + FileNameWithoutExtenstion + Extenstion;

            }

            OurDbContext.User.Add(U);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(UserLoginController.AddUpdateUser));
        }

        public IActionResult NewLogin()
        {
                      
            return View();
        }

        
 
        public IActionResult CheckLoginusingform(string Email, string Password)

        {
            try
            {
                User obj = OurDbContext.User.Where(abc => abc.Email == Email).FirstOrDefault<User>();
                if (obj.Password == Password)
                {

                    string FirstName = obj.FirstName;
                    string LastName = obj.LastName;

                    HttpContext.Session.SetString("UserName", FirstName + " " + LastName);

                    return RedirectToAction(nameof(DashBoardController.DashBoard));
                }
                else
                {

                    return RedirectToAction(nameof(UserLoginController.NewLogin));
                }
            }
            catch(Exception e)
            {
                return View(e);
            }
           
        }

        //private User CopyMUtoU(ModelUser mu)
        //{
        //    User U = new User
        //    {
        //        Id = mu.Id,
        //        FirstName = mu.FirstName,
        //        LastName = mu.LastName,
        //        Email = mu.Email,
        //        Password = mu.Password,
        //        Gander = mu.Gander,
        //        DateCreated = mu.DateCreated,
        //        DateUpdated = mu.DateUpdated
        //    };
        //   return U;
        //}

        //private User CopyUtoMU(User U)
        //{
        //    ModelUser muobj = new ModelUser
        //    {
        //        Id = U.Id,
        //        FirstName = U.FirstName,
        //        LastName = U.LastName,
        //        Email = U.Email,
        //        Password = U.Password,
        //        Gander = U.Gander,
        //        DateCreated = U.DateCreated,
        //        DateUpdated = U.DateUpdated
        //    };
        //    return muobj; 
        //}
    }
}