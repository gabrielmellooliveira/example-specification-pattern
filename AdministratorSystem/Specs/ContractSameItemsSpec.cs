using AdministratorSystem.Model;
using SpecificationsLib;

namespace ContractSystem.Specs
{
    public class ContractSameItemsSpec : Specification<Contract>
    {
        public override bool IsSatisfiedBy(Contract contract)
        {
            return contract.Name == contract.Name || contract.RegisterCode == contract.RegisterCode;
        }
    }
}
