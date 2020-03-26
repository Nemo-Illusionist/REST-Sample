using NUnit.Framework;
using Sample.Auth.Contracts;
using Sample.Auth.Services;

namespace Sample.Tests.Unit
{
    public class PasswordProviderTest
    {
        private IPasswordProvider _passwordProvider;

        [SetUp]
        public void Init()
        {
            _passwordProvider = new PasswordProvider();
        }

        [TestCase("test")]
        public void VerifyPasswordTest(string password)
        {
            var hash = _passwordProvider.CreatePasswordHash(password);
            var isVerify = _passwordProvider.VerifyPasswordHash(password,hash);
            Assert.IsTrue(isVerify);
        }
    }
}