public class Elevator
{
    public int Number { get; set; }
    public int Capacity { get; set; }
    public int CurrentFloor { get; set; }
    public bool IsMoving { get; set; }
    public int Occupancy { get; set; }
    public string Direction { get; set; }

    public Elevator(int number, int currentFloor)
    {
        Number = number;
        Capacity = 21;
        CurrentFloor = currentFloor;
        IsMoving = false;
        Direction = "None";
    }

    public void MoveToFloor(int floorNumber)
    {
        Direction = floorNumber > CurrentFloor ? "Up" : floorNumber < CurrentFloor ? "Down" : "None";
        IsMoving = Direction != "None";
        CurrentFloor = floorNumber;
    }
    public void OffloadPassenger(int floorNumber, int numberOfPeople)
    {
        IsMoving = false;
        Occupancy -= numberOfPeople;
        Capacity += numberOfPeople;
        Console.WriteLine($"Elevator {Number} offloaded {numberOfPeople} passenger on floor {floorNumber}");
        Console.WriteLine("--------------------------------------------------------------------");
    }

}
