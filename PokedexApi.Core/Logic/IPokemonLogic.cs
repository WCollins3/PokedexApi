using PokedexApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokedexApi.Core.Logic
{
    /// <summary>
    ///     Interface for logic classes built to retrieve <see cref="Pokemon"/> objects.
    /// </summary>
    public interface IPokemonLogic
    {
        /// <summary>
        ///     Get a single <see cref="Pokemon"/> by Id.
        /// </summary>
        /// <param name="id">Pokedex Id of the <see cref="Pokemon"/>.</param>
        /// <returns>The <see cref="Pokemon"/> that has the Id.</returns>
        Pokemon Get(int id);

        /// <summary>
        ///     Get a list of <see cref="Pokemon"/> by a list of Ids.
        /// </summary>
        /// <param name="ids">Pokedex Ids of the <see cref="Pokemon"/>.</param>
        /// <returns>
        ///     The <see cref="Pokemon"/> who have an Id within the list of
        ///     Ids passed in as a parameter.
        /// </returns>
        IList<Pokemon> Get(IList<int> ids);
    }
}
