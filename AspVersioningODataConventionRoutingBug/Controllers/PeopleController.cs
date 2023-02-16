using Asp.Versioning;
using AspVersioningODataConventionRoutingBug.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AspVersioningODataConventionRoutingBug.Controllers
{
    [ApiVersion(1)]
    public class PeopleController : ODataController
    {
        // e.g. ~/people
        public IActionResult Get()
        {
            return Ok(new List<Person>());
        }

        // e.g. ~/people/1
        public IActionResult Get(int key)
        {
            return Ok(new Person() { Id = key, Name = "X" });
        }

        // e.g. ~/people/1/name
        public IActionResult GetName(int key)
        {
            return Ok("X");
        }

        // e.g. ~/people/1/children
        public IActionResult GetChildren(int key)
        {
            return Ok(new List<Child>());
        }
    }
}
