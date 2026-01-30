using CinemaApp.Models;

namespace CinemaApp.Services;

public class GreedyMarathonPlanner : IMarathonPlanner
{
    public IEnumerable<Show> PlanMarathon(IEnumerable<Show> shows)
    {
        var sortedShows = shows.OrderBy(s => s.End).ToList();
        var marathon = new List<Show>();
        DateTime lastEnd = DateTime.MinValue;

        foreach (var show in sortedShows)
        {
            if (show.Start >= lastEnd)
            {
                marathon.Add(show);
                lastEnd = show.End;
            }
        }

        return marathon;
    }
}
