using AdministratorSystem.Model;
using SpecificationsLib;

namespace ContractSystem.Specs
{
    public class UserProfileToContractSpec : Specification<User>
    {
        UserProfileAdministratorSpec userProfileAdministratorSpec = new UserProfileAdministratorSpec();
        UserProfileManagerSpec userProfileManagerSpec = new UserProfileManagerSpec();

        public override bool IsSatisfiedBy(User user)
        {
            return userProfileAdministratorSpec.Or(userProfileManagerSpec).IsSatisfiedBy(user);
        }
    }
}
