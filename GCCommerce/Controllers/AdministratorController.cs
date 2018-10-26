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
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    MN.DateUpdated = DateTime.Now;
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
        //public IActionResult NewsDelete(int NewsID)
        //{
        //    News obj = OurdbContext.News.Where(abc => abc.NewsId == NewsID).FirstOrDefault<News>();
        //    OurdbContext.News.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.NewsList));
        //}
        public bool DeleteNews(int Id)
        {
            try
            {
                News N = OurdbContext.News.Find(Id);
                if (N != null)
                {
                    OurdbContext.News.Remove(N);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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
            ModelEvent E = new ModelEvent();
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
            catch (Exception e)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.EventList));
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
        //public IActionResult EventDelete(int EventID)
        //{
        //    Event obj = OurdbContext.Event.Where(abc => abc.EventId == EventID).FirstOrDefault();
        //    OurdbContext.Event.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.EventList));
        //}
        public bool DeleteEvent(int Id)
        {
            try
            {
                Event E = OurdbContext.Event.Find(Id);
                if (E != null)
                {
                    OurdbContext.Event.Remove(E);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private Event CopyMEToE(ModelEvent ME)
        {
            Event E = new Event
            {
                EventId = ME.EventId,
                EventName = ME.EventName,
                EventDescription=ME.EventDescription,
                EventDate = ME.EventDate,
                DateCreated = ME.DateCreated,
                DateUpdated = ME.DateUpdated,

            };
            return E;
        }

        private ModelEvent CopyEToME(Event E)
        {
            ModelEvent ME = new ModelEvent
            {
                EventId = E.EventId,
                EventName = E.EventName,
                EventDescription=E.EventDescription,
                EventDate = E.EventDate,
                DateCreated = E.DateCreated,
                DateUpdated = E.DateUpdated,

            };
            return ME;
        }
        #endregion

        #region Gallery
        /******************************************************* GALLERY SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateGllery()
        {
            ModelGallery G = new ModelGallery();
            G.DateCreated = DateTime.Now;
            return View(G);
        }
        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            Gallery G = OurdbContext.Gallery.Find(id);
            if (G.GalleryId < 1)
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
            Gallery obj = OurdbContext.Gallery.Where(abc => abc.GalleryId == GalleryID).FirstOrDefault();
            return View(obj);
        }
        //public IActionResult GalleryDelete(int GalleryID)
        //{
        //    Gallery obj = OurdbContext.Gallery.Where(abc => abc.GalleryId == GalleryID).FirstOrDefault();
        //    OurdbContext.Gallery.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.GalleryList));
        //}
        public bool DeleteGallery(int Id)
        {
            try
            {
                Gallery G = OurdbContext.Gallery.Find(Id);
                if (G != null)
                {
                    OurdbContext.Gallery.Remove(G);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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
            ModelTeacher T = new ModelTeacher();
            T.DateCreated = DateTime.Now;
            return View(T);
        }
        [HttpGet]
        public IActionResult UpdateTeacher(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            Teacher T = OurdbContext.Teacher.Find(id);
            if (T.TeacherId < 1)
            {
                return NotFound();
            }
            return View("AddUpdateTeacher", CopyTToMT(T));
        }
        [HttpPost]
        public IActionResult AddUpdateTeacher(ModelTeacher objMT, ICollection<IFormFile> Image)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(objMT);
            }

            string wwwrootPath = env.WebRootPath;
            string ImageFolderPath = wwwrootPath + "/ProjectImages/";

            foreach (var file in Image)
            {
                string Name = file.Name;
                string FileName = file.FileName;
                long FileLength = file.Length;

                string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
                Random r = new Random();

                FileNameWithoutExtension = DateTime.Now.ToString("ddMMyyyyhhmm") + r.Next(1, 1000).ToString();
                string Extension = Path.GetExtension(FileName);

                FileStream fs = new FileStream(ImageFolderPath + FileNameWithoutExtension+Extension, FileMode.CreateNew);
                file.CopyTo(fs);
                fs.Close();
                fs.Dispose();

                objMT.Image = ImageFolderPath + FileNameWithoutExtension + Extension;
            }
            try
            {
                if (objMT.TeacherId > 0)
                {
                    objMT.DateUpdated = DateTime.Now;
                    OurdbContext.Teacher.Update(CopyMTToT(objMT));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Teacher.Add(CopyMTToT(objMT));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.TeacherList));
        }

        public IActionResult TeacherList()
        {
            return View(OurdbContext.Teacher.ToList());
        }
        public IActionResult TeacherDetail(int TeacherID)
        {
            Teacher obj = OurdbContext.Teacher.Where(abc => abc.TeacherId == TeacherID).FirstOrDefault();
            return View(obj);
        }
        //public IActionResult TeacherDelete(int TeacherID)
        //{
        //    Teacher obj = OurdbContext.Teacher.Where(abc => abc.TeacherId == TeacherID).FirstOrDefault();
        //    OurdbContext.Teacher.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.TeacherList));
        //}
        public bool DeleteTeacher(int Id)
        {
            try
            {
                Teacher T = OurdbContext.Teacher.Find(Id);
                if (T != null)
                {
                    OurdbContext.Teacher.Remove(T);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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
                Image = MT.Image,
                DateCreated = MT.DateCreated,
                DateUpdated = MT.DateUpdated,

            };
            return T;
        }
        private ModelTeacher CopyTToMT(Teacher T)
        {
            ModelTeacher MTobj = new ModelTeacher
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
            return MTobj;
        }
        #endregion

        #region Shift
        /******************************************************* Shift SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateShift()
        {
            ModelShift S = new ModelShift();
            S.DateCreated = DateTime.Now;
            return View(S);
        }
        [HttpGet]
        public IActionResult UpdateShift(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            Shift S = OurdbContext.Shift.Find(id);
            if (S.ShiftId < 1)
            {
                return NotFound();
            }
            return View("AddUpdateShift", CopyShiftToMShift(S));
        }
        [HttpPost]
        public IActionResult AddUpdateShift(ModelShift MSobj)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MSobj);
            }

            try
            {
                if (MSobj.ShiftId > 0)
                {
                    MSobj.DateUpdated = DateTime.Now;
                    OurdbContext.Shift.Update(CopyMShiftToShift(MSobj));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Shift.Add(CopyMShiftToShift(MSobj));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["Action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.ShiftList));
        }
        [HttpPost]
        public JsonResult checkDuplicateShift(string Shift1)
        {
            bool duplicate = false;
            if(OurdbContext.Shift.Where(abc => abc.Shift1.Contains(Shift1)).Count() > 0)
            {
                duplicate = true;
            }
            return Json(duplicate == false);
        }
        public IActionResult ShiftList()
        {
            return View(OurdbContext.Shift.ToList());
        }

        public IActionResult ShiftDetail(int ShiftID)
        {
            Shift obj = OurdbContext.Shift.Where(abc => abc.ShiftId == ShiftID).FirstOrDefault();
            return View(obj);
        }

        //public IActionResult ShiftDelete(int ShiftID)
        //{
        //    Shift obj = OurdbContext.Shift.Where(abc => abc.ShiftId == ShiftID).FirstOrDefault();
        //    OurdbContext.Shift.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.ShiftList));
        //}

        public bool DeleteShift(int id)
        {
            try
            {
                Shift  S = OurdbContext.Shift.Find(id);
                if (S != null)
                {
                    OurdbContext.Shift.Remove(S);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        private Shift CopyMShiftToShift(ModelShift MS)
        {
            Shift S = new Shift
            {
                ShiftId = MS.ShiftId,
                Shift1 = MS.Shift1,
                DateCreated = MS.DateCreated,
                DateUpdated = MS.DateUpdated,

            };
            return S;
        }

        private ModelShift CopyShiftToMShift(Shift S)
        {
            ModelShift MS = new ModelShift
            {
                ShiftId = S.ShiftId,
                Shift1 = S.Shift1,
                DateCreated = S.DateCreated,
                DateUpdated = S.DateUpdated,
            };
            return MS;
        }
        #endregion

        #region Program
        /******************************************************* PROGRAM SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateProgram()
        {
            ModelProgram MP = new ModelProgram();
            MP.DateCreated = DateTime.Now;
            IList<Shift> ILS = OurdbContext.Shift.ToList();
            ViewBag.vb = ILS;
            return View(MP);
        }
        [HttpGet]
        public IActionResult UpdateProgram(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Entities.Program P = OurdbContext.Program.Find(id);
            if (P.ProgramId < 1)
            {
                return NotFound();
            }
            IList<Shift> ILS = OurdbContext.Shift.ToList();
            ViewBag.vb = ILS;
            return View("AddUpdateProgram", CopyPToMP(P));
        }
        [HttpPost]
        public JsonResult CheckDuplicate(string ProgramTitle)
       {
            bool duplicate = false;
            if (OurdbContext.Program.Where(abc => abc.ProgramTitle.Contains(ProgramTitle)).Count() > 0)
            {
                duplicate = true;
            }
            return Json(duplicate == false);
        }
        [HttpPost]
        public IActionResult AddUpdateProgram(ModelProgram MP)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MP);
            }

            try
            {
                if (MP.ProgramId > 0)
                {
                    MP.DateUpdated = DateTime.Now;
                    OurdbContext.Program.Update(CopyMPToP(MP));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Program.Add(CopyMPToP(MP));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["Action"] = Constants.FAILED;
            }

            return RedirectToAction(nameof(AdministratorController.ProgramList));
        }
        public IActionResult ProgramList()
        {
            IList<ModelProgramList> obj = (from a in OurdbContext.Program
                                           join b in OurdbContext.Shift on a.FkShiftId equals b.ShiftId
                                           select new ModelProgramList
                                           {
                                               Id = a.ProgramId,
                                               ProgramShift = b.Shift1,
                                               ProgramTitle = a.ProgramTitle
                                           }).ToList();

            return View(obj);
        }
        public IActionResult ProgramDetail(int ProgramID)
        {
            Entities.Program P = OurdbContext.Program.Where(abc => abc.ProgramId == ProgramID).FirstOrDefault();
            return View(P);
        }
        //public IActionResult ProgramDelete(int ProgramID)
        //{
        //    Program obj = OurdbContext.Program.Where(abc => abc.ProgramId == ProgramID).FirstOrDefault();
        //    OurdbContext.Program.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.ProgramList));
        //}
        public bool DeleteProgram(int Id)
        {
            try
            {
                Program P = OurdbContext.Program.Find(Id);
                if (P != null)
                {
                    OurdbContext.Program.Remove(P);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private Program CopyMPToP(ModelProgram MP)
        {
            Entities.Program P = new Entities.Program
            {
                ProgramId = MP.ProgramId,
                FkShiftId = MP.FkShiftId,
                ProgramTitle = MP.ProgramTitle,
                DateCreated = MP.DateCreated,
                DateUpdated = MP.DateUpdated,
            };
            return P;
        }
        private ModelProgram CopyPToMP(Program P)
        {
            ModelProgram MP = new ModelProgram
            {

                ProgramId = P.ProgramId,
                FkShiftId = P.FkShiftId,
                ProgramTitle = P.ProgramTitle,
                DateCreated = P.DateCreated,
                DateUpdated = P.DateUpdated,
            };
            return MP;
        }
        #endregion

        #region MERITLIST
        /******************************************************* MERITLIST SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateMeritList()
        {
            ModelMeritList ML = new ModelMeritList();
            ML.DateCreated = DateTime.Now;
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            IList<Shift> ILS = OurdbContext.Shift.ToList();
            ViewBag.vbs = ILS;

            return View(ML);
        }
        [HttpGet]
        public IActionResult UpdateMeritList(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            MeritList ML = OurdbContext.MeritList.Find(id);
            if (ML.MeritListId < 1)
            {
                return NotFound();
            }
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            IList<Shift> ILS = OurdbContext.Shift.ToList();
            ViewBag.vbs = ILS;
            return View("AddUpdateMeritList", CopyMLToMML(ML));
        }
        [HttpPost]
        public IActionResult AddUpdateMeritList(ModelMeritList MML)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MML);
            }
            try
            {
                if (MML.MeritListId > 0)
                {
                    MML.DateUpdated = DateTime.Now;
                    OurdbContext.MeritList.Update(CopyMMLToML(MML));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.MeritList.Add(CopyMMLToML(MML));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["Action"] = Constants.FAILED;
            }

            return RedirectToAction(nameof(AdministratorController.MeritListList));
        }
        public IActionResult MeritListList()
        {
            IList<ModelMeritListList> obj = (from a in OurdbContext.MeritList
                                             join b in OurdbContext.Program on a.FkProgramId equals b.ProgramId
                                             join c in OurdbContext.Shift on a.Shift equals c.Shift1
                                             select new ModelMeritListList
                                             {
                                                 ID = a.MeritListId,
                                                 FKProgramID = b.ProgramId,
                                                 ProgramTitle = b.ProgramTitle,
                                                 Shift = a.Shift,
                                                 MeritListValue = a.MeritListValue

                                             }).ToList();
            return View(obj);
        }

        public IActionResult MeritListDetail(int MeritListID)
        {
            //MeritList ML = OurdbContext.MeritList.Where(abc => abc.MeritListId == MeritListID).FirstOrDefault();
            MeritList ML = OurdbContext.MeritList.Find(MeritListID);
            return View(ML);
        }

        //public IActionResult MeritListDelete(int MeritListID)
        //{
        //    MeritList ML = OurdbContext.MeritList.Find(MeritListID);
        //    OurdbContext.MeritList.Remove(ML);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.MeritListList));
        //}
        public bool DeleteMeritList(int Id)
        {
            try
            {
                MeritList ML = OurdbContext.MeritList.Find(Id);
                if (ML != null)
                {
                    OurdbContext.MeritList.Remove(ML);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private MeritList CopyMMLToML(ModelMeritList MML)
        {
            MeritList ml = new MeritList();

            MeritList ML = new MeritList
            {
                MeritListId = MML.MeritListId,
                FkProgramId = MML.FkProgramId,
                Shift = MML.Shift,
                MeritListValue = MML.MeritListValue,
                DateCreated = MML.DateCreated,
                DateUpdated = MML.DateUpdated,

            };
            return ML;
        }
        private MeritList CopyMLToMML(MeritList ML)
        {
            ModelMeritList MML = new ModelMeritList
            {
                MeritListId = ML.MeritListId,
                FkProgramId = ML.FkProgramId,
                Shift = ML.Shift,
                MeritListValue = ML.MeritListValue,
                DateCreated = ML.DateCreated,
                DateUpdated = ML.DateUpdated,
            };
            return ML;
        }
        #endregion

        #region Admission

        /******************************************************* ADMISSION SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateAdmission()
        {
            ModelAdmission ma = new ModelAdmission();
            ma.DateCreated = DateTime.Now;
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            return View(ma);
        }
        [HttpGet]
        public IActionResult UpdateAdmission(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            Admission A = OurdbContext.Admission.Find(id);
            if (A.AdmissionId < 1)
            {
                return NotFound();
            }
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            return View("AddUpdateAdmission", CopyAToMA(A));

        }
        [HttpPost]
        public IActionResult AddUpdateAdmission(ModelAdmission MA)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MA);
            }
            try
            {
                if (MA.AdmissionId > 0)
                {
                    MA.DateUpdated = DateTime.Now;
                    OurdbContext.Admission.Update(CopyMAToA(MA));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Admission.Add(CopyMAToA(MA));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.AdmissionList));
        }

        public IActionResult AdmissionList()
        {
            IList<ModelAdmissionList> obj = (from a in OurdbContext.Admission
                                             join b in OurdbContext.Program on a.FkProgramId equals b.ProgramId
                                             select new ModelAdmissionList
                                             {
                                                 AdmissonID = a.AdmissionId,
                                                 ProgramTitle = b.ProgramTitle,
                                                 AdmissionEligibilityCriteria = a.AdmissionEligibilityCriteria,
                                                 AdmissionDocument = a.AdmissionDocument

                                             }).ToList();
            return View(obj);
        }

        public IActionResult AdmissionDetail(int AdmissionID)
        {
            Admission obj = OurdbContext.Admission.Where(abc => abc.AdmissionId == AdmissionID).FirstOrDefault<Admission>();
            return View(obj);
        }

        //public IActionResult AdmissionDelete(int AdmissionID)
        //{
        //    Admission obj = OurdbContext.Admission.Where(abc => abc.AdmissionId == AdmissionID).FirstOrDefault<Admission>();
        //    //Admission obj1 = OurdbContext.Admission.Find(AdmissionID);
        //    OurdbContext.Admission.Remove(obj);
        //    OurdbContext.SaveChanges();

        //    return RedirectToAction(nameof(AdministratorController.AdmissionList));
        //}
        public bool DeleteAdmission(int Id)
        {
            try
            {
                Admission Ad = OurdbContext.Admission.Find(Id);
                if (Ad != null)
                {
                    OurdbContext.Admission.Remove(Ad);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }           
        }

        //public string DeleteStudentAjax(Student S)
        //{
        //    System.Threading.Thread.Sleep(7000);
        //    // Student S = OurDBContext.Student.Where(abc => abc.Id == StudentID).FirstOrDefault<Student>();
        //    try
        //    {
        //        OurDBContext.Student.Remove(S);
        //        OurDBContext.SaveChanges();
        //    }
        //    catch
        //    {
        //        return "0";
        //    }
        //    return "1";
        //}

        private Admission CopyMAToA(ModelAdmission ma)
        {
            Admission A = new Admission
            {
                AdmissionId = ma.AdmissionId,
                FkProgramId = ma.FkProgramId,
                AdmissionEligibilityCriteria = ma.AdmissionEligibilityCriteria,
                AdmissionDocument = ma.AdmissionDocument,
                DateCreated = ma.DateCreated,
                DateUpdated = ma.DateUpdated,

            };
            return A;
        }

        private ModelAdmission CopyAToMA(Admission A)
        {
            ModelAdmission ma = new ModelAdmission
            {
                AdmissionId = A.AdmissionId,
                FkProgramId = A.FkProgramId,
                AdmissionEligibilityCriteria = A.AdmissionEligibilityCriteria,
                AdmissionDocument = A.AdmissionDocument,
                DateCreated = A.DateCreated,
                DateUpdated = A.DateUpdated,
            };
            return ma;
        }
        #endregion

        #region FeeStructure

        /******************************************************* FEESTRUCTURE SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateFeeStructure()
        {
            ModelFeeStructure MFS = new ModelFeeStructure();
            MFS.DateCreated = DateTime.Now.Date;
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            IList<Shift> ILS = OurdbContext.Shift.ToList();
            ViewBag.vbs = ILS;

            return View(MFS);
        }
        [HttpGet]
        public IActionResult UpdateFeeStructure(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            FeeStructure FS = OurdbContext.FeeStructure.Find(id);
            if (FS.Id < 1)
            {
                return NotFound();
            }
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            IList<Shift> ILS = OurdbContext.Shift.ToList();
            ViewBag.vbs = ILS;
            return View("AddUpdateFeeStructure", CopyFSToMFS(FS));

        }

        [HttpPost]
        public JsonResult  CheckDuplicateFee(string Year1)
        {
            bool duplicateYear1 = false;
            if(OurdbContext.FeeStructure.Where(abcd =>abcd.Year1.ToString().Contains(Year1)).Count() > 0)
            {
                duplicateYear1 = true;
            }
            return Json(duplicateYear1 == false);
        }
        [HttpPost]
        public JsonResult CheckDuplicateF(string Year2)
        {
            bool duplicateYear2 = false;
            if (OurdbContext.FeeStructure.Where(abcd => abcd.Year2.ToString().Contains(Year2)).Count() > 0)
            {
                duplicateYear2 = true;
            }
            return Json(duplicateYear2 == false);
        }
        [HttpPost]
        public IActionResult AddUpdateFeeStructure(ModelFeeStructure MFS)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MFS);
            }
            try
            {
                if (MFS.Id > 0)
                {
                    MFS.DateUpdated = DateTime.Now;
                    OurdbContext.FeeStructure.Update(CopyMFSToFS(MFS));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.FeeStructure.Add(CopyMFSToFS(MFS));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.FeeStructureList));
        }

        public IActionResult FeeStructureList()
        {
            IList<ModelFeeStructureList> obj = (from a in OurdbContext.FeeStructure
                                                join b in OurdbContext.Program on a.FkProgramId equals b.ProgramId
                                                join c in OurdbContext.Shift on b.FkShiftId equals c.ShiftId
                                                select new ModelFeeStructureList
                                                {
                                                    Id = a.Id,
                                                    ProgramTitle = b.ProgramTitle,
                                                    Shift = c.Shift1,
                                                    Year1 = a.Year1,
                                                    Year2 = a.Year2
                                                }).ToList();
            return View(obj);
        }

        public IActionResult FeeStructureDetail(int FeeStructureID)
        {
            FeeStructure obj = OurdbContext.FeeStructure.Where(abc => abc.Id == FeeStructureID).FirstOrDefault<FeeStructure>();
            return View(obj);
        }

        //public IActionResult FeeStructureDelete(int FeeStructureID)
        //{
        //    FeeStructure obj = OurdbContext.FeeStructure.Where(abc => abc.Id == FeeStructureID).FirstOrDefault<FeeStructure>();
        //    OurdbContext.FeeStructure.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.FeeStructureList));
        //}

        public bool DeleteFeeStructure(int Id)
        {
            try
            {
                FeeStructure FS = OurdbContext.FeeStructure.Find(Id);
                if (FS != null)
                {
                    OurdbContext.FeeStructure.Remove(FS);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private FeeStructure CopyMFSToFS(ModelFeeStructure MFS)
        {
            FeeStructure FS = new FeeStructure
            {
                Id = MFS.Id,
                FkProgramId = MFS.FkProgramId,
                Shift = MFS.Shift,
                Year1 = MFS.Year1,
                Year2 = MFS.Year2,
                DateCreated = MFS.DateCreated,
                DateUpdated = MFS.DateUpdated,
            };
            return FS;
        }

        private ModelFeeStructure CopyFSToMFS(FeeStructure FS)
        {
            ModelFeeStructure MFS = new ModelFeeStructure
            {
                Id = FS.Id,
                FkProgramId = FS.FkProgramId,
                Shift = FS.Shift,
                Year1 = FS.Year1,
                Year2 = FS.Year2,
                DateCreated = FS.DateCreated,
                DateUpdated = FS.DateUpdated,
            };
            return MFS;
        }
        #endregion

        #region Seats

        /******************************************************* SEATS SECTION ********************************************************/
        [HttpGet]
        public IActionResult AddUpdateSeats()
        {
            ModelSeats MS = new ModelSeats();
            MS.DateCreated = DateTime.Now.Date;
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            return View(MS);
        }
        [HttpGet]
        public IActionResult UpdateSeats(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            Seats S = OurdbContext.Seats.Find(id);
            if (S.SeatId < 1)
            {
                return NotFound();
            }
            IList<Program> ILP = OurdbContext.Program.ToList();
            ViewBag.vb = ILP;
            return View("AddUpdateSeats", CopySToMS(S));

        }
        [HttpPost]
        public IActionResult AddUpdateSeats(ModelSeats MS)
        {
            if (!ModelState.IsValid)
            {
                TempData["Action"] = Constants.FAILED;
                return View(MS);
            }
            try
            {
                if (MS.SeatId > 0)
                {
                    MS.DateUpdated = DateTime.Now;
                    OurdbContext.Seats.Update(CopyMSToS(MS));
                    OurdbContext.SaveChanges();
                }
                else
                {
                    OurdbContext.Seats.Add(CopyMSToS(MS));
                    OurdbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                TempData["action"] = Constants.FAILED;
            }
            return RedirectToAction(nameof(AdministratorController.SeatsList));
        }

        public IActionResult SeatsList()
        {
            IList<ModelSeatsList> obj = (from a in OurdbContext.Seats
                                         join b in OurdbContext.Program on a.FkProgramId equals b.ProgramId
                                         select new ModelSeatsList
                                         {
                                             Id = a.SeatId,
                                             ProgramTitle = b.ProgramTitle,
                                             TotalSeats = a.SeatsTotal,
                                             AvailAbleSeats = a.SeatsAvailable,
                                             ReserveSeats = a.SeatsReserve

                                         }).ToList();



            return View(obj);
        }

        public IActionResult SeatsDetail(int SeatsID)
        {
            Seats obj = OurdbContext.Seats.Where(abc => abc.SeatId == SeatsID).FirstOrDefault<Seats>();
            return View(obj);
        }

        //public IActionResult SeatsDelete(int SeatsID)
        //{
        //    Seats obj = OurdbContext.Seats.Where(abc => abc.SeatId == SeatsID).FirstOrDefault<Seats>();
        //    OurdbContext.Seats.Remove(obj);
        //    OurdbContext.SaveChanges();
        //    return RedirectToAction(nameof(AdministratorController.SeatsList));
        //}

        public bool DeleteSeats(int Id)
        {
            try
            {
                Seats S = OurdbContext.Seats.Find(Id);
                if (S != null)
                {
                    OurdbContext.Seats.Remove(S);
                    OurdbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        private Seats CopyMSToS(ModelSeats MS)
        {
            Seats S = new Seats
            {
                SeatId = MS.SeatId,
                FkProgramId = MS.FkProgramId,
                SeatsTotal = MS.SeatsTotal,
                SeatsAvailable = MS.SeatsAvailable,
                SeatsReserve = MS.SeatsReserve,
                DateCreated = MS.DateCreated,
                DateUpdated = MS.DateUpdated,
            };
            return S;
        }

        private ModelSeats CopySToMS(Seats S)
        {
            ModelSeats MS = new ModelSeats
            {
                SeatId = S.SeatId,
                FkProgramId = S.FkProgramId,
                SeatsTotal = S.SeatsTotal,
                SeatsAvailable = S.SeatsAvailable,
                SeatsReserve = S.SeatsReserve,
                DateCreated = S.DateCreated,
                DateUpdated = S.DateUpdated,
            };
            return MS;
        }
        #endregion


    }

}