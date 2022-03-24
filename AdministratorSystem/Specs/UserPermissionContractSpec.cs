using AdministratorSystem.Model;
using SpecificationsLib;
using System.Linq;

namespace ContractSystem.Specs
{
    public class UserPermissionContractSpec : Specification<User>
    {
        PermissionContractSpec permissionContractSpec = new PermissionContractSpec();

        public override bool IsSatisfiedBy(User user)
        {
            return user.Permissions.Any(permission => permissionContractSpec.IsSatisfiedBy(permission));
        }
    }
}
