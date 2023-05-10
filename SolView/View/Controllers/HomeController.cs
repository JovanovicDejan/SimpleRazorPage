using Microsoft.AspNetCore.Mvc;
using View.Models;

namespace View.Controllers
{
    public class HomeController : Controller
    {

        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {


            
            ViewData["appTitle"] = "Asp.Net core demo app";
            List<Person> people = new List<Person>()
            {
                new Person() {Name = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                new Person() {Name = "Linda", DateOfBirth = DateTime.Parse("1995-07-12"), PersonGender = Gender.Female},
                new Person() {Name = "Susan", DateOfBirth = DateTime.Parse("2003-02-02"), PersonGender = Gender.Other}
            };
            //ViewData["people"] = people;
            //ViewBag.people = people;
            //Convert.ToDateTime("2004-07-01")
            return View(people);  //Views/Home/Index.cshtml
            //return View("abc"); //abc.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if(name == null)
                return Content("Person name can't be null");
            List<Person> people = new List<Person>()
            {
                new Person() {Name = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                new Person() {Name = "Linda", DateOfBirth = DateTime.Parse("1995-07-12"), PersonGender = Gender.Female},
                new Person() {Name = "Susan", DateOfBirth = DateTime.Parse("2003-02-02"), PersonGender = Gender.Other}
            };
            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();
            return View(matchingPerson);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { Name = "Sara", PersonGender = Gender.Female, DateOfBirth = Convert.ToDateTime("2004-07-01") };

            Products product = new Products() { ProductID = 1, ProductName = "Air conditioner" };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product };
            return View(personAndProductWrapperModel);
        }


        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
        }
    }
}
