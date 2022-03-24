namespace SpecificationsLib
{
    public interface ISpecification<TEntity>
    {
        public bool IsSatisfiedBy(TEntity candidate);
    }
}
