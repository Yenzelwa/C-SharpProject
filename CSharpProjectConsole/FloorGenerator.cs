public class FloorGenerator
{
    public List<Floor> GenerateFloors()
    {
        List<Floor> floors = new List<Floor>();
        Random random = new Random();

        while (true)
        {
            int floorNumber = random.Next(1, 6);
            Console.WriteLine($"Generated Floor Number: {floorNumber}");

            Floor floor = new Floor { FloorNumber = floorNumber };

            Console.WriteLine($"Enter the requested floor and number of people (separated by commas):");
            string input = Console.ReadLine();
            string[] inputs = input.Split(',');

            if (inputs.Length != 2)
            {
                Console.WriteLine("Invalid input. Please enter the requested floor and the number of people separated by a comma.");
                continue;
            }

            if (!int.TryParse(inputs[0], out int requestedFloor))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the requested floor.");
                continue;
            }
              if (requestedFloor == floorNumber)
            {
                Console.WriteLine("Invalid input. The requested floor cannot be the same as the current floor number.");
                continue;
            }

            if (!int.TryParse(inputs[1], out int numberOfPeople))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the number of people.");
                continue;
            }

            RequestedFloorData requestedFloorData = new RequestedFloorData
            {
                FloorNumber = requestedFloor,
                NumberOfPeople = numberOfPeople
            };

            floor.RequestedFloor.Add(requestedFloorData);

            floors.Add(floor);

            Console.WriteLine("Do you want to add another floor? (Y/N)");
            input = Console.ReadLine().ToUpper();
            if (input != "Y")
                break;
        }

        return floors;
    }
}