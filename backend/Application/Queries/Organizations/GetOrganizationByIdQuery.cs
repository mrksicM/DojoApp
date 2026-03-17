namespace Application.Queries.Organizations
{
    public class GetOrganizationByIdQuery
    {
        public int Id { get; }
        public GetOrganizationByIdQuery(int id) => Id = id;
    }
}