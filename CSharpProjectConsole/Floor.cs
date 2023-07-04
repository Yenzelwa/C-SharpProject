public class Floor
{
    public int FloorNumber { get; set; }
    public List<RequestedFloorData> RequestedFloor { get; set; } = new List<RequestedFloorData>();
}

public class RequestedFloorData
{
    public int FloorNumber { get; set; }
    public int NumberOfPeople { get; set; }
}
