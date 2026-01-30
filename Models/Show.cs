namespace CinemaApp.Models;

public class Show
{
    private static int _nextId = 1;
    private readonly HashSet<int> _bookedSeats = new();

    public int Id { get; }
    public Movie Movie { get; }
    public Room Room { get; }
    public DateTime Start { get; }
    public DateTime End { get; }
    public decimal Price { get; }
    public IReadOnlySet<int> BookedSeats => _bookedSeats;

    public Show(Movie movie, Room room, DateTime start, decimal price)
    {
        if (movie == null)
            throw new ArgumentNullException(nameof(movie));
        if (room == null)
            throw new ArgumentNullException(nameof(room));
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.", nameof(price));

        Id = _nextId++;
        Movie = movie;
        Room = room;
        Start = start;
        End = start.Add(movie.Duration);
        Price = price;
    }

    public bool TryBook(params int[] seats)
    {
        if (seats == null || seats.Length == 0)
            return false;

        foreach (var seat in seats)
        {
            if (seat < 1 || seat > Room.Capacity)
            {
                Console.WriteLine($"Error: Seat {seat} is invalid. Valid range: 1-{Room.Capacity}");
                return false;
            }

            if (_bookedSeats.Contains(seat))
            {
                Console.WriteLine($"Error: Seat {seat} is already booked.");
                return false;
            }
        }

        foreach (var seat in seats)
        {
            _bookedSeats.Add(seat);
        }

        return true;
    }

    public override string ToString()
    {
        return $"[{Id}] {Movie.Title} | {Room.Name} | {Start:yyyy-MM-dd HH:mm} | ${Price:F2} | Seats: {_bookedSeats.Count}/{Room.Capacity}";
    }
}
