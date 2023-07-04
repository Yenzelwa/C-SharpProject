public class ElevatorControl
{
    private List<Elevator> elevators { get; set; }
    private List<Floor> floors { get; set; }

    public ElevatorControl(List<Floor> availableFloors, List<Elevator> availableElevators)
    {
        elevators = availableElevators;
        floors = availableFloors;
    }

    public void AddElevator(Elevator elevator)
    {
        elevators.Add(elevator);
    }

    public Elevator GetNearestElevator(int floorNumber, int requestedFloor, int numberOfPeople)
    {
        if (elevators.Any(elevator => numberOfPeople > elevator.Capacity))
        {
            Console.WriteLine("The number of people requested exceeds the capacity of all elevators. Please try again with a lower number of people.");
            Console.WriteLine("--------------------------------------------------------------------");
            return null;
        }

        Elevator nearestElevator = FindNearestElevator(floorNumber, requestedFloor, numberOfPeople);

        return nearestElevator;
    }

    private Elevator FindNearestElevator(int floorNumber, int requestedFloor, int numberOfPeople)
    {
        int minDistance = int.MaxValue;
        Elevator nearestElevator = null;

        foreach (var elevator in elevators)
        {
            int distance = Math.Abs(elevator.CurrentFloor - floorNumber);
            int direction = Math.Sign(requestedFloor - elevator.CurrentFloor);

            if (IsElevatorDirectionValid(elevator, direction) && CanAccommodatePassengers(elevator, numberOfPeople))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestElevator = elevator;
                }
            }
        }

        return nearestElevator;
    }

    private bool IsElevatorDirectionValid(Elevator elevator, int direction)
    {
        return (elevator.Direction == "MovingUp" || elevator.Direction == "None") && direction >= 0 ||
               (elevator.Direction == "MovingDown" || elevator.Direction == "None") && direction <= 0;
    }
    private bool CanAccommodatePassengers(Elevator elevator, int numberOfPeople)
    {
        return elevator.Occupancy + numberOfPeople < elevator.Capacity;
    }
    public void AssignElevatorToFloor()
    {
        foreach (var floor in floors)
        {
            ProcessRequestedFloors(floor);
        }
    }
    private void ProcessRequestedFloors(Floor floor)
    {
        var requestedFloors = floor.RequestedFloor.ToList();

        foreach (var requested in requestedFloors)
        {
            Elevator nearestElevator = GetNearestElevator(floor.FloorNumber, requested.FloorNumber, requested.NumberOfPeople);

            if (nearestElevator != null)
            {
                Console.WriteLine($"Elevator Information: Elevator number {nearestElevator.Number}");
                Console.WriteLine($"Fetching person from floor {floor.FloorNumber}");
                nearestElevator.MoveToFloor(floor.FloorNumber);
                Console.WriteLine($"Person onboard Elevator {nearestElevator.Number}");

                Console.WriteLine($"Delivering person to floor {requested.FloorNumber}");
                HandleElevatorAssignment(nearestElevator, requested);
                HandleElevatorInformation(nearestElevator);
                if (nearestElevator.IsMoving)
                {
                    HandlePassengerOffloading(nearestElevator, floor, requested);
                }
                else{
                     Console.WriteLine("--------------------------------------------------------------------");
                }

            }
            
        }
    }

    private void HandleElevatorAssignment(Elevator elevator, RequestedFloorData requested)
    {
        elevator.Occupancy += requested.NumberOfPeople;
        elevator.MoveToFloor(requested.FloorNumber);
    }

    private void HandleElevatorInformation(Elevator elevator)
    {
        Console.WriteLine($"Current Floor: {elevator.CurrentFloor}");
        Console.WriteLine($"Is Moving: {elevator.IsMoving}");
        Console.WriteLine($"Occupancy: {elevator.Occupancy}");
        Console.WriteLine($"Direction: {elevator.Direction}");
    }

    private void HandlePassengerOffloading(Elevator elevator, Floor floor, RequestedFloorData requested)
    {
        elevator.OffloadPassenger(requested.FloorNumber, requested.NumberOfPeople);
        floor.RequestedFloor.RemoveAll(r => r.FloorNumber == requested.FloorNumber);
    }

}

