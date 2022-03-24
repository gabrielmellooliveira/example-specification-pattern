using AdministratorSystem.Model;
using ContractSystem.Specs;
using NUnit.Framework;

namespace ContractSystem.Tests
{
    [TestFixture]
    public class UserProfileManagerSpecTest
    {
        [Test]
        public void UserProfileIsManager()
        {
            var userProfileManagerSpec = new UserProfileManagerSpec();

            var user = new User();

            user.Profile = new Profile() { Name = "Manager" };

            bool result = userProfileManagerSpec.IsSatisfiedBy(user);

            Assert.True(result, "User is manager");
        }

        [Test]
        public void UserProfileIsNotManager()
        {
            var userProfileManagerSpec = new UserProfileManagerSpec();

            var user = new User();

            user.Profile = new Profile() { Name = "Administrator" };

            bool result = userProfileManagerSpec.IsSatisfiedBy(user);

            Assert.False(result, "User is not manager");
        }
    }
}
