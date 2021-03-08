﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            GetClass();
        }
        public StudentViewModel(int studentID, string name_Student, int classID, DateTime dateOfBirth, string address, string email, string phone)
        {
            ID = studentID;
            Name_Student = name_Student;
            ClassID = classID;
            DateOfBirth = dateOfBirth;
            Address = address;
            Email = email;
            Phone = phone;
            GetClass();
        }
        public int ID { get; set; }
        [DisplayName("Tên học sinh")]
        public string Name_Student { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DisplayName("Mã lớp")]
        public int ClassID { get; set; }
        [DisplayName("Tên lớp")]
        public string ClassName { get; set; }

        public void GetClass()
        {
            if (ClassID > 0)
            {
                using (managerteacher db = new managerteacher())
                {
                    this.ClassName = db.Classes.Find(this.ClassID) != null ?
                        db.Classes.Find(this.ClassID).Name : string.Empty;
                }
            }
        }
    }
}