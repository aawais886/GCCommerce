using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCCommerce.Entities;
using GCCommerce.Helpers;
using GCCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace GCCommerce.Controllers
{
    public class AdministratorController : Controller
    {
        GCCommerceContext OurdbContext = null;
        IHostingEnvironment env = null;

        public AdministratorController(GCCommerceContext _OurdbContext, IHostingEnvironment _env)
        {
            OurdbContext = _OurdbContext;
            env = _env;

        }
        public IActionResult Index()
        {
            return View();
        }
        #region News

        /******************************************************* NEWS SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateNews()
        {
            ModelNews mn = new ModelNews();
            mn.DateCreated = DateTime.Now.Date;
            return View(mn);
        }
        [HttpGet]
        public IActionResult UpdateNews(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            News N = OurdbContext.News.Find(id);
            if (N.NewsId < 1)
            {
                return NotFound();
            }
            return View("AddUpdateNews", CopyNToMN(N));

        }
        [HttpPost]
        public IActionResult AddUpdateNews(ModelNews MN)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MN);
            }
            try
            {
                if (MN.NewsId > 0)
                {
                    MN.DateUpdated = DateTime.Now.Date;
                    OurdbContext.News.Update(CopyMNToN(MN));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.News.Add(CopyMNToN(MN));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.NewsList));
        }

        public IActionResult NewsList()
        {
            return View(OurdbContext.News.ToList<News>());
        }

        public IActionResult NewsDetail(int NewsID)
        {
            News obj = OurdbContext.News.Where(abc => abc.NewsId == NewsID).FirstOrDefault();
            return View(obj);
        }
        [HttpDelete]
        public IActionResult NewsDelete(int NewsID)
        {
            News obj = OurdbContext.News.Where(abc => abc.NewsId == NewsID).FirstOrDefault<News>();
            OurdbContext.News.Remove(obj);
            OurdbContext.SaveChanges();
            return RedirectToAction(nameof(AdministratorController.NewsList));
        }
        private News CopyMNToN(ModelNews mn)
        {
            News N = new News
            {
                NewsId = mn.NewsId,
                NewsValue = mn.NewsValue,
                DateCreated = mn.DateCreated,
                DateUpdated = mn.DateUpdated,

            };
            return N;
        }

        private ModelNews CopyNToMN(News N)
        {
            ModelNews mn = new ModelNews
            {
                NewsId = N.NewsId,
                NewsValue = N.NewsValue,
                DateCreated = N.DateCreated,
                DateUpdated = N.DateUpdated,

            };
            return mn;
        }
        #endregion

        #region EVENT
        /******************************************************* EVENT SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateEvent()
        {
            Event E = new Event();
            E.DateCreated = DateTime.Now;
            return View(E);
        }
        [HttpGet]
        public IActionResult UpdateEvent(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            Event E = OurdbContext.Event.Find(id);
            if (E.EventId < 1)
            {
                return NotFound();
            }
            return RedirectToAction("AddUpdateEvent", CopyEToME(E));
        }
        [HttpPost]
        public IActionResult AddUpdateEvent(ModelEvent ME)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(ME);
            }
            try
            {
                if (ME.EventId > 0)
                {
                    ME.DateUpdated = DateTime.Now.Date;
                    OurdbContext.Event.Update(CopyMEToE(ME));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Event.Add(CopyMEToE(ME));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.NewsList));
        }
        public IActionResult EventList()
        {
            return View(OurdbContext.Event.ToList<Event>());
        }
        public IActionResult EventDetail(int EventID)
        {
            Event obj = OurdbContext.Event.Where(abc => abc.EventId == EventID).FirstOrDefault();
            return View(obj);
        }
        public IActionResult EventDelete(int EventID)
        {
            Event obj = OurdbContext.Event.Where(abc => abc.EventId == EventID).FirstOrDefault();
            OurdbContext.Event.Remove(obj);
            OurdbContext.SaveChanges();
            return RedirectToAction(nameof(AdministratorController.EventList));
        }

        private Event CopyMEToE(ModelEvent ME)
        {
            Event E = new Event
            {
                EventId = ME.EventId,
                EventName = ME.EventName,
                EventDate = ME.EventDate,
                DateCreated = ME.DateCreated,
                DateUpdated = ME.DateUpdated,

            };
            return E;
        }

        private ModelEvent CopyEToME(Event N)
        {
            ModelEvent ME = new ModelEvent
            {
                EventId = N.EventId,
                EventName = N.EventName,
                EventDate = N.EventDate,
                DateCreated = N.DateCreated,
                DateUpdated = N.DateUpdated,

            };
            return ME;
        }
        #endregion

        #region Gallery
        /******************************************************* GALLERY SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateGllery()
        {
            Gallery G = new Gallery();
            G.DateCreated = DateTime.Now;
            return View(G);
        }
        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            if(id < 1)
            {
                return NotFound();
            }
            Gallery G = OurdbContext.Gallery.Find(id);
            if(G.GalleryId < 1)
            {
                return NotFound();
            }
            return View("AddUpdateGllery", CopyGToMG(G));
        }
        [HttpPost]
        public IActionResult AddUpdateGllery(ModelGallery MG)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MG);
            }
            try
            {
                if (MG.GalleryId > 0)
                {
                    MG.DateUpdated = DateTime.Now;
                    OurdbContext.Gallery.Update(CopyMGToG(MG));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Gallery.Add(CopyMGToG(MG));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.GalleryList));
        }
        public IActionResult GalleryList()
        {
            return View(OurdbContext.Gallery.ToList());
        }
        public IActionResult GalleryDetail(int GalleryID)
        {
           Gallery obj =OurdbContext.Gallery.Where(abc => abc.GalleryId == GalleryID).FirstOrDefault();
            return View(obj);
        }
        public IActionResult GalleryDelete(int GalleryID)
        {
           Gallery obj = OurdbContext.Gallery.Where(abc => abc.GalleryId == GalleryID).FirstOrDefault();
            OurdbContext.Gallery.Remove(obj);
            OurdbContext.SaveChanges();
            return RedirectToAction(nameof(AdministratorController.GalleryList));
        }
        private Gallery CopyMGToG(ModelGallery MG)
        {
            Gallery G = new Gallery
            {
                GalleryId = MG.GalleryId,
                GalleryImageName = MG.GalleryImageName,
                GalleryImageDescription = MG.GalleryImageDescription,
                DateCreated = MG.DateCreated,
                DateUpdated = MG.DateUpdated,

            };
            return G;
        }

        private ModelGallery CopyGToMG(Gallery G)
        {
            ModelGallery MG = new ModelGallery
            {
                GalleryId = G.GalleryId,
                GalleryImageName = G.GalleryImageName,
                GalleryImageDescription = G.GalleryImageDescription,
                DateCreated = G.DateCreated,
                DateUpdated = G.DateUpdated,

            };
            return MG;
        }
        #endregion

        #region Teacher
        /******************************************************* TEACHER SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateTeacher()
        {
            Teacher T = new Teacher();
            T.DateCreated = DateTime.Now;
            return View(T);
        }
        [HttpGet]
        public IActionResult UpdateTeacher(int id)
        { 
            if(id < 1 )
            {
                return NotFound();
            }
            Teacher T = OurdbContext.Teacher.Find(id);
            if(T.TeacherId < 1)
            {
                return NotFound();
            }
            return View("AddUpdateTeacher", CopyTToMT(T));
        }
        [HttpPost]
        public IActionResult AddUpdateTeacher(ModelTeacher MT, ICollection<IFormFile> images)
        {
            if(!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MT);
            }
            string wwwrootPath = env.WebRootPath;
            string ImageFolderPath = wwwrootPath + "/images/";

            foreach (var file in images)
            {
                string Name = file.Name;

                string FileName = file.FileName;
                long FileLength = file.Length;
               
                string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
                Random r = new Random();

                FileNameWithoutExtension = DateTime.Now.ToString("ddMMyyyyhhmm") + r.Next(1, 1000).ToString();
                string Extension = Path.GetExtension(FileName);

                FileStream fs = new FileStream(ImageFolderPath + FileNameWithoutExtension + Extension, FileMode.CreateNew);
                file.CopyTo(fs);
                fs.Close();
                fs.Dispose();

               MT.Image = ImageFolderPath + FileNameWithoutExtension + Extension;
            }
            try
            {
                if (MT.TeacherId > 0)
                {
                    MT.DateUpdated = DateTime.Now;
                    OurdbContext.Teacher.Update(CopyMTToT(MT));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Teacher.Add(CopyMTToT(MT));
                    OurdbContext.SaveChanges();
                }
            }
            catch(Exception)
            {
                TempData["action"] = Constants.FAILED;
            }
            return View();
        }

        public IActionResult TeacherList()
        {
            return View(OurdbContext.Teacher.ToList());
        }
        public IActionResult TeacherDetail(int TeacherID)
        {
            Teacher obj =OurdbContext.Teacher.Where(abc => abc.TeacherId == TeacherID).FirstOrDefault();
            return View(obj);
        }

        private Teacher CopyMTToT(ModelTeacher MT)
        {
            Teacher T = new Teacher
            {
                TeacherId = MT.TeacherId,
                FirstName = MT.FirstName,
                LastName = MT.LastName,
                Email = MT.Email,
                Grade = MT.Grade,
                Qualification = MT.Qualification,
                HiredDate = MT.HiredDate,
                TransferDate = MT.TransferDate,
                RetirementDate = MT.RetirementDate,
                Image =MT.Image,
                DateCreated = MT.DateCreated,
                DateUpdated = MT.DateUpdated,

            };
            return T;
        }
        private ModelTeacher CopyTToMT(Teacher T)
        {
            ModelTeacher MT = new ModelTeacher
            {
                TeacherId = T.TeacherId,
                FirstName = T.FirstName,
                LastName = T.LastName,
                Email = T.Email,
                Grade = T.Grade,
                Qualification = T.Qualification,
                HiredDate = T.HiredDate,
                TransferDate = T.TransferDate,
                RetirementDate = T.RetirementDate,
                Image = T.Image,
                DateCreated = T.DateCreated,
                DateUpdated = T.DateUpdated,

            };
            return MT;
        }
        #endregion
    }
}