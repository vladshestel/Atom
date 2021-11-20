using System.Text;
using Xunit;

namespace Vee.Tests
{
    public class Hash256Tests
    {
        [Fact]
        public void AssertHash()
        {
            var input = "abc";

            var binary = Encoding.UTF8.GetBytes(input);
            var hash = Sha.Hash256(binary);

            var result = Encoding.UTF8.GetString(hash);
            Assert.Equal("3a985da74fe225b2045c172d6bd390bd855f086e3e9d525b46bfe24511431532", result);
        }
    }
}