using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PetGeneratorNameJumagbas.Models;
using System.Linq;
using System.Linq.Expressions;

namespace PetGeneratorNameJumagbas.Controllers
{
    [ApiController]
    [Route("[Controller")]
    public class PetNameGeneratorController : Controller
    {
        [HttpPost("/generate")]
        public IActionResult Post([FromQuery] AnimalType animalType, bool hasLastName)
        {
            try
            {
                string firstname = "";
                string lastname = "";
                Random random = new Random();
                int randomIndex = random.Next(0, 10);
                if (animalType == AnimalType.Dog)
                {
                    firstname = Constants.Names.Dog.First[randomIndex];
                    if (hasLastName)
                    {
                        lastname = Constants.Names.Dog.Last[randomIndex];
                    }
                }

                else if (animalType == AnimalType.Cat)
                {
                    firstname = Constants.Names.Cat.First[randomIndex];
                    if (hasLastName)
                    {
                        lastname = Constants.Names.Cat.Last[randomIndex];
                    }
                }
                else if (animalType == AnimalType.Bird)
                {
                    firstname = Constants.Names.Bird.First[randomIndex];
                    if (hasLastName)
                    {
                        lastname = Constants.Names.Bird.Last[randomIndex];
                    }
                }
                else
                {
                    return BadRequest();
             
                }   return Ok(new { firstname, lastname });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
