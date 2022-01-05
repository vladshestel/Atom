using System.Text;
using Xunit;

namespace Vee.Tests
{
    public class ExtendableHash128Tests
    {
        [Fact]
        public void PikachuHash()
        {
            var input = "pikachu";
            var binary = Encoding.UTF8.GetBytes(input);
            
            var hash = Sha.ExtendableHash(binary, 100);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "4ae5cc89140af096a1d20bb925f8b2e11ba419469c48b1e70a295267610468a1dd849931b1f95a940949a5e1bec81085f23dc04a700218da1b7e61079b47e4789601493db638e3116fe1ac63f1bff9ff4d6e6761529f9cd81c73d045fe6897378ad59686",
                serialized
            );
        }

        [Fact]
        public void MewtwoHash()
        {
            var input = "mewtwo";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.ExtendableHash(binary, 100);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "aa2108603b7f8cec67648b289beeec27f7e501a157d9e7b6bddf1dc2bc6548fd81e69df60c3dafd4faab8b4d1187d4a2f9b310e16179ab565eaecbc3c571eec62f3fb9ec4f76d532c55dfa26ede302133eb9520290bc6d5e54d3260823d3cf283bc43ebd",
                serialized
            );
        }

        [Fact]
        public void FirstGenerationHash()
        {
            var input = "Bulbasaur, Ivysaur, Venusaur, Charmander, Charmeleon, Charizard, Squirtle, Wartortle, Blastoise, Caterpie, Metapod, Butterfree, Weedle, Kakuna, Beedrill, Pidgey, Pidgeotto, Pidgeot, Rattata, Raticate, Spearow, Fearow, Ekans, Arbok, Pikachu, Raichu, Sandshrew, Sandslash, Nidoran♀, Nidorina, Nidoqueen, Nidoran♂, Nidorino, Nidoking, Clefairy, Clefable, Vulpix, Ninetales, Jigglypuff, Wigglytuff, Zubat, Golbat, Oddish, Gloom, Vileplume, Paras, Parasect, Venonat, Venomoth, Diglett, Dugtrio, Meowth, Persian, Psyduck, Golduck, Mankey, Primeape, Growlithe, Arcanine, Poliwag, Poliwhirl, Poliwrath, Abra, Kadabra, Alakazam, Machop, Machoke, Machamp, Bellsprout, Weepinbell, Victreebel, Tentacool, Tentacruel, Geodude, Graveler, Golem, Ponyta, Rapidash, Slowpoke, Slowbro, Magnemite, Magneton, Farfetch'd, Doduo, Dodrio, Seel, Dewgong, Grimer, Muk, Shellder, Cloyster, Gastly, Haunter, Gengar, Onix, Drowzee, Hypno, Krabby, Kingler, Voltorb, Electrode, Exeggcute, Exeggutor, Cubone, Marowak, Hitmonlee, Hitmonchan, Lickitung, Koffing, Weezing, Rhyhorn, Rhydon, Chansey, Tangela, Kangaskhan, Horsea, Seadra, Goldeen, Seaking, Staryu, Starmie, Mr. Mime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magikarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon, Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.ExtendableHash(binary, 100);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "cb093d05b43c83250b4c964e28ddf33143edd4edf055a987f44777665e0204be30f0f33899ca999214db5512050bab28c15af50f771c69b42a201aae15db39fc166d2170a60c42bac0d1115b909ab2eaf95054eb4d51a592941486ecbcf3782aef6e8bb0",
                serialized
            );
        }
    }
}