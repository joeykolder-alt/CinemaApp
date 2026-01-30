using CinemaApp.Models;
using CinemaApp.Repositories;

namespace CinemaApp.Services;

public class CinemaManager
{
    private readonly Dictionary<string, Room> _rooms = new();
    private readonly Dictionary<string, Movie> _movies = new();
    private readonly IShowStore _showStore;
    private readonly IMarathonPlanner _marathonPlanner;

    public CinemaManager(IShowStore showStore, IMarathonPlanner marathonPlanner)
    {
        _showStore = showStore ?? throw new ArgumentNullException(nameof(showStore));
        _marathonPlanner = marathonPlanner ?? throw new ArgumentNullException(nameof(marathonPlanner));
    }

    public void AddRoom(string name, int capacity)
    {
        try
        {
            var room = new Room(name, capacity);
            _rooms[name] = room;
            Console.WriteLine($"✓ Room added: {room}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void AddMovie(string title, TimeSpan duration)
    {
        try
        {
            var movie = new Movie(title, duration);
            _movies[title] = movie;
            Console.WriteLine($"✓ Movie added: {movie}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void AddShow(string movieTitle, string roomName, DateTime startTime, decimal price)
    {
        if (!_movies.TryGetValue(movieTitle, out var movie))
        {
            Console.WriteLine($"Error: Movie '{movieTitle}' not found.");
            return;
        }

        if (!_rooms.TryGetValue(roomName, out var room))
        {
            Console.WriteLine($"Error: Room '{roomName}' not found.");
            return;
        }

        try
        {
            var show = new Show(movie, room, startTime, price);
            _showStore.AddShow(show);
            Console.WriteLine($"✓ Show added: {show}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ListShows(DateTime date)
    {
        var shows = _showStore.GetShowsByDate(date);
        
        if (!shows.Any())
        {
            Console.WriteLine($"No shows scheduled for {date:yyyy-MM-dd}");
            return;
        }

        Console.WriteLine($"\n═══ Shows for {date:yyyy-MM-dd} ═══");
        foreach (var show in shows)
        {
            Console.WriteLine(show);
        }
        Console.WriteLine();
    }

    public void BookSeats(int showId, params int[] seats)
    {
        var show = _showStore.GetShowById(showId);
        
        if (show == null)
        {
            Console.WriteLine($"Error: Show with ID {showId} not found.");
            return;
        }

        if (show.TryBook(seats))
        {
            Console.WriteLine($"✓ Successfully booked seats {string.Join(", ", seats)} for show {showId}");
        }
        else
        {
            Console.WriteLine($"✗ Failed to book seats for show {showId}");
        }
    }

    public void PlanMarathon(DateTime date)
    {
        var shows = _showStore.GetShowsByDate(date);
        
        if (!shows.Any())
        {
            Console.WriteLine($"No shows available for {date:yyyy-MM-dd}");
            return;
        }

        var marathon = _marathonPlanner.PlanMarathon(shows);
        
        if (!marathon.Any())
        {
            Console.WriteLine($"No marathon possible for {date:yyyy-MM-dd}");
            return;
        }

        Console.WriteLine($"\n═══ Marathon Plan for {date:yyyy-MM-dd} ═══");
        var totalDuration = TimeSpan.Zero;
        var totalPrice = 0m;

        foreach (var show in marathon)
        {
            Console.WriteLine(show);
            totalDuration += show.Movie.Duration;
            totalPrice += show.Price;
        }

        Console.WriteLine($"\nTotal Movies: {marathon.Count()}");
        Console.WriteLine($"Total Duration: {totalDuration:hh\\:mm}");
        Console.WriteLine($"Total Price: ${totalPrice:F2}");
        Console.WriteLine();
    }
}
