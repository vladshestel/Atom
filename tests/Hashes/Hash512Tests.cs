using System.Text;
using Xunit;

namespace Vee.Tests
{
    public class Hash512Tests
    {
        [Fact]
        public void PikachuHash()
        {
            var input = "pikachu";
            var binary = Encoding.UTF8.GetBytes(input);
            
            var hash = Sha.Hash512(binary);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "f5ac008e2ce307bda7f3ea501751603eb6a4ff598c1febacc41597b7cd17f436d9dd2369403dc234bc94ded9af51d35aaa5e2ea7b2ce627a67a60957d1c70f7b",
                serialized
            );
        }

        [Fact]
        public void MewtwoHash()
        {
            var input = "mewtwo";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.Hash512(binary);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "259139f2e09b36be27e5f6f428aee69d15a6b5723ac7e6347eb7c9316a807b693b1b63612c597b320fd578451385498939983faae8ba702b4b1c82bd23d46618",
                serialized
            );
        }

        [Fact]
        public void FirstGenerationHash()
        {
            var input = "Bulbasaur, Ivysaur, Venusaur, Charmander, Charmeleon, Charizard, Squirtle, Wartortle, Blastoise, Caterpie, Metapod, Butterfree, Weedle, Kakuna, Beedrill, Pidgey, Pidgeotto, Pidgeot, Rattata, Raticate, Spearow, Fearow, Ekans, Arbok, Pikachu, Raichu, Sandshrew, Sandslash, Nidoran♀, Nidorina, Nidoqueen, Nidoran♂, Nidorino, Nidoking, Clefairy, Clefable, Vulpix, Ninetales, Jigglypuff, Wigglytuff, Zubat, Golbat, Oddish, Gloom, Vileplume, Paras, Parasect, Venonat, Venomoth, Diglett, Dugtrio, Meowth, Persian, Psyduck, Golduck, Mankey, Primeape, Growlithe, Arcanine, Poliwag, Poliwhirl, Poliwrath, Abra, Kadabra, Alakazam, Machop, Machoke, Machamp, Bellsprout, Weepinbell, Victreebel, Tentacool, Tentacruel, Geodude, Graveler, Golem, Ponyta, Rapidash, Slowpoke, Slowbro, Magnemite, Magneton, Farfetch'd, Doduo, Dodrio, Seel, Dewgong, Grimer, Muk, Shellder, Cloyster, Gastly, Haunter, Gengar, Onix, Drowzee, Hypno, Krabby, Kingler, Voltorb, Electrode, Exeggcute, Exeggutor, Cubone, Marowak, Hitmonlee, Hitmonchan, Lickitung, Koffing, Weezing, Rhyhorn, Rhydon, Chansey, Tangela, Kangaskhan, Horsea, Seadra, Goldeen, Seaking, Staryu, Starmie, Mr. Mime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magikarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon, Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.Hash512(binary);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "7a6aad36a705f9ae3bb9ccd6adb41efc96003db65a7a7320c4a6cc261f6202fc08a1c7693c9ba6a80ccbc3d738752804f603cddafef6967a4e3c30e910af9da4",
                serialized
            );
        }
    }
}