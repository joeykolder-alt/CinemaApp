# Cinema Application Demo Examples

## Example 1: Basic Setup and Booking

### Setup Rooms
```
add-room "IMAX" 150
add-room "Standard" 80
add-room "VIP" 30
```

### Add Movies
```
add-movie "Dune: Part Two" 02:46
add-movie "Godzilla x Kong" 01:55
add-movie "Kung Fu Panda 4" 01:34
```

### Schedule Shows
```
add-show "Dune: Part Two" "IMAX" 2025-11-01T10:00 18.99
add-show "Godzilla x Kong" "Standard" 2025-11-01T13:00 12.99
add-show "Kung Fu Panda 4" "VIP" 2025-11-01T15:00 22.50
```

### Book Tickets
```
book 1 75 76 77 78
book 2 20 21
book 3 5
```

---

## Example 2: Marathon Planning Scenario

### Setup
```
add-room "Screen 1" 100
add-room "Screen 2" 120

add-movie "Movie A" 01:30
add-movie "Movie B" 02:00
add-movie "Movie C" 01:45
add-movie "Movie D" 02:15
add-movie "Movie E" 01:20
```

### Create Overlapping Shows
```
add-show "Movie A" "Screen 1" 2025-12-01T09:00 10.00
add-show "Movie B" "Screen 1" 2025-12-01T11:00 12.00
add-show "Movie C" "Screen 2" 2025-12-01T10:00 11.00
add-show "Movie D" "Screen 1" 2025-12-01T14:00 13.00
add-show "Movie E" "Screen 2" 2025-12-01T17:00 9.00
```

### View Schedule
```
list-shows 2025-12-01
```

### Calculate Best Marathon
```
marathon 2025-12-01
```

**Expected Marathon Output:**
- Movie A (09:00-10:30)
- Movie C (10:00-11:45) - Different room, so can overlap with Movie B
- Movie D (14:00-16:15)
- Movie E (17:00-18:20)

---

## Example 3: Error Handling

### Invalid Seat Bookings
```
# Try to book invalid seat number (too high)
book 1 999
# Output: Error: Seat 999 is invalid. Valid range: 1-100

# Try to book seat 0 (too low)
book 1 0
# Output: Error: Seat 0 is invalid. Valid range: 1-100

# Book valid seats
book 1 50 51

# Try to double-book
book 1 51
# Output: Error: Seat 51 is already booked.
```

### Invalid Show ID
```
book 999 10
# Output: Error: Show with ID 999 not found.
```

### Missing Data
```
# Try to add show with non-existent movie
add-show "NonExistent Movie" "Screen 1" 2025-11-01T10:00 10.00
# Output: Error: Movie 'NonExistent Movie' not found.

# Try to add show with non-existent room
add-show "Movie A" "NonExistent Room" 2025-11-01T10:00 10.00
# Output: Error: Room 'NonExistent Room' not found.
```

---

## Example 4: Real Cinema Day Schedule

### Friday Premium Shows
```
add-room "Dolby Atmos 1" 200
add-room "Dolby Atmos 2" 180
add-room "Standard 1" 120
add-room "Standard 2" 100

add-movie "Avatar 3" 03:12
add-movie "Fast X" 02:21
add-movie "Mission Impossible 8" 02:43
add-movie "The Marvels" 01:45
add-movie "Wonka" 01:56

# Morning Shows
add-show "Wonka" "Standard 1" 2025-11-15T09:00 8.99
add-show "The Marvels" "Standard 2" 2025-11-15T10:00 9.99

# Afternoon Shows
add-show "Avatar 3" "Dolby Atmos 1" 2025-11-15T12:00 19.99
add-show "Fast X" "Dolby Atmos 2" 2025-11-15T13:00 16.99
add-show "Mission Impossible 8" "Standard 1" 2025-11-15T14:00 12.99

# Evening Shows
add-show "Avatar 3" "Dolby Atmos 1" 2025-11-15T16:00 22.99
add-show "Fast X" "Standard 2" 2025-11-15T17:00 14.99
add-show "Wonka" "Standard 1" 2025-11-15T18:00 11.99

# Late Shows
add-show "Mission Impossible 8" "Dolby Atmos 2" 2025-11-15T20:00 18.99
add-show "The Marvels" "Standard 1" 2025-11-15T21:00 10.99

list-shows 2025-11-15
```

### Group Booking
```
# Family booking (6 seats together)
book 1 45 46 47 48 49 50

# Couple booking
book 2 30 31

# Solo booking
book 3 75
```

---

## Example 5: Testing Marathon Algorithm

### Test Case: Greedy by End Time
```
add-room "Test Room" 50

add-movie "Short1" 01:00
add-movie "Short2" 01:00
add-movie "Long1" 02:30
add-movie "Short3" 01:00

# Setup shows to test greedy algorithm
add-show "Short1" "Test Room" 2025-11-20T10:00 10.00    # 10:00-11:00
add-show "Long1" "Test Room" 2025-11-20T10:30 15.00     # 10:30-13:00
add-show "Short2" "Test Room" 2025-11-20T11:30 10.00    # 11:30-12:30
add-show "Short3" "Test Room" 2025-11-20T13:00 10.00    # 13:00-14:00

marathon 2025-11-20
```

**Expected Output:**
1. Short1 (10:00-11:00) - Earliest end time
2. Short2 (11:30-12:30) - Next available after Short1
3. Short3 (13:00-14:00) - Next available after Short2

**Not selected:** Long1 (overlaps with Short1 and ends later than Short2)

---

## Commands Quick Reference

| Command | Example | Description |
|---------|---------|-------------|
| `add-room` | `add-room "IMAX" 150` | Add a cinema room |
| `add-movie` | `add-movie "Inception" 02:28` | Add a movie |
| `add-show` | `add-show "Inception" "IMAX" 2025-11-01T10:00 15.99` | Schedule a show |
| `list-shows` | `list-shows 2025-11-01` | List shows for a date |
| `book` | `book 1 50 51 52` | Book seats for a show |
| `marathon` | `marathon 2025-11-01` | Plan optimal marathon |
| `help` | `help` | Show help |
| `exit` | `exit` | Exit application |

---

## Testing Checklist

- [ ] Can add rooms with different capacities
- [ ] Can add movies with different durations
- [ ] Can schedule shows at different times
- [ ] Shows are listed in chronological order
- [ ] Can book multiple seats at once
- [ ] Cannot book the same seat twice
- [ ] Cannot book invalid seat numbers (< 1 or > capacity)
- [ ] Marathon correctly identifies non-overlapping shows
- [ ] Marathon works across multiple rooms
- [ ] Marathon uses greedy algorithm (earliest end time first)
- [ ] Error messages are clear and helpful
- [ ] All commands work with quoted strings

---

## Advanced Scenarios

### Scenario: Cross-Room Marathon Maximization
```
# Create two rooms with simultaneous shows
add-room "Room A" 100
add-room "Room B" 100

add-movie "Film 1" 02:00
add-movie "Film 2" 01:30
add-movie "Film 3" 02:30
add-movie "Film 4" 01:00

# Room A timeline
add-show "Film 1" "Room A" 2025-11-01T10:00 10.00  # 10:00-12:00
add-show "Film 3" "Room A" 2025-11-01T13:00 12.00  # 13:00-15:30

# Room B timeline (overlaps with Room A)
add-show "Film 2" "Room B" 2025-11-01T11:00 10.00  # 11:00-12:30
add-show "Film 4" "Room B" 2025-11-01T16:00 8.00   # 16:00-17:00

marathon 2025-11-01
```

**Best Marathon:**
- Film 1 (Room A: 10:00-12:00)
- Film 2 (Room B: 11:00-12:30) - Can watch because different room!
- Film 3 (Room A: 13:00-15:30)
- Film 4 (Room B: 16:00-17:00)

This demonstrates the power of having multiple rooms for marathon planning!

---

## Tips

1. **Use quotes** for room and movie names with spaces
2. **Date format** must be ISO 8601: `yyyy-MM-ddTHH:mm`
3. **Duration format** must be `HH:mm` (e.g., `02:28` for 2 hours 28 minutes)
4. **Seat numbers** start at 1 and go up to room capacity
5. **Marathon** considers time only - different rooms can overlap
6. **Show IDs** are auto-generated starting from 1
