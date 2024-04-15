using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai2._1.Models;
using System.IO;
using System.Xml.Linq;

namespace bai2._1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult TestViewResult()
        {
            return View();
        }
        public PartialViewResult TestPartialViewResult()
        {
            return PartialView();
        }
        //Action trả về một View trống (null)
        public EmptyResult TestEmptyResult()
        {
            return new EmptyResult();
        }
        // Action đáp ứng việc chuyển trực tiếp tới một view khác
        public RedirectResult TestRedirectResult()
        {
            return Redirect("Index");

        }
        public JsonResult testJsonResult()
        {
            List<Student> listStudent = new List<Student>();
            listStudent.Add(new Student() { ID = 001, Name = "Đỗ Trọng Huy", Classname = "C1311L" });
            listStudent.Add(new Student() { ID = 002, Name = "Đỗ Trọng Huy", Classname = "C1311J" });
            listStudent.Add(new Student() { ID = 003, Name = "Đỗ Trọng Huy", Classname = "C1311H" });
            listStudent.Add(new Student() { ID = 004, Name = "Nguyễn Trọng Huy", Classname = "C1311T" });
            listStudent.Add(new Student() { ID = 005, Name = "Tạ Trọng Huy", Classname = "C1311C" });
            listStudent.Add(new Student() { ID = 006, Name = "Vũ Trọng Huy", Classname = "C1311L" });
            listStudent.Add(new Student() { ID = 007, Name = "Phạm Trọng Huy", Classname = "C1311B" });
            listStudent.Add(new Student() { ID = 008, Name = "Ngô Trọng Huy", Classname = "C1311L" });
            listStudent.Add(new Student() { ID = 009, Name = "Trịnh Trọng Huy", Classname = "C1311M" });
            listStudent.Add(new Student() { ID = 010, Name = "Lê Trọng Huy", Classname = "C1311L" });
            return Json(listStudent, JsonRequestBehavior.AllowGet);
        }
        public JavaScriptResult TestJavaScriptResult()
        {
            string js = "funtion checkEMail(){var btloc=/^([w-]+(?:.[w-]+)*)@((?:[w -] +.) * w[w -]{ 0,66}).([a - z]{ 2,6} (?:.[a - z]{ 2})?)$/ i if (btloc.test(mail)) { kq = true; } else { alert(“Email address invalid”); kq = false;} return kq; }";
            return JavaScript(js);
        }
        public ContentResult TestContentResult()
        {
            XElement contentXML = new XElement("Students",
                    new XElement("Student", "ID", "001", "FullName", "Nguyễn Viết Nam", "ClassName", "C1308H"),
                    new XElement("Student", "ID", "002", "FullName", "Nguyễn Hoàng Anh", "ClassName", "C1411P"),
                    new XElement("Student", "ID", "003", "FullName", "Phạm Ngọc Anh", "ClassName", "C1411L"),
                    new XElement("Student", "ID", "004", "FullName", "Trần Ngọc Linh", "ClassName", "C1411H"),
                    new XElement("Student", "ID", "005", "FullName", "Nguyễn Hồng Anh", "ClassName", "C1411L"));
            return Content(contentXML.ToString(), "text/xml", System.Text.Encoding.UTF8);
        }
        public FileContentResult TestFileContentResult()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/demovideo.mp4"));
            string fileName = "demovideo.mp4";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            return File(fileBytes, "video/mp4", fileName);
        }
        public FileStreamResult TestFileStreamResult()
        {
            string pathFile = Server.MapPath("~/Content/vonsong.docx");
            string fileName = "vonsong.docx";
            return File(new FileStream(pathFile, FileMode.Open), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }

        public FilePathResult TestFilePathResult()
        {
            string pathFile = Server.MapPath("~/Content/vonsong.docx");
            string fileName = "vonsong.docx";
            return File(pathFile, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }



    }
}