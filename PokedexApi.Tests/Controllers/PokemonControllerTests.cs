using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokedexApi.Controllers;
using PokedexApi.Core.Enums;
using PokedexApi.Core.Logic;
using PokedexApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokedexApi.Tests.Controllers
{
    /// <summary>
    ///     Tests for the <see cref="PokemonController"/> class.
    /// </summary>
    [TestClass]
    public class PokemonControllerTests
    {
        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s single-Id Get method
        ///     returns an Ok result with a <see cref="Pokemon"/> when the
        ///     <see cref="IPokemonLogic"/> object returns a <see cref="Pokemon"/>.
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

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);
            logic.Setup(x => x.Get(id))
                .Returns(pokemon);

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            logic.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s single-Id Get method
        ///     returns a BadRequestObjectResult when a zero is passed in the id parameter.
        /// </summary>
        [TestMethod]
        public void Get_Single_Id_Zero_Returns_BadRequestObjectResult()
        {
            int id = 0;

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(id);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            logic.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s single-Id Get method
        ///     returns a BadRequestObjectResult when a negative number is passed in the
        ///     id parameter.
        /// </summary>
        [TestMethod]
        public void Get_Single_Id_Negative_Returns_BadRequestObjectResult()
        {
            int id = -1;

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(id);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            logic.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s single-Id Get method
        ///     returns NotFoundObjectResult when the <see cref="IPokemonLogic"/> object
        ///     returns a null value.
        /// </summary>
        [TestMethod]
        public void Get_Single_Id_Null_Pokemon_Returns_NotFoundObjectResult()
        {
            int id = 1;

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);
            logic.Setup(x => x.Get(id))
                .Returns((Pokemon) null);

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
            logic.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s list-Ids Get method
        ///     returns an Ok result with a <see cref="Pokemon"/> when the
        ///     <see cref="IPokemonLogic"/> object returns a list of <see cref="Pokemon"/>.
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

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);
            logic.Setup(x => x.Get(ids))
                .Returns(pokemonList);

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(ids);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            logic.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s list-Ids Get method
        ///     returns a BadRequestObjectResult when a zero is one of the values
        ///     passed in the ids parameter.
        /// </summary>
        [TestMethod]
        public void Get_List_Ids_Zero_Returns_BadRequestObjectResult()
        {
            var ids = new List<int>
            {
                1,
                0,
            };

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(ids);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            logic.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s list-Ids Get method
        ///     returns a BadRequestObjectResult when a negative number is one of
        ///     the values passed in the ids parameter.
        /// </summary>
        [TestMethod]
        public void Get_List_Ids_Negative_Returns_BadRequestObjectResult()
        {
            var ids = new List<int>
            {
                1,
                -1,
            };

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(ids);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            logic.VerifyAll();
        }

        /// <summary>
        ///     Test that the <see cref="PokemonController"/>'s single-Id Get method
        ///     returns NotFoundObjectResult when the <see cref="IPokemonLogic"/> object
        ///     returns an empty list.
        /// </summary>
        [TestMethod]
        public void Get_List_Ids_Empty_Pokemon_List_Returns_NotFoundObjectResult()
        {
            var ids = new List<int>
            {
                1,
                2,
            };

            var logic = new Mock<IPokemonLogic>(MockBehavior.Strict);
            logic.Setup(x => x.Get(ids))
                .Returns(new List<Pokemon>());

            var controller = new PokemonController(logic.Object);
            var result = controller.Get(ids);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
            logic.VerifyAll();
        }
    }
}
