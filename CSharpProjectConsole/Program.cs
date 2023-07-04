public class Program
{
    static void Main(string[] args)
    {
        List<Elevator> elevators = new List<Elevator>();
        FloorGenerator floorGenerator = new FloorGenerator();
        List<Floor> floors = floorGenerator.GenerateFloors();

        DisplayFloors displayFloors = new DisplayFloors();
        displayFloors.ShowFloors(floors);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        elevators.Add(new Elevator(1, 1));
        elevators.Add(new Elevator(2, 2));

        ElevatorControl elevatorControl = new ElevatorControl(floors, elevators);

        elevatorControl.AssignElevatorToFloor();
    }
}


