namespace CinemaApp.Models;

public class Room
{
    public string Name { get; }
    public int Capacity { get; }

    public Room(string name, int capacity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Room name cannot be empty.", nameof(name));
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.", nameof(capacity));

        Name = name;
        Capacity = capacity;
    }

    public override string ToString() => $"{Name} (Capacity: {Capacity})";
}
