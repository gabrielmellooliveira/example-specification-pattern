using AdministratorSystem.Model;
using SpecificationsLib;

namespace ContractSystem.Specs
{
    public class UserProfileManagerSpec : Specification<User>
    {
        public override bool IsSatisfiedBy(User user)
        {
            return user.Profile.Name == "Manager";
        }
    }
}
