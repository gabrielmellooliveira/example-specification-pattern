namespace AdministratorSystem.Model
{
    public class Permission
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public PermissionType Type { get; set; }
        public PermissionContext Context { get; set; }
    }
}
