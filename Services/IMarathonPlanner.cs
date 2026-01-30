using CinemaApp.Models;

namespace CinemaApp.Services;

public interface IMarathonPlanner
{
    IEnumerable<Show> PlanMarathon(IEnumerable<Show> shows);
}
