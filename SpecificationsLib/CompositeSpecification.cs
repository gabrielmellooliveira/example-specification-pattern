namespace SpecificationsLib
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
    {
        protected readonly ISpecification<TEntity> left;

        protected readonly ISpecification<TEntity> right;

        protected CompositeSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
