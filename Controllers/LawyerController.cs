using IntroductoryProject3._1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace IntroductoryProject3._1.Controllers
{
    public class LawyerController : ApiController
    {
        public LawyerController()
        {
        }




        //Get action methods of the previous section
        public IHttpActionResult PostNewLawyer(LawyerViewModel lawyer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new LawyerDbEntities())
            {
                ctx.Lawyers.Add(new Lawyer()
                {
                    Id = lawyer.Id,
                    Name = lawyer.Name,
                    Surname = lawyer.Surname,
                    Initials = lawyer.Initials,
                    DateOfBirth = lawyer.DateOfBirth,
                    Email = lawyer.Email,
                    Gender = lawyer.Gender,
                    Title = lawyer.Title
                });

                ctx.SaveChanges();
            }

            return Ok();
        }



        public IHttpActionResult GetAllLawyers()
        {
            IList<LawyerViewModel> lawyers = null;

            using (var ctx = new LawyerDbEntities())
            {
                lawyers = ctx.Lawyers.Include("Name").Select(l => new LawyerViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Surname = l.Surname,
                    Initials = l.Initials,
                    DateOfBirth = l.DateOfBirth,
                    Email = l.Email,
                    Gender = (short)l.Gender,
                    Title = (short)l.Title

                }).ToList<LawyerViewModel>();
            }

            if (lawyers == null)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }

        public IHttpActionResult GetAllLawyers(int lid)
        {
            LawyerViewModel student = null;

            using (var ctx = new LawyerDbEntities())
            {
                student = ctx.Lawyers.Include("Name")
                    .Where(l => l.Id == lid)
                    .Select(l => new LawyerViewModel()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender = (short)l.Gender,
                        Title = (short)l.Title
                    }).FirstOrDefault<LawyerViewModel>();
            }

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        public IHttpActionResult GetAllLawyers(string name, string surname)
        {
            IList<LawyerViewModel> lawyers = null;

            using (var ctx = new LawyerDbEntities())
            {
                lawyers = ctx.Lawyers.Include("Name").Include("Surname")
                    .Where(l => l.Name.ToLower() == name.ToLower() && l.Surname.ToLower() == surname.ToLower())
                    .Select(l => new LawyerViewModel()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender = (short)l.Gender,
                        Title = (short)l.Title

                    }).ToList<LawyerViewModel>();
            }

            if (lawyers.Count == 0)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }

        public IHttpActionResult GetByName(string name)
        {
            IList<LawyerViewModel> lawyers = null;

            using (var ctx = new LawyerDbEntities())
            {
                lawyers = ctx.Lawyers.Include("Name")
                    .Where(l => l.Name.ToLower() == name.ToLower())
                    .Select(l => new LawyerViewModel()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender = (short)l.Gender,
                        Title = (short)l.Title

                    }).ToList<LawyerViewModel>();
            }

            if (lawyers.Count == 0)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }


        public IHttpActionResult GetBySurname(string surname)
        {
            IList<LawyerViewModel> lawyers = null;

            using (var ctx = new LawyerDbEntities())
            {
                lawyers = ctx.Lawyers.Include("Surname")
                    .Where(l => l.Surname.ToLower() == surname.ToLower())
                    .Select(l => new LawyerViewModel()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender = (short)l.Gender,
                        Title = (short)l.Title

                    }).ToList<LawyerViewModel>();
            }

            if (lawyers.Count == 0)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }


        public IHttpActionResult Put(LawyerViewModel lawyer)
        {
           

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new LawyerDbEntities())
            {
                
                var existingLawyer = ctx.Lawyers.Where(l => l.Id == lawyer.Id)
                                                        .FirstOrDefault<Lawyer>();

                if (existingLawyer != null)
                {
                    

                  

                    existingLawyer.Name = lawyer.Name;
                    existingLawyer.Surname = lawyer.Surname;
                    existingLawyer.Initials = lawyer.Initials;
                    existingLawyer.DateOfBirth = lawyer.DateOfBirth;
                    existingLawyer.Email = lawyer.Email;
                    existingLawyer.Gender = lawyer.Gender;
                    existingLawyer.Title = lawyer.Title;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid lawyer id");

            using (var ctx = new LawyerDbEntities())
            {
                var lawyer = ctx.Lawyers
                    .Where(l => l.Id == id)
                    .FirstOrDefault();

                ctx.Entry(lawyer).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }




}


