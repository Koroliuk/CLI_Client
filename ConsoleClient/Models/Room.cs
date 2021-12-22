namespace ConsoleClient.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public RoomCategory RoomCategory { get; set; }

        public override string ToString()
        {
            return $"Room number: {RoomNumber},\nRoom category number: {RoomCategory.CategoryNumber}\n" +
                    $"(Category details:\nname: {RoomCategory.Name},\nprice per day: {RoomCategory.PricePerDay} ,\n" +
                    $"capacity: {RoomCategory.Capacity},\ndescription: {RoomCategory.Description})";
        }
    }
}
