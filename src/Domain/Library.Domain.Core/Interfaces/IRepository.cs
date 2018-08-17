namespace Library.Domain.Core.Interfaces
{
    public interface IRepository<T, TId>
        : ICommandRepository<T, TId>, IQueryRepository<T, TId>
    {

    }
}
