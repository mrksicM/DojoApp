namespace Application.Queries.Members
{
    public class GetMemberByIdQuery
    {
        public int Id { get; }
        public GetMemberByIdQuery(int id) => Id = id;
    }
}