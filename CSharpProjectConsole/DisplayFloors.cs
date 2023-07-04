public class DisplayFloors
{
    public void ShowFloors(List<Floor> floors)
    {
        Console.WriteLine("\nFloors:");
        foreach (var floor in floors)
        {
            Console.WriteLine($"Floor Number: {floor.FloorNumber}");
            Console.WriteLine("Requested Floors:");
            foreach (var requestedFloor in floor.RequestedFloor)
            {
                Console.WriteLine($"  - Floor Number: {requestedFloor.FloorNumber}, Number of People: {requestedFloor.NumberOfPeople}");
            }
            Console.WriteLine();
        }
    }
}
