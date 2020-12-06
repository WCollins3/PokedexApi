using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokedexApi.Core.Data;
using PokedexApi.Core.Enums;
using PokedexApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokedexApi.Logic.Tests
{
    /// <summary>
    ///     Tests for the <see cref="PokemonLogic"/> class.
    /// </summary>
    [TestClass]
    public class PokemonLogicTests
    {
        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s single-Id Get method returns
        ///     the <see cref="Pokemon"/> that the <see cref="IPokemonRepository"/>
        ///     returns when a valid Id is passed.
        /// </summary>
        [TestMethod]
        public void Get_Single_Id_Valid()
        {
            int id = 1;

            var pokemon = new Pokemon
            {
                Id = 1,
                Name = "Bulbasaur",
                Types = new List<PokemonType> {
                    PokemonType.Grass,
                    PokemonType.Poison,
                },
                Weaknesses = new List<PokemonType> {
                    PokemonType.Fire,
                    PokemonType.Psychic,
                    PokemonType.Flying,
                    PokemonType.Ice,
                },
                Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
            };

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);
            repository.Setup(x => x.Get(id))
                .Returns(pokemon);

            var logic = new PokemonLogic(repository.Object);
            var result = logic.Get(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(pokemon.Name, result.Name);
            Assert.AreEqual(pokemon.Types.Count, result.Types.Count);
            for (int i = 0; i < pokemon.Types.Count; i++)
            {
                Assert.AreEqual(pokemon.Types[i], result.Types[i]);
            }

            Assert.AreEqual(pokemon.Weaknesses.Count, result.Weaknesses.Count);
            for (int i = 0; i < pokemon.Weaknesses.Count; i++)
            {
                Assert.AreEqual(pokemon.Weaknesses[i], result.Weaknesses[i]);
            }

            Assert.AreEqual(pokemon.Description, result.Description);
            repository.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s single-Id Get method returns
        ///     a null value if the <see cref="IPokemonRepository"/> returns a null value.
        /// </summary>
        [TestMethod]
        public void Get_Single_Id_Repository_Returns_Null_Valid()
        {
            int id = 1;

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);
            repository.Setup(x => x.Get(id))
                .Returns((Pokemon) null);

            var logic = new PokemonLogic(repository.Object);
            var result = logic.Get(id);

            Assert.IsNull(result);
            repository.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s single-Id Get method throws
        ///     an <see cref="InvalidOperationException"/> when 0 is passed in as the
        ///     Id parameter.
        /// </summary>
        [TestMethod]
        public void Get_Single_Id_Zero_Throws_InvalidOperationException()
        {
            int id = 0;

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);

            var logic = new PokemonLogic(repository.Object);

            var ex = Assert.ThrowsException<InvalidOperationException>(() => logic.Get(id));

            Assert.AreEqual($"Id must be at least 1. Id parameter: {id}.", ex.Message);
            repository.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s single-Id Get method throws
        ///     an <see cref="InvalidOperationException"/> when a negative number is
        ///     passed in as the Id parameter.
        /// </summary>
        [TestMethod]
        public void Get_Single_Id_Negative_Throws_InvalidOperationException()
        {
            int id = -1;

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);

            var logic = new PokemonLogic(repository.Object);

            var ex = Assert.ThrowsException<InvalidOperationException>(() => logic.Get(id));

            Assert.AreEqual($"Id must be at least 1. Id parameter: {id}.", ex.Message);
            repository.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s list-Ids Get method returns
        ///     the <see cref="Pokemon"/> list that the <see cref="IPokemonRepository"/>
        ///     returns when a valid Id list is passed.
        /// </summary>
        [TestMethod]
        public void Get_List_Ids_Valid()
        {
            var ids = new List<int>
            {
                1,
                2,
            };

            var pokemon1 = new Pokemon
            {
                Id = 1,
                Name = "Bulbasaur",
                Types = new List<PokemonType> {
                    PokemonType.Grass,
                    PokemonType.Poison,
                },
                Weaknesses = new List<PokemonType> {
                    PokemonType.Fire,
                    PokemonType.Psychic,
                    PokemonType.Flying,
                    PokemonType.Ice,
                },
                Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
            };

            var pokemon2 = new Pokemon
            {
                Id = 2,
                Name = "Ivysaur",
                Types = new List<PokemonType> {
                    PokemonType.Grass,
                    PokemonType.Poison,
                },
                Weaknesses = new List<PokemonType> {
                    PokemonType.Fire,
                    PokemonType.Psychic,
                    PokemonType.Flying,
                    PokemonType.Ice,
                },
                Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
            };

            var pokemonList = new List<Pokemon>
            {
                pokemon1,
                pokemon2,
            };

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);
            repository.Setup(x => x.Get(ids))
                .Returns(pokemonList);

            var logic = new PokemonLogic(repository.Object);
            var resultList = logic.Get(ids);

            Assert.IsNotNull(resultList);
            Assert.AreEqual(pokemonList.Count, resultList.Count);
            for (int i = 0; i < pokemonList.Count; i++)
            {
                var pokemon = pokemonList[i];
                var result = resultList[i];

                Assert.AreEqual(pokemon.Id, result.Id);
                Assert.AreEqual(pokemon.Name, result.Name);
                Assert.AreEqual(pokemon.Types.Count, result.Types.Count);
                for (int j = 0; j < pokemon.Types.Count; j++)
                {
                    Assert.AreEqual(pokemon.Types[j], result.Types[j]);
                }

                Assert.AreEqual(pokemon.Weaknesses.Count, result.Weaknesses.Count);
                for (int j = 0; j < pokemon.Weaknesses.Count; j++)
                {
                    Assert.AreEqual(pokemon.Weaknesses[j], result.Weaknesses[j]);
                }

                Assert.AreEqual(pokemon.Description, result.Description);
            }

            repository.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s list-Ids Get method returns
        ///     a null value if the <see cref="IPokemonRepository"/> returns a null value.
        /// </summary>
        [TestMethod]
        public void Get_List_Ids_Repository_Returns_Null_Valid()
        {
            var ids = new List<int>
            {
                1,
                2,
            };

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);
            repository.Setup(x => x.Get(ids))
                .Returns((IList<Pokemon>) null);

            var logic = new PokemonLogic(repository.Object);
            var resultList = logic.Get(ids);

            Assert.IsNull(resultList);
            repository.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s list-Ids Get method throws
        ///     an <see cref="InvalidOperationException"/> when 0 is passed in as one
        ///     of the values in the ids list.
        /// </summary>
        [TestMethod]
        public void Get_List_Ids_Zero_Throws_InvalidOperationException()
        {
            var ids = new List<int>
            {
                1,
                0,
            };

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);

            var logic = new PokemonLogic(repository.Object);

            var ex = Assert.ThrowsException<InvalidOperationException>(() => logic.Get(ids));

            Assert.AreEqual("All Ids must be at least 1. One or more Ids were less than 1.", ex.Message);
            repository.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonLogic"/>'s list-Ids Get method throws
        ///     an <see cref="InvalidOperationException"/> when a negative number is
        ///     passed in as one of the values in the ids list.
        /// </summary>
        [TestMethod]
        public void Get_List_Ids_Negative_Throws_InvalidOperationException()
        {
            var ids = new List<int>
            {
                1,
                -1,
            };

            var repository = new Mock<IPokemonRepository>(MockBehavior.Strict);

            var logic = new PokemonLogic(repository.Object);

            var ex = Assert.ThrowsException<InvalidOperationException>(() => logic.Get(ids));

            Assert.AreEqual("All Ids must be at least 1. One or more Ids were less than 1.", ex.Message);
            repository.VerifyAll();
        }
    }
}
