# 🎬 Cinema Application - Quick Start Guide

## ⚡ Installation (30 seconds)

```bash
cd /Users/mohammedahmedabdallah/Desktop/cinema/CinemaApp
dotnet run
```

## 📋 Essential Commands

| Command | Format | Example |
|---------|--------|---------|
| Add Room | `add-room "Name" capacity` | `add-room "IMAX" 150` |
| Add Movie | `add-movie "Title" HH:mm` | `add-movie "Inception" 02:28` |
| Add Show | `add-show "Movie" "Room" DateTime price` | `add-show "Inception" "IMAX" 2026-02-01T10:00 15.99` |
| List Shows | `list-shows YYYY-MM-DD` | `list-shows 2026-02-01` |
| Book Seats | `book showId seat1 seat2 ...` | `book 1 50 51 52` |
| Marathon | `marathon YYYY-MM-DD` | `marathon 2026-02-01` |
| Help | `help` | `help` |
| Exit | `exit` | `exit` |

## 🚀 5-Minute Complete Demo

```bash
# 1. Setup (copy all lines and paste into the running app)
add-room "IMAX" 150
add-room "Standard" 80

add-movie "Dune" 02:35
add-movie "Oppenheimer" 03:00
add-movie "Barbie" 01:54

add-show "Dune" "IMAX" 2026-02-01T10:00 15.99
add-show "Oppenheimer" "IMAX" 2026-02-01T13:00 16.99
add-show "Barbie" "Standard" 2026-02-01T14:00 9.99

# 2. View schedule
list-shows 2026-02-01

# 3. Book tickets
book 1 50 51 52 53
book 2 75 76

# 4. Try error cases
book 1 51
book 1 999

# 5. Plan marathon
marathon 2026-02-01

# 6. Exit
exit
```

## 📊 What the Marathon Shows

The marathon planner uses a **greedy algorithm** that:
1. Sorts all shows by **end time**
2. Picks the show that finishes earliest
3. Picks the next show that starts after the previous one ends
4. Repeats until no more shows can be added

**Example:**
```
Shows available:
- Dune: 10:00-12:35 (ends first ✓)
- Oppenheimer: 13:00-16:00 (starts after Dune ✓)
- Barbie: 14:00-15:54 (overlaps with Oppenheimer ✗)

Marathon selected: Dune → Oppenheimer
Total: 2 movies, 5 hours 35 minutes, $32.98
```

## 🎯 Common Use Cases

### Case 1: Family Booking
```bash
add-room "Family Room" 50
add-movie "Toy Story 5" 01:40
add-show "Toy Story 5" "Family Room" 2026-02-01T14:00 8.99
book 1 10 11 12 13 14 15  # Book 6 seats together
```

### Case 2: Date Night
```bash
add-room "Premium" 30
add-movie "Romantic Movie" 02:00
add-show "Romantic Movie" "Premium" 2026-02-14T19:00 25.00
book 1 15 16  # Best seats in the middle
```

### Case 3: Movie Marathon Day
```bash
# Add 5+ shows throughout the day
marathon 2026-02-01  # Get optimal non-overlapping schedule
```

## ❗ Important Notes

1. **Quotes are required** for names with spaces
2. **Date format**: Must be `YYYY-MM-DDTHH:mm` (ISO 8601)
3. **Duration format**: Must be `HH:mm` (e.g., `02:30` for 2.5 hours)
4. **Seats**: Valid range is 1 to room capacity
5. **Show IDs**: Auto-generated starting from 1

## 🐛 Troubleshooting

### Problem: "Movie not found"
**Solution**: Make sure you added the movie first with `add-movie`

### Problem: "Room not found"
**Solution**: Make sure you added the room first with `add-room`

### Problem: "Seat X is invalid"
**Solution**: Check room capacity, seats must be 1 to capacity

### Problem: "Seat X is already booked"
**Solution**: That seat is taken, choose a different seat number

### Problem: Format errors
**Solution**: Check date format (`2026-02-01T10:00`) and duration format (`02:28`)

## 📁 File Structure

```
CinemaApp/
├── Models/           # Domain entities (Room, Movie, Show)
├── Repositories/     # Data storage (IShowStore, InMemoryShowStore)
├── Services/         # Business logic (CinemaManager, IMarathonPlanner)
├── Program.cs        # CLI entry point
├── README.md         # Full documentation
├── EXAMPLES.md       # Detailed examples
└── PROJECT_SUMMARY.md # Implementation details
```

## 🎓 Learning Resources

- Full documentation: `README.md`
- Detailed examples: `EXAMPLES.md`
- Implementation summary: `PROJECT_SUMMARY.md`
- Test script: `test-commands.txt`

## 🏆 Key Features

✅ Room management with capacity control
✅ Movie catalog with duration tracking
✅ Show scheduling with pricing
✅ Seat booking with validation
✅ Marathon planning with greedy algorithm
✅ Cross-room support for marathons
✅ User-friendly CLI with color symbols
✅ Comprehensive error handling
✅ Clean architecture (SOLID principles)
✅ Extensible design (Strategy + Repository patterns)

## 💡 Next Steps

1. **Run the demo**: `dotnet run < demo-session.txt`
2. **Read examples**: Open `EXAMPLES.md`
3. **Understand architecture**: Read `PROJECT_SUMMARY.md`
4. **Customize**: Modify code in `Models/`, `Services/`, etc.
5. **Extend**: Add JSON persistence, web API, etc.

## 📞 Need Help?

- Type `help` in the application
- Read `EXAMPLES.md` for detailed scenarios
- Check `PROJECT_SUMMARY.md` for architecture details
- Review the code comments for implementation details

---

**Ready to manage your cinema! 🎬**
