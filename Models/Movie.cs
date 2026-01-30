namespace CinemaApp.Models;

public class Movie
{
    public string Title { get; }
    public TimeSpan Duration { get; }

    public Movie(string title, TimeSpan duration)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Movie title cannot be empty.", nameof(title));
        if (duration <= TimeSpan.Zero)
            throw new ArgumentException("Duration must be greater than zero.", nameof(duration));

        Title = title;
        Duration = duration;
    }

    public override string ToString() => $"{Title} (Duration: {Duration:hh\\:mm})";
}
