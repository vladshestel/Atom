using System.Text;
using Xunit;

namespace Vee.Tests
{
    public class ExtendableHash256Tests
    {
        [Fact]
        public void PikachuHash()
        {
            var input = "pikachu";
            var binary = Encoding.UTF8.GetBytes(input);
            
            var hash = Sha.ExtendableHashStrong(binary, 1024 / 8);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "44c2a0455dda7cd00335bc115db6230b2b6a8f03823589f6377542e7927d8a58b7b9e96317e8940eabca5f5672a08cfc805a3433bd3eacdc160f421ed26d9559d306223cd6a94ae1fe781786114755528fc9a76d55e146f5c8b27702db398926d5e7e5af7082c841ad0f10b1f00186a1882f5fe6ae544ea984ca8c1394d9eaa0",
                serialized
            );
        }

        [Fact]
        public void MewtwoHash()
        {
            var input = "mewtwo";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.ExtendableHashStrong(binary, 1024 / 8);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "2595bfa150a09e111b4cdc3f731520d0f078725bdf18de726fdfffe8b38324ac98ced6fd462571dd15c92a5b987b12f261296cc4c6342bc4671e10be1ae8d7b8232f1e826dfb163870bd7af0d7a0b9a5da4a352a1b9592a828cdb970881719c3e6865dfaa15ddaadc7e5a9bee952b4f6cac30bac259fb0e2b55ff8b229b048fe",
                serialized
            );
        }

        [Fact]
        public void FirstGenerationHash()
        {
            var input = "Bulbasaur, Ivysaur, Venusaur, Charmander, Charmeleon, Charizard, Squirtle, Wartortle, Blastoise, Caterpie, Metapod, Butterfree, Weedle, Kakuna, Beedrill, Pidgey, Pidgeotto, Pidgeot, Rattata, Raticate, Spearow, Fearow, Ekans, Arbok, Pikachu, Raichu, Sandshrew, Sandslash, Nidoran♀, Nidorina, Nidoqueen, Nidoran♂, Nidorino, Nidoking, Clefairy, Clefable, Vulpix, Ninetales, Jigglypuff, Wigglytuff, Zubat, Golbat, Oddish, Gloom, Vileplume, Paras, Parasect, Venonat, Venomoth, Diglett, Dugtrio, Meowth, Persian, Psyduck, Golduck, Mankey, Primeape, Growlithe, Arcanine, Poliwag, Poliwhirl, Poliwrath, Abra, Kadabra, Alakazam, Machop, Machoke, Machamp, Bellsprout, Weepinbell, Victreebel, Tentacool, Tentacruel, Geodude, Graveler, Golem, Ponyta, Rapidash, Slowpoke, Slowbro, Magnemite, Magneton, Farfetch'd, Doduo, Dodrio, Seel, Dewgong, Grimer, Muk, Shellder, Cloyster, Gastly, Haunter, Gengar, Onix, Drowzee, Hypno, Krabby, Kingler, Voltorb, Electrode, Exeggcute, Exeggutor, Cubone, Marowak, Hitmonlee, Hitmonchan, Lickitung, Koffing, Weezing, Rhyhorn, Rhydon, Chansey, Tangela, Kangaskhan, Horsea, Seadra, Goldeen, Seaking, Staryu, Starmie, Mr. Mime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magikarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon, Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew";
            var binary = Encoding.UTF8.GetBytes(input);

            var hash = Sha.ExtendableHashStrong(binary, 1024 / 8);

            var serialized = string.Join(string.Empty, hash.ToArray().Select(_byte => _byte.ToString("x2")));
            Assert.Equal(
                "8d09679c19d3d149da507731c6702bdce7e4ea44b6760669b4c133e8fc779d64fcadf59125910e3f0b9ede06df3838c96c1f51ba849dc44af60dfdb3dd5c1b006b814e027612bd12978fb5aff5f034523d3efcb4286911d8c5841140f15c0591502ac13dfd011ea4350fb1659ffcd0503fda2586f7faa8c84245e68537ea2132",
                serialized
            );
        }
    }
}