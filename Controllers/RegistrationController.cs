using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistrationForms2.Models;

namespace RegistrationForms2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            using(REGISTRATIONEntities db=new REGISTRATIONEntities())
            {
                List<selfInformation> selfInformation = db.selfInformations.ToList();
                List<Gender> genders = db.Genders.ToList();
                List<Language> languages = db.Languages.ToList();
                List<Education> educations = db.Educations.ToList();
                List<Experiance> experiances = db.Experiances.ToList();
                var RegisterData = from e in selfInformation
                                   join d in genders on e.self_Id equals d.selfe_Id into table1
                                   from d in table1.ToList()
                                   join l in languages on e.self_Id equals l.self_FK into table2
                                   from l in table2.ToList()
                                   join s in educations on e.self_Id equals s.self_Id_fk into table3
                                   from s in table3.ToList()
                                   join p in experiances on e.self_Id equals p.self_Id_fk_fk into table4
                                   from p in table4.ToList()
                                   select new selfInformation
                                   {
                                       self_Id=e.self_Id,
                                       FirstName=e.FirstName,
                                       MiddileName=e.MiddileName,
                                       LastName=e.LastName,
                                       DateofBirth=e.DateofBirth,
                                       PhoneNumber=e.PhoneNumber,
                                       PhoneNumber2=e.PhoneNumber2,
                                       Email=e.Email,
                                       PresentAddress=e.PresentAddress,
                                       PermanentAdress=e.PermanentAdress,
                                       Gender1=d.Gender1,
                                       Language1=l.Language1,
                                       read1=l.read1,
                                       speak1=l.speak1,
                                       write1=l.write1,
                                       understand1=l.understand1,
                                       Language2 = l.Language2,
                                       read2 = l.read2,
                                       speak2 = l.speak2,
                                       write2 = l.write2,
                                       understand2 = l.understand2,
                                       Language3= l.Language3,
                                       read3 = l.read3,
                                       speak3 = l.speak3,
                                       write3 = l.write3,
                                       understand3 = l.understand3,
                                       Language4 = l.Language4,
                                       read4 = l.read4,
                                       speak4 = l.speak4,
                                       write4 = l.write4,
                                       understand4 = l.understand4,
                                       Degree=s.Degree,
                                       Course=s.Course,
                                       Program_course=s.Program_course,
                                       Elective=s.Elective,
                                       CollegeName=s.CollegeName,
                                       UniversityName=s.UniversityName,
                                       fromYear=s.fromYear,
                                       Toyear=s.Toyear,
                                       percentageYear=s.percentageYear,
                                       GDate=s.GDate,
                                       CompanyName1=p.CompanyName1,
                                       YearOF1=p.YearOF1,
                                       Position1=p.Position1,
                                       CompanyName2=p.CompanyName2,
                                       YearOF2=p.YearOF2,
                                       Position2=p.Position2,
                                       CompanyName3=p.CompanyName3,
                                       YearOF3=p.YearOF3,
                                       Position3=p.Position3


                                   };
                return View(RegisterData);

            }
           
        }

        public ActionResult Create()
        {
            REGISTRATIONEntities db = new REGISTRATIONEntities();
            List<selfInformation> selfInformation = db.selfInformations.ToList();
            List<Gender> genders = db.Genders.ToList();
            List<Language> languages = db.Languages.ToList();
            List<Education> educations = db.Educations.ToList();
            List<Experiance> experiances = db.Experiances.ToList();
            return View();

        }
        [HttpPost]
        public ActionResult Create(selfInformation vm)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    REGISTRATIONEntities db = new REGISTRATIONEntities();
                    List<selfInformation> selfInformation = db.selfInformations.ToList();
                    List<Gender> genders = db.Genders.ToList();
                    List<Language> languages = db.Languages.ToList();
                    List<Education> educations = db.Educations.ToList();
                    List<Experiance> experiances = db.Experiances.ToList();
                    if (vm.self_Id==0)
                    {
                       
                        selfInformation s = new selfInformation();
                        s.FirstName = vm.FirstName;
                        s.MiddileName = vm.MiddileName;
                        s.LastName = vm.LastName;
                        s.DateofBirth = vm.DateofBirth;
                        s.PhoneNumber = vm.PhoneNumber;
                        s.PresentAddress = vm.PresentAddress;
                        s.PermanentAdress = vm.PermanentAdress;
                        s.Email = vm.Email;
                        db.selfInformations.Add(s);
                        db.SaveChanges();
                        int NewSelfid = s.self_Id;

                        Gender g = new Gender();

                        g.selfe_Id = NewSelfid;
                        db.Genders.Add(g);
                        db.SaveChanges();

                        Language l = new Language();
                        l.Language1 = vm.Language1;
                        l.read1 = vm.read1;
                        l.write1 = vm.write1;
                        l.speak1 = vm.speak1;
                        l.understand1 = vm.understand1;
                        l.Language2 = vm.Language2;
                        l.read2 = vm.read2;
                        l.write2 = vm.write2;
                        l.speak2 = vm.speak2;
                        l.understand2 = vm.understand2;
                        l.Language3 = vm.Language3;
                        l.read3 = vm.read3;
                        l.write3 = vm.write3;
                        l.speak3 = vm.speak3;
                        l.understand3 = vm.understand3;
                        l.Language4 = vm.Language4;
                        l.read4 = vm.read4;
                        l.write4 = vm.write4;
                        l.speak4 = vm.speak4;
                        l.understand4 = vm.understand4;
                        l.self_FK = NewSelfid;




                        db.Languages.Add(l);
                        db.SaveChanges();

                        Education ed = new Education();
                        ed.Degree = vm.Degree;
                        ed.Course = vm.Course;
                        ed.Program_course = vm.Program_course;
                        ed.Elective = vm.Elective;
                        ed.CollegeName = vm.CollegeName;
                        ed.UniversityName = vm.UniversityName;
                        ed.fromYear = vm.fromYear;
                        ed.Toyear = vm.Toyear;
                        ed.percentageYear = vm.percentageYear;
                        ed.GDate = vm.GDate;
                        ed.self_Id_fk = NewSelfid;
                        db.Educations.Add(ed);
                        db.SaveChanges();

                        Experiance ex = new Experiance();
                        ex.CompanyName1 = vm.CompanyName1;
                        ex.Position1 = vm.Position1;
                        ex.YearOF1 = vm.YearOF1;
                        ex.CompanyName2 = vm.CompanyName2;
                        ex.Position2 = vm.Position2;
                        ex.YearOF2 = vm.YearOF2;
                        ex.CompanyName3 = vm.CompanyName3;
                        ex.Position3 = vm.Position3;
                        ex.YearOF3 = vm.YearOF3;
                        ex.self_Id_fk_fk = NewSelfid;
                        db.Experiances.Add(ex);
                        db.SaveChanges();
                        ModelState.Clear();

                    }
                   

                    return RedirectToAction("Create");
                }
                return View();

            }
            catch (Exception)
            {

                throw;
            }


        }

        public ActionResult Edit(int? id)
        {

            REGISTRATIONEntities db = new REGISTRATIONEntities();
            List<selfInformation> selfInformation = db.selfInformations.ToList();
            List<Gender> genders = db.Genders.ToList();
            List<Language> languages = db.Languages.ToList();
            List<Education> educations = db.Educations.ToList();
            List<Experiance> experiances = db.Experiances.ToList();

            var u = (from e in selfInformation
                     join d in genders on e.self_Id equals d.selfe_Id into table1
                     from d in table1.ToList()
                     join l in languages on e.self_Id equals l.self_FK into table2
                     from l in table2.ToList()
                     join s in educations on e.self_Id equals s.self_Id_fk into table3
                     from s in table3.ToList()
                     join p in experiances on e.self_Id equals p.self_Id_fk_fk into table4
                     from p in table4.ToList()
                     select new selfInformation
                     {
                         self_Id = e.self_Id,
                         FirstName = e.FirstName,
                         MiddileName = e.MiddileName,
                         LastName = e.LastName,
                         DateofBirth = e.DateofBirth,
                         PhoneNumber = e.PhoneNumber,
                         PhoneNumber2 = e.PhoneNumber2,
                         Email = e.Email,
                         PresentAddress = e.PresentAddress,
                         PermanentAdress = e.PermanentAdress,
                         Gender1 = d.Gender1,
                         Language1 = l.Language1,
                         read1 = l.read1,
                         speak1 = l.speak1,
                         write1 = l.write1,
                         understand1 = l.understand1,
                         Language2 = l.Language2,
                         read2 = l.read2,
                         speak2 = l.speak2,
                         write2 = l.write2,
                         understand2 = l.understand2,
                         Language3 = l.Language3,
                         read3 = l.read3,
                         speak3 = l.speak3,
                         write3 = l.write3,
                         understand3 = l.understand3,
                         Language4 = l.Language4,
                         read4 = l.read4,
                         speak4 = l.speak4,
                         write4 = l.write4,
                         understand4 = l.understand4,
                         Degree = s.Degree,
                         Course = s.Course,
                         Program_course = s.Program_course,
                         Elective = s.Elective,
                         CollegeName = s.CollegeName,
                         UniversityName = s.UniversityName,
                         fromYear = s.fromYear,
                         Toyear = s.Toyear,
                         percentageYear = s.percentageYear,
                         GDate = s.GDate,
                         CompanyName1 = p.CompanyName1,
                         YearOF1 = p.YearOF1,
                         Position1 = p.Position1,
                         CompanyName2 = p.CompanyName2,
                         YearOF2 = p.YearOF2,
                         Position2 = p.Position2,
                         CompanyName3 = p.CompanyName3,
                         YearOF3 = p.YearOF3,
                         Position3 = p.Position3
                     }).FirstOrDefault();
            return View(u);





        }
        [HttpPost]
        public ActionResult Edit(int? id,selfInformation self)
        {
            REGISTRATIONEntities db = new REGISTRATIONEntities();
            List<selfInformation> selfInformation = db.selfInformations.ToList();
            List<Gender> genders = db.Genders.ToList();
            List<Language> languages = db.Languages.ToList();
            List<Education> educations = db.Educations.ToList();
            List<Experiance> experiances = db.Experiances.ToList();

            var u = db.selfInformations.FirstOrDefault(x => x.self_Id == id);

            if(u != null)
            {
                u.FirstName = self.FirstName;
                u.MiddileName = self.MiddileName;
                u.LastName = self.LastName;
                u.DateofBirth = self.DateofBirth;
                u.PhoneNumber = self.PhoneNumber;
                u.PhoneNumber2 = self.PhoneNumber2;
                u.PresentAddress = self.PresentAddress;
                u.PermanentAdress = self.PermanentAdress;
                u.Gender1 = self.Gender1;
                u.Language1 = self.Language1;
                u.read1 = self.read1;
                u.write1 = self.write1;
                u.speak1 = self.speak1;
                u.understand1 = u.understand1;
                u.Language2 = self.Language2;
                u.read2 = self.read2;
                u.write2 = self.write2;
                u.speak2 = self.speak2;
                u.understand2 = u.understand2;
                u.Language3 = self.Language3;
                u.read3 = self.read3;
                u.write3 = self.write3;
                u.speak3 = self.speak3;
                u.understand3 = u.understand3;
                u.Language4 = self.Language4;
                u.read4 = self.read4;
                u.write4= self.write4;
                u.speak4 = self.speak4;
                u.understand4 = u.understand4;


                u.Degree = self.Degree;
                u.Course = self.Course;
                u.Program_course = self.Program_course;
                u.Elective = self.Elective;
                u.CollegeName = self.CollegeName;
                u.UniversityName = self.UniversityName;
                u.fromYear = self.fromYear;
                u.Toyear = self.Toyear;
                u.GDate = self.GDate;
                u.CompanyName1 = self.CompanyName1;
                u.Position1 = self.Position1;
                u.YearOF1 = self.YearOF1;
                u.CompanyName2 = self.CompanyName1;
                u.Position2 = self.Position1;
                u.YearOF2 = self.YearOF1;
                u.CompanyName3 = self.CompanyName3;
                u.Position3 = self.Position3;
                u.YearOF3 = self.YearOF3;
                u.CollegeName = self.CollegeName;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            return View();
        }

        public ActionResult Delete()
        {
            REGISTRATIONEntities db = new REGISTRATIONEntities();
            List<selfInformation> selfInformation = db.selfInformations.ToList();
            List<Gender> genders = db.Genders.ToList();
            List<Language> languages = db.Languages.ToList();
            List<Education> educations = db.Educations.ToList();
            List<Experiance> experiances = db.Experiances.ToList();

            var u = (from e in selfInformation
                     join d in genders on e.self_Id equals d.selfe_Id into table1
                     from d in table1.ToList()
                     join l in languages on e.self_Id equals l.self_FK into table2
                     from l in table2.ToList()
                     join s in educations on e.self_Id equals s.self_Id_fk into table3
                     from s in table3.ToList()
                     join p in experiances on e.self_Id equals p.self_Id_fk_fk into table4
                     from p in table4.ToList()
                     select new selfInformation
                     {
                         self_Id = e.self_Id,
                         FirstName = e.FirstName,
                         MiddileName = e.MiddileName,
                         LastName = e.LastName,
                         DateofBirth = e.DateofBirth,
                         PhoneNumber = e.PhoneNumber,
                         PhoneNumber2 = e.PhoneNumber2,
                         Email = e.Email,
                         PresentAddress = e.PresentAddress,
                         PermanentAdress = e.PermanentAdress,
                         Gender1 = d.Gender1,
                         Language1 = l.Language1,
                         read1 = l.read1,
                         speak1 = l.speak1,
                         write1 = l.write1,
                         understand1 = l.understand1,
                         Language2 = l.Language2,
                         read2 = l.read2,
                         speak2 = l.speak2,
                         write2 = l.write2,
                         understand2 = l.understand2,
                         Language3 = l.Language3,
                         read3 = l.read3,
                         speak3 = l.speak3,
                         write3 = l.write3,
                         understand3 = l.understand3,
                         Language4 = l.Language4,
                         read4 = l.read4,
                         speak4 = l.speak4,
                         write4 = l.write4,
                         understand4 = l.understand4,
                         Degree = s.Degree,
                         Course = s.Course,
                         Program_course = s.Program_course,
                         Elective = s.Elective,
                         CollegeName = s.CollegeName,
                         UniversityName = s.UniversityName,
                         fromYear = s.fromYear,
                         Toyear = s.Toyear,
                         percentageYear = s.percentageYear,
                         GDate = s.GDate,
                         CompanyName1 = p.CompanyName1,
                         YearOF1 = p.YearOF1,
                         Position1 = p.Position1,
                         CompanyName2 = p.CompanyName2,
                         YearOF2 = p.YearOF2,
                         Position2 = p.Position2,
                         CompanyName3 = p.CompanyName3,
                         YearOF3 = p.YearOF3,
                         Position3 = p.Position3
                     }).FirstOrDefault();
            return View(u);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {

            REGISTRATIONEntities db = new REGISTRATIONEntities();
            List<selfInformation> selfInformation = db.selfInformations.ToList();
            List<Gender> genders = db.Genders.ToList();
            List<Language> languages = db.Languages.ToList();
            List<Education> educations = db.Educations.ToList();
            List<Experiance> experiances = db.Experiances.ToList();

            var u = db.selfInformations.FirstOrDefault(x => x.self_Id == id);
            if (u != null)
            {
                db.selfInformations.Remove(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();



        }






    }







    }
