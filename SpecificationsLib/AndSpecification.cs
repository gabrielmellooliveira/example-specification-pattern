namespace SpecificationsLib
{
    public class AndSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right) : base(left, right) { }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return left.IsSatisfiedBy(candidate) && right.IsSatisfiedBy(candidate);
        }
    }
}
