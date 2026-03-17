namespace Application.Queries.AikidoEvents
{
    public class GetAikidoEventByIdQuery
    {
        public int Id { get; }
        public GetAikidoEventByIdQuery(int id) => Id = id;
    }
}