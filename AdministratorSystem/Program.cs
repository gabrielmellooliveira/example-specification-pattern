using AdministratorSystem.Model;
using AdministratorSystem.Service;
using System.Collections.Generic;
using System.Linq;
using ContractSystem.Specs;

namespace ContractSystem
{
    class Program
    {
        private static ContractService _contractService;

        static void Main(string[] args)
        {
            _contractService = new ContractService();
        }

        // Regra 1: Para buscar os contratos o usuário deve ter perfil de (administrador ou gerente) 
        //          e ter alguma permissão do contexto dos contratos
        // Regra 2: Os contratos serão carregados por gerente ou serão carregados todos os contratos 
        //          caso seja um administrador
        static List<Contract> GetContracts(User user)
        {
            List<Contract> contracts = new List<Contract>();

            if ((user.Profile.Name == "Administrator" || user.Profile.Name == "Manager") &&
                user.Permissions.Any(permission => permission.Context.Tag == "CONTRACT"))
            {
                if (user.Profile.Name == "Manager")
                {
                    contracts = _contractService.GetByManager(user.Profile.Name);
                }
                else
                {
                    contracts = _contractService.GetAll();
                }
            }

            return contracts;
        }

        // Regra 1: Para criar um contrato o usuário deve ter perfil de (administrador ou gerente) 
        //          e ter alguma permissão do contexto dos contratos do tipo escrita ou leitura e escrita
        // Regra 2: Não deve existir um contrato com o mesmo nome ou mesmo código de registro
        static void CreateContract(Contract contract, User user)
        {
            if ((user.Profile.Name == "Administrator" || user.Profile.Name == "Manager") &&
                user.Permissions.Any(permission =>
                    (permission.Type == PermissionType.WRITE || permission.Type == PermissionType.READ_AND_WRITE) &&
                    permission.Context.Tag == "CONTRACT"
                ))
            {
                List<Contract> contracts = _contractService.GetAll();

                if (!contracts.Any(cont => cont.Name == contract.Name || cont.RegisterCode == contract.RegisterCode))
                {
                    _contractService.Create(contract);
                }
            }
        }

        static List<Contract> _GetContracts(User user)
        {
            List<Contract> contracts = new List<Contract>();

            var userProfileToContractSpec = new UserProfileToContractSpec();
            var userProfileManagerSpec = new UserProfileManagerSpec();

            var userPermissionsContractSpec = new UserPermissionContractSpec();

            if (userProfileToContractSpec.And(userPermissionsContractSpec).IsSatisfiedBy(user))
            {
                if (userProfileManagerSpec.IsSatisfiedBy(user))
                {
                    contracts = _contractService.GetByManager(user.Profile.Name);
                }
                else
                {
                    contracts = _contractService.GetAll();
                }
            }

            return contracts;
        }

        static void _CreateContract(Contract contract, User user)
        {
            var profileToContractSpec = new UserProfileToContractSpec();

            var permissionContractSpec = new PermissionContractSpec();
            var permissionWriteAndReadSpec = new PermissionWriteAndReadSpec();

            if (profileToContractSpec.IsSatisfiedBy(user) &&
                user.Permissions.Any(permission => 
                permissionContractSpec.And(permissionWriteAndReadSpec).IsSatisfiedBy(permission)
            )) {
                List<Contract> contracts = _contractService.GetAll();

                var contractSameItemsSpec = new ContractSameItemsSpec();

                if (!contracts.Any(cont => contractSameItemsSpec.IsSatisfiedBy(cont)))
                {
                    _contractService.Create(contract);
                }
            }
        }
    }
}
