using PokedexApi.Core.Data;
using PokedexApi.Core.Logic;
using PokedexApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokedexApi.Logic
{
    /// <summary>
    ///     This class is built to provide <see cref="Pokemon"/> to controllers.
    /// </summary>
    public class PokemonLogic : IPokemonLogic
    {
        private readonly IPokemonRepository pokemonRepository;

        /// <summary>
        ///     Created an instance of the <see cref="PokemonLogic"/> class.
        /// </summary>
        /// <param name="pokemonRepository">The <see cref="IPokemonRepository"/> to use.</param>
        public PokemonLogic(IPokemonRepository pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;
        }

        /// <inheritdoc/>
        public Pokemon Get(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException($"Id must be at least 1. Id parameter: {id}.");
            }

            var pokemon = pokemonRepository.Get(id);
            return pokemon;
        }

        /// <inheritdoc/>
        public IList<Pokemon> Get(IList<int> ids)
        {
            if (ids.Any(id => id < 1))
            {
                throw new InvalidOperationException("All Ids must be at least 1. One or more Ids were less than 1.");
            }

            var pokemonList = pokemonRepository.Get(ids);
            return pokemonList;
        }
    }
}
