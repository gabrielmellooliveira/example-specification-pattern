namespace SpecificationsLib
{
    public class NotSpecification<TEntity> : Specification<TEntity>
    {
        protected readonly ISpecification<TEntity> specification;

        public NotSpecification(ISpecification<TEntity> specification)
        {
            this.specification = specification;
        }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return !specification.IsSatisfiedBy(candidate);
        }
    }
}
