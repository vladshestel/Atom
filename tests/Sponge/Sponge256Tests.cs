using System.Text;
using Xunit;

namespace Vee.Tests
{
    public class Sponge256Tests
    {
        [Fact]
        public void PikachuHash()
        {
            var sponge = Sha.CreateSha256Sponge();
            var input = "pikachu";
            var binary = Encoding.UTF8.GetBytes(input);

            sponge.Absorb(binary);
            var hash = sponge.Hash();

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal("93784094c0b4969cf4401bbfcf70f877a5f70a1f99843cb6eb882b6aa207ad0d", serialized);
        }

        [Fact]
        public void PikachuAndMewtwoHash()
        {
            var sponge = Sha.CreateSha256Sponge();
            var pikachu = "pikachu";
            var pikachuBinary = Encoding.UTF8.GetBytes(pikachu);
            var mewtwo = "mewtwo";
            var mewtwoBinary = Encoding.UTF8.GetBytes(mewtwo);

            sponge.Absorb(pikachuBinary);
            sponge.Absorb(mewtwoBinary);
            var hash = sponge.Hash();

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal("64fd34f3981242fc69dfda621bfcf9bfe043fb3b045ce1b7783d8ba393446f13", serialized);
        }

        [Fact]
        public void FirstGenerationHash()
        {
            var sponge = Sha.CreateSha256Sponge();
            var input = "Bulbasaur, Ivysaur, Venusaur, Charmander, Charmeleon, Charizard, Squirtle, Wartortle, Blastoise, Caterpie, Metapod, Butterfree, Weedle, Kakuna, Beedrill, Pidgey, Pidgeotto, Pidgeot, Rattata, Raticate, Spearow, Fearow, Ekans, Arbok, Pikachu, Raichu, Sandshrew, Sandslash, Nidoran♀, Nidorina, Nidoqueen, Nidoran♂, Nidorino, Nidoking, Clefairy, Clefable, Vulpix, Ninetales, Jigglypuff, Wigglytuff, Zubat, Golbat, Oddish, Gloom, Vileplume, Paras, Parasect, Venonat, Venomoth, Diglett, Dugtrio, Meowth, Persian, Psyduck, Golduck, Mankey, Primeape, Growlithe, Arcanine, Poliwag, Poliwhirl, Poliwrath, Abra, Kadabra, Alakazam, Machop, Machoke, Machamp, Bellsprout, Weepinbell, Victreebel, Tentacool, Tentacruel, Geodude, Graveler, Golem, Ponyta, Rapidash, Slowpoke, Slowbro, Magnemite, Magneton, Farfetch'd, Doduo, Dodrio, Seel, Dewgong, Grimer, Muk, Shellder, Cloyster, Gastly, Haunter, Gengar, Onix, Drowzee, Hypno, Krabby, Kingler, Voltorb, Electrode, Exeggcute, Exeggutor, Cubone, Marowak, Hitmonlee, Hitmonchan, Lickitung, Koffing, Weezing, Rhyhorn, Rhydon, Chansey, Tangela, Kangaskhan, Horsea, Seadra, Goldeen, Seaking, Staryu, Starmie, Mr. Mime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magikarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon, Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew";
            var binary = Encoding.UTF8.GetBytes(input);

            sponge.Absorb(binary);
            var hash = sponge.Hash();

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal("5f64740542f5f8f6397e0034ba0527bc32fd368d832d902dadee0a2d178d0ff7", serialized);
        }
    }
}