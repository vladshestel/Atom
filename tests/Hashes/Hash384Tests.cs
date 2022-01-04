using System.Text;
using Xunit;

namespace Vee.Tests
{
    public class Hash384Tests
    {
        [Fact]
        public void PikachuHash()
        {
            var input = "pikachu";
            var binary = Encoding.UTF8.GetBytes(input);
            
            var hash = Sha.Hash384(binary);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "0a1c27456f43a6ad0346db9c058953d16842abd47b8bdee255d9cb0a962b620650f70e95cde8d811c7bcc0d80ed1db9b",
                serialized
            );
        }

        [Fact]
        public void MewtwoHash()
        {
            var input = "mewtwo";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.Hash384(binary);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "4309c8cb2ecefb7dc650097ae00f29158988e2e51253319cbeb8a8b831c5bbd7fa2f452496e86e73c750612f220c0333",
                serialized
            );
        }

        [Fact]
        public void FirstGenerationHash()
        {
            var input = "Bulbasaur, Ivysaur, Venusaur, Charmander, Charmeleon, Charizard, Squirtle, Wartortle, Blastoise, Caterpie, Metapod, Butterfree, Weedle, Kakuna, Beedrill, Pidgey, Pidgeotto, Pidgeot, Rattata, Raticate, Spearow, Fearow, Ekans, Arbok, Pikachu, Raichu, Sandshrew, Sandslash, Nidoran♀, Nidorina, Nidoqueen, Nidoran♂, Nidorino, Nidoking, Clefairy, Clefable, Vulpix, Ninetales, Jigglypuff, Wigglytuff, Zubat, Golbat, Oddish, Gloom, Vileplume, Paras, Parasect, Venonat, Venomoth, Diglett, Dugtrio, Meowth, Persian, Psyduck, Golduck, Mankey, Primeape, Growlithe, Arcanine, Poliwag, Poliwhirl, Poliwrath, Abra, Kadabra, Alakazam, Machop, Machoke, Machamp, Bellsprout, Weepinbell, Victreebel, Tentacool, Tentacruel, Geodude, Graveler, Golem, Ponyta, Rapidash, Slowpoke, Slowbro, Magnemite, Magneton, Farfetch'd, Doduo, Dodrio, Seel, Dewgong, Grimer, Muk, Shellder, Cloyster, Gastly, Haunter, Gengar, Onix, Drowzee, Hypno, Krabby, Kingler, Voltorb, Electrode, Exeggcute, Exeggutor, Cubone, Marowak, Hitmonlee, Hitmonchan, Lickitung, Koffing, Weezing, Rhyhorn, Rhydon, Chansey, Tangela, Kangaskhan, Horsea, Seadra, Goldeen, Seaking, Staryu, Starmie, Mr. Mime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magikarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon, Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.Hash384(binary);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "2ec545ccf030c3678716edadaa0da0c76401bec1c254e9f39ca97b3e5b25d037416d62eb4863e15a7daf43578bfb96c6",
                serialized
            );
        }
    }
}