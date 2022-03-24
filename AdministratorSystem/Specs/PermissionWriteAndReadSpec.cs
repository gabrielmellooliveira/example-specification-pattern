using AdministratorSystem.Model;
using SpecificationsLib;

namespace ContractSystem.Specs
{
    public class PermissionWriteAndReadSpec : Specification<Permission>
    {
        public override bool IsSatisfiedBy(Permission permission)
        {
            return permission.Type == PermissionType.WRITE || permission.Type == PermissionType.READ_AND_WRITE;
        }
    }
}
