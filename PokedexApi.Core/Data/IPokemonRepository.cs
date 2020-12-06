using PokedexApi.Core.Models;
using System.Collections.Generic;

namespace PokedexApi.Core.Data
{
    /// <summary>
    ///     Interface for classes built to retrieve <see cref="Pokemon"/> from
    ///     a data source.
    /// </summary>
    public interface IPokemonRepository
    {
        /// <summary>
        ///     Get <see cref="Pokemon"/> by Id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Pokemon"/> being requested.</param>
        /// <returns>The <see cref="Pokemon"/> with the Id passed in from the Id parameter.</returns>
        Pokemon Get(int id);

        /// <summary>
        ///     Get <see cref="Pokemon"/> by Id.
        /// </summary>
        /// <param name="ids">Ids of the <see cref="Pokemon"/> being requested.</param>
        /// <returns>A list of <see cref="Pokemon"/> who's Id is in the Ids parameter.</returns>
        IList<Pokemon> Get(IList<int> ids);
    }
}
