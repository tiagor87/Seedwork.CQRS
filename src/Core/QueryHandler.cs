namespace Seedwork.CQRS.Core
{
    public abstract class QueryHandler<T, TResponse> : CommandHandler<T, TResponse>
        where T : Query<TResponse>
    {
    }
}