using CinemaApp.Models;

namespace CinemaApp.Repositories;

public class InMemoryShowStore : IShowStore
{
    private readonly List<Show> _shows = new();

    public void AddShow(Show show)
    {
        if (show == null)
            throw new ArgumentNullException(nameof(show));
        
        _shows.Add(show);
    }

    public IEnumerable<Show> GetAllShows() => _shows;

    public IEnumerable<Show> GetShowsByDate(DateTime date)
    {
        return _shows
            .Where(s => s.Start.Date == date.Date)
            .OrderBy(s => s.Start)
            .ToList();
    }

    public Show? GetShowById(int id) => _shows.FirstOrDefault(s => s.Id == id);
}
