using Microsoft.AspNetCore.Mvc;
using PokedexApi.Core.Logic;
using PokedexApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Controllers
{
    /// <summary>
    ///     Controller used to retrieve data related to <see cref="Pokemon"/>.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonLogic pokemonLogic;

        /// <summary>
        ///     Creates an instance of the <see cref="PokemonController"/> class.
        /// </summary>
        /// <param name="pokemonLogic">The <see cref="IPokemonLogic"/> class to use.</param>
        public PokemonController(IPokemonLogic pokemonLogic)
        {
            this.pokemonLogic = pokemonLogic;
        }

        /// <summary>
        ///     GET method to retrieve a single <see cref="Pokemon"/> by Id.
        /// </summary>
        /// <param name="id">Pokedex Id of the <see cref="Pokemon"/>.</param>
        /// <returns>The <see cref="Pokemon"/> that has the Id.</returns>
        [HttpGet("id/{id:int}/pokemon")]
        public IActionResult Get(int id)
        {
            if (id < 1)
            {
                return new BadRequestObjectResult($"Id must be at least 1. Id passed to the endpoint: {id}.");
            }

            var pokemon = pokemonLogic.Get(id);

            if (pokemon == null)
            {
                return new NotFoundObjectResult($"Could not find a pokemon with the Id: {id}.");
            }

            return Ok(pokemon);
        }

        /// <summary>
        ///     GET method to retrieve a list of <see cref="Pokemon"/> by Ids.
        /// </summary>
        /// <param name="ids">Pokedex Ids of the <see cref="Pokemon"/>.</param>
        /// <returns>A list of <see cref="Pokemon"/>.</returns>
        [HttpGet("pokemon")]
        public IActionResult Get([FromQuery]IList<int> ids)
        {
            if (ids.Any(id => id < 1))
            {
                return new BadRequestObjectResult("All Ids must be at least 1. One or more Ids were less than 1.");
            }

            var pokemonList = pokemonLogic.Get(ids);

            if (!pokemonList.Any())
            {
                return new NotFoundObjectResult("No Pokemon could be found with the Ids provided");
            }

            return Ok(pokemonList);
        }
    }
}
