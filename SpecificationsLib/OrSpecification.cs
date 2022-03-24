namespace SpecificationsLib
{
    public class OrSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right) : base(left, right) { }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return left.IsSatisfiedBy(candidate) || right.IsSatisfiedBy(candidate);
        }
    }
}
