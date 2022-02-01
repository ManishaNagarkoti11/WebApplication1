using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public StudentController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var data = _context.Students.ToList();
            return View(data);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var data = _context.Students.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID","FirstName","LastName","Address","Phone","ImageFile")]Student student)
        {
                if (ModelState.IsValid)
                {

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(student.ImageFile.FileName);
                string extension = Path.GetExtension(student.ImageFile.FileName);
                student.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image", fileName);
                using (var fileStream=new FileStream(path, FileMode.Create))
                {
                     student.ImageFile.CopyToAsync(fileStream);
                }
                _context.Students.Add(student);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            return View(student);
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = _context.Students.Find(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Student student)
        {
            try
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int? id)
        {
            Student student = _context.Students.Find(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = _context.Students.Find(id);
                _context.Students.Remove(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
