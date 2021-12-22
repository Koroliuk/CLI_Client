using System;

namespace ConsoleClient.Models
{
    class Order
    {
        public int OrderNumber { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public OrderType Type { get; set; }
        public int RoomNumber { get; set; }

        public override string ToString()
        {
            return $"OrderNumber: {OrderNumber},\nStart date: {Start.Date},\nEnd date: {End.Date},\n" +
                $"OrderType: {Type},\nRoomNumber: {RoomNumber}";
        }
    }

    public enum OrderType
    {
        Booked,
        Paid
    }
}
