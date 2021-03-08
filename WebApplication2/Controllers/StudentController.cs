﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModel;
using WebApplication2.Dao;

namespace WebApplication2.Controllers
{
    public class StudentController : BaseController
    {
        managerteacher db = new managerteacher();
        public bool isThemMoi;
        // GET: Student
        public ActionResult Index()
        {
            var listStudent = new List<StudentViewModel>();
            db.Students.ToList().ForEach(student =>
            {
                listStudent.Add(new StudentViewModel(student.ID, student.Name_Student, student.ClassID, student.DateOfBirth, student.Address, student.Email, student.Phone));
            });
            ViewBag.listStudent = listStudent;
            List<Class> listClass = db.Classes.OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.listClass = listClass;
            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Students.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }

        public ActionResult Add(Student model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {
                    model.Name_Student = model.Name_Student.ToString().Trim() ?? "";
                    model.DateOfBirth = model.DateOfBirth;
                    model.Address = model.Address.ToString().Trim() ?? "";
                    model.Email = model.Email ?? "";
                    model.Phone = model.Phone.ToString().Trim() ?? "";
                    model.ClassID = model.ClassID;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);


                    db.Students.Add(model);
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Thêm thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Cập Nhật")
            {
                isThemMoi = false;
                if (model != null)
                {
                    var list = db.Students.SingleOrDefault(x => x.ID == model.ID);
                    list.Name_Student = model.Name_Student.ToString().Trim();
                    list.DateOfBirth = model.DateOfBirth;
                    list.Address = model.Address.ToString().Trim();
                    list.Email = model.Email;
                    list.Phone = model.Phone.ToString().Trim();
                    list.ClassID = model.ClassID;
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name_Student))
                {
                    List<Student> list = GetData().Where(s => s.Name_Student.Contains(model.Name_Student)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<Student> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<Student> list = GetData().OrderBy(s => s.Name_Student).ToList();
                return View("Index", list);
            }
        }
        public List<Student> GetData()
        {
            return db.Students.ToList();


        }
        public ActionResult Delete(int id)
        {
            new StudentDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }
    }
}