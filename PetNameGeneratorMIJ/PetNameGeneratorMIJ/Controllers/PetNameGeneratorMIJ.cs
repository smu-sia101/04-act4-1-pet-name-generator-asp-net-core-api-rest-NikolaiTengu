using Microsoft.AspNetCore.Mvc;
using PetNameGeneratorMIJ.Models;
using System.Linq;

namespace PetNameGeneratorMIJ.Controllers
{
    public class PetNameGeneratorMIJ : Controller
    {
        public string[] Dogs =
                {
           "Fluffy", "Spot", "Rover", "Spike", "Fido", "Whiskers", "Mittens", "Snowball", "Buddy", "Max", "Lycaon"
        };

        public string[] Birds =
        {
            "Polly", "Tweety", "Pidgey", "Hedwig", "Zazu", "Iago", "Scuttle", "Kevin", "Blu", "Penguin", "Pidgeotto"
        };

        public string[] Cats =
        {
            "Whiskers", "Mittens", "Snowball", "Fluffy", "Spot", "Rover", "Spike", "Fido", "Buddy", "Max", "Lycaon"
        };

        [HttpPost("generate")]
        public ActionResult<string> Generate([FromBody] GenerateRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.AnimalType))
            {
                return BadRequest("AnimalType is required.");
            }

            string[] names;
            switch (request.AnimalType.ToLower())
            {
                case "dog":
                    names = Dogs;
                    break;
                case "cat":
                    names = Cats;
                    break;
                case "bird":
                    names = Birds;
                    break;
                default:
                    return BadRequest("Invalid AnimalType. Must be 'dog', 'cat', or 'bird'.");
            }

            var random = new Random();
            var index = random.Next(names.Length);
            var name = names[index];

            if (request.TwoPart)
            {
                var secondIndex = random.Next(names.Length);
                name += " " + names[secondIndex];
            }

            return Ok(name);
        }

        [HttpGet("get")]
        public string Get()
        {
            var random = new Random();
            var index = random.Next(Dogs.Length);
            return Dogs[index];
        }

        [HttpPost("{name}")]
        public ActionResult Post([FromRoute] string name)
        {
            string[] newName = { name };
            Dogs = Dogs.Concat(newName).ToArray();
            return Ok(Dogs);
        }
    }
}
