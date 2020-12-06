using PokedexApi.Core.Enums;
using System.Collections.Generic;

namespace PokedexApi.Core.Models
{
    public class Pokemon
    {
        /// <summary>
        ///     Pokedex ID number of the <see cref="Pokemon"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Name of the <see cref="Pokemon"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Type(s) of the <see cref="Pokemon"/>.
        /// </summary>
        public IList<PokemonType> Types { get; set; }

        /// <summary>
        ///     Types of attacks that this <see cref="Pokemon"/> is weak to.
        /// </summary>
        public IList<PokemonType> Weaknesses { get; set; }

        /// <summary>
        ///     Pokedex description of the <see cref="Pokemon"/>.
        /// </summary>
        public string Description { get; set; }
    }
}
