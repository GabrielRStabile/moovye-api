using Movye.Data.Context;
using Movye.Data.Repositories.Shared;
using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Repositories;

namespace Movye.Data.Repositories
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext dataContext)
            : base(dataContext) { }
    }
}
