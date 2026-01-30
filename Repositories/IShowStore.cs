using CinemaApp.Models;

namespace CinemaApp.Repositories;

public interface IShowStore
{
    void AddShow(Show show);
    IEnumerable<Show> GetAllShows();
    IEnumerable<Show> GetShowsByDate(DateTime date);
    Show? GetShowById(int id);
}
