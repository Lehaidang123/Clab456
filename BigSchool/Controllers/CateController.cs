using BigSchool.ViewModels;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool.Models;

namespace BigSchool.Controllers
{
    public class CateController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CateController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Cate
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            var category = new Models.Category();
            try
            {

                if (category.uploadimg != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(category.uploadimg.FileName);
                    string extension = Path.GetExtension(category.uploadimg.FileName);
                    filename = filename + extension;
                    category.Name = "~/Content/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Content/Images/"), filename);


                }
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");



            }
            catch
            {
                return View(category);
            }

        }

    }
}