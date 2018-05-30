using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCCommerce.Entities;
using GCCommerce.Helpers;
using GCCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace GCCommerce.Controllers
{
    public class AdministratorController : Controller
    {
        GCCommerceContext OurdbContext = null;

        public AdministratorController(GCCommerceContext _OurdbContext)
        {
            OurdbContext = _OurdbContext;

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
            if (N.NewsId< 1)
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
                NewsValue=mn.NewsValue,
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
            if(E.EventId < 1)
            {
                return NotFound();
            }
            return View("AddUpdateEvent", CopyEToME(E));
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
        #region 
    }
}