using AdministratorSystem.Model;
using SpecificationsLib;

namespace ContractSystem.Specs
{
    public class PermissionContractSpec : Specification<Permission>
    {
        public override bool IsSatisfiedBy(Permission permission)
        {
            return permission.Context.Tag == "CONTRACT";
        }
    }
}
