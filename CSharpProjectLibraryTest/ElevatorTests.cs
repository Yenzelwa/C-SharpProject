using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CSharpProjectLibraryTest;

[TestClass]
public class ElevatorTests
{
    [TestMethod]
    public void MoveToFloor_MoveUp_DirectionIsUp()
    {
        // Arrange
        var elevator = new Elevator(1, 0);

        // Act
        elevator.MoveToFloor(5);

        // Assert
        Assert.AreEqual("Up", elevator.Direction);
    }

    [TestMethod]
    public void MoveToFloor_MoveDown_DirectionIsDown()
    {
        // Arrange
        var elevator = new Elevator(1, 5);
        // Act
        elevator.MoveToFloor(2);
        // Assert
        Assert.AreEqual("Down", elevator.Direction);
    }

    [TestMethod]
    public void MoveToFloor_StayOnSameFloor_DirectionIsNone()
    {
        // Arrange
        var elevator = new Elevator(1, 3);
        // Act
        elevator.MoveToFloor(3);
        // Assert
        Assert.AreEqual("None", elevator.Direction);
    }

    [TestMethod]
    public void MoveToFloor_UpdateCurrentFloor()
    {
        // Arrange
        var elevator = new Elevator(1, 0);
        // Act
        elevator.MoveToFloor(8);
        // Assert
        Assert.AreEqual(8, elevator.CurrentFloor);
    }

    [TestMethod]
    public void MoveToFloor_SetIsMovingToTrue()
    {
        // Arrange
        var elevator = new Elevator(1, 0);
        // Act
        elevator.MoveToFloor(5);
        // Assert
        Assert.IsTrue(elevator.IsMoving);
    }

    [TestMethod]
    public void OffloadPassenger_DecreaseOccupancy()
    {
        // Arrange
        var elevator = new Elevator(1, 0)
        {
            Occupancy = 10
        };
        // Act
        elevator.OffloadPassenger(5, 3);
        // Assert
        Assert.AreEqual(7, elevator.Occupancy);
    }

    [TestMethod]
    public void OffloadPassenger_IncreaseCapacity()
    {
        // Arrange
        var elevator = new Elevator(1, 0)
        {
            Capacity = 18
        };
        // Act
        elevator.OffloadPassenger(5, 3);
        // Assert
        Assert.AreEqual(21, elevator.Capacity);
    }
    [TestMethod]
    public void OffloadPassenger_IsMovingSetToFalse()
    {
        // Arrange
        var elevator = new Elevator(1, 0)
        {
            IsMoving = true
        };
        // Act
        elevator.OffloadPassenger(5, 3);
        // Assert
        Assert.IsFalse(elevator.IsMoving);
    }
}
