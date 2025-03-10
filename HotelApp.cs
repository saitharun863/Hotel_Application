using System;
using System.Data;
using HotelLibrary;

namespace HotelApp
{
    public class Hotel
    {
        private DatabaseHelper db = new DatabaseHelper();
        public void AddGuest(string name, string contact)
        {
            string query = $"INSERT INTO Guests(Name,Contact) VALUES ('{name}','{contact}')";
            db.ExecuteQuery(query);
        }
        public void BookRoom(int guestId, int roomId, string checkInDate, string checkOutDate)
        {
            string query = $"INSERT INTO Bookings(GuestId,RoomId,CheckInDate,CheckOutDate) VALUES ({guestId},{roomId},'{checkInDate}','{checkOutDate}')";
            db.ExecuteQuery(query);
        }

        public void ShowGuests()
        {
            DataTable dt = db.GetData("SELECT * FROM Guests");
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"Guest ID: {dr["GuestId"]} , Name : {dr["Name"]} , Contact : {dr["Contact"]}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            hotel.AddGuest("John Doe", "1234567890");
            hotel.BookRoom(1, 101, "2025-03-10", "2025-03-15");
            hotel.ShowGuests();
        }
    }
}

