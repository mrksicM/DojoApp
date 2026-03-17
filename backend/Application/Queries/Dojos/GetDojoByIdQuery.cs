namespace Application.Queries.Dojos
{
    public class GetDojoByIdQuery
    {        
        public int Id { get; }
        public GetDojoByIdQuery(int id) => Id = id;
    }
}