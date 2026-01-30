# 🎬 Cinema Management System

A web-based cinema management application built with **ASP.NET Core 8 (C#)** for the backend and **HTML/CSS/JavaScript** for the frontend. This system allows you to manage rooms, movies, shows, and book seats seamlessly through a modern, responsive user interface.

## 📋 Features

- **Web Interface**: A clean, single-page application (SPA) style interface for easy navigation.
- **Room Management**: Add new cinema rooms with custom names and capacities.
- **Movie Catalog**: Register movies with titles and durations.
- **Show Scheduling**: Create shows by linking a movie to a room at a specific time and price.
- **Seat Booking**: Interactive visual seat map for booking tickets. 
  - **Green**: Available
  - **Red**: Booked
- **Validation**: Prevents double-booking and validates input data.
- **Localization**: Supports English numbering and currency formats (Dinar).

## 🏗️ Architecture

### Backend (C# / .NET 8)
- **ASP.NET Core Web API**: Hosts the application and serves static files.
- **Models**: Defines the data structures (`Room`, `Movie`, `Show`).
- **Services**: Manages business logic (like `CinemaManager`).

### Frontend (HTML / JS)
- **Vanilla JavaScript**: Handles UI logic, data storage (currently local), and interactions.
- **CSS**: Provides a modern, responsive design with a red/white/gray color scheme.
- **HTML5**: Semantically structured layout.

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A modern web browser (Chrome, Edge, Firefox, Safari)

### Installation & Running

1. **Clone the repository:**
   ```bash
   git clone https://github.com/joeykolder-alt/CinemaApp.git
   cd CinemaApp
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

3. **Open in Browser:**
   - The application will start a local web server (usually at `http://localhost:5000` or `http://localhost:5001`).
   - Open your browser and navigate to the displayed URL.

## 💻 Usage

### 1. Add Resources
- Use the **"Add Room"** section to create auditoriums.
- Use the **"Add Movie"** section to register new films.

### 2. Schedule Shows
- Go to **"Add Show"**.
- Select a movie and a room from the dropdowns.
- Set the date, time, and price.
- Click **"Add Show"**.

### 3. Book Tickets
- Scroll down to **"Book Seats"**.
- Select a show to see its seating plan.
- Click on any **Green** (available) seat to book it.
- The seat will turn **Red** (booked), and a confirmation alert with the price will appear.

## 🔧 Design Notes

- The project has evolved from a Console Application to a Web Application to provide a better user experience.
- The frontend currently prototypes the interaction logic using JavaScript and local storage, while the backend is set up to be extended for full API integration.
- Codebase is clean, modular, and follows separation of concerns.

## 📝 License

This project is for educational purposes.

## 👨‍💻 Author

Developed as a comprehensive learning project demonstrating full-stack capabilities with .NET and standard web technologies.
