using System.Text;
using Xunit;

namespace Vee.Tests
{
    public class Sponge384Tests
    {
        [Fact]
        public void PikachuHash()
        {
            var sponge = Sha.CreateSha384Sponge();
            var input = "pikachu";
            var binary = Encoding.UTF8.GetBytes(input);

            sponge.Absorb(binary);
            var hash = sponge.Hash();

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "0a1c27456f43a6ad0346db9c058953d16842abd47b8bdee255d9cb0a962b620650f70e95cde8d811c7bcc0d80ed1db9b",
                serialized
            );
        }

        [Fact]
        public void PikachuAndMewtwoHash()
        {
            var sponge = Sha.CreateSha384Sponge();
            var pikachu = "pikachu";
            var pikachuBinary = Encoding.UTF8.GetBytes(pikachu);
            var mewtwo = "mewtwo";
            var mewtwoBinary = Encoding.UTF8.GetBytes(mewtwo);

            sponge.Absorb(pikachuBinary);
            sponge.Absorb(mewtwoBinary);
            var hash = sponge.Hash();

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "8469093dccbb60a05f77193c44da9b539511f3b19500a90394d120a6dd758528612cbf7d9154a546f400604cbabbd4c7",
                serialized
            );
        }

        [Fact]
        public void FirstGenerationHash()
        {
            var sponge = Sha.CreateSha384Sponge();
            var input = "Bulbasaur, Ivysaur, Venusaur, Charmander, Charmeleon, Charizard, Squirtle, Wartortle, Blastoise, Caterpie, Metapod, Butterfree, Weedle, Kakuna, Beedrill, Pidgey, Pidgeotto, Pidgeot, Rattata, Raticate, Spearow, Fearow, Ekans, Arbok, Pikachu, Raichu, Sandshrew, Sandslash, Nidoran♀, Nidorina, Nidoqueen, Nidoran♂, Nidorino, Nidoking, Clefairy, Clefable, Vulpix, Ninetales, Jigglypuff, Wigglytuff, Zubat, Golbat, Oddish, Gloom, Vileplume, Paras, Parasect, Venonat, Venomoth, Diglett, Dugtrio, Meowth, Persian, Psyduck, Golduck, Mankey, Primeape, Growlithe, Arcanine, Poliwag, Poliwhirl, Poliwrath, Abra, Kadabra, Alakazam, Machop, Machoke, Machamp, Bellsprout, Weepinbell, Victreebel, Tentacool, Tentacruel, Geodude, Graveler, Golem, Ponyta, Rapidash, Slowpoke, Slowbro, Magnemite, Magneton, Farfetch'd, Doduo, Dodrio, Seel, Dewgong, Grimer, Muk, Shellder, Cloyster, Gastly, Haunter, Gengar, Onix, Drowzee, Hypno, Krabby, Kingler, Voltorb, Electrode, Exeggcute, Exeggutor, Cubone, Marowak, Hitmonlee, Hitmonchan, Lickitung, Koffing, Weezing, Rhyhorn, Rhydon, Chansey, Tangela, Kangaskhan, Horsea, Seadra, Goldeen, Seaking, Staryu, Starmie, Mr. Mime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magikarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon, Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew";
            var binary = Encoding.UTF8.GetBytes(input);

            sponge.Absorb(binary);
            var hash = sponge.Hash();

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "2ec545ccf030c3678716edadaa0da0c76401bec1c254e9f39ca97b3e5b25d037416d62eb4863e15a7daf43578bfb96c6",
                serialized
            );
        }
    }
}