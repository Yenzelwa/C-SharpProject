using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CSharpProjectLibraryTest;

[TestClass]
public class ElevatorControlTests
{
    [TestMethod]
    public void AddElevator_AddsElevatorToList()
    {
        // Arrange
        var elevators = new List<Elevator>();
        var floors = new List<Floor>();
        var elevatorControl = new ElevatorControl(floors, elevators);
        var elevator = new Elevator(3, 4);
        // Act
        elevatorControl.AddElevator(elevator);
        // Assert
        CollectionAssert.Contains(elevators, elevator);
    }

    [TestMethod]
    public void GetNearestElevator_InvalidNumberOfPeople_ReturnsNull()
    {
        // Arrange
        var elevators = new List<Elevator>
        {
             new Elevator(3, 4) {Capacity = 10}
        };
        var floors = new List<Floor>();
        var elevatorControl = new ElevatorControl(floors, elevators);
        // Act
        var result = elevatorControl.GetNearestElevator(1, 2, 15);
        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void GetNearestElevator_ValidParameters_ReturnsNearestElevator()
    {
        // Arrange
      var elevators = new List<Elevator>
            {
                new Elevator(1, 1) { Direction = "MovingUp" },
                new Elevator(2, 2) { Direction = "MovingDown" }
            };
        var floors = new List<Floor>();
        var elevatorControl = new ElevatorControl(floors, elevators);
        // Act
        var result = elevatorControl.GetNearestElevator(1, 5, 5);
        // Assert
        Assert.AreEqual(1, result.CurrentFloor);
    }
    [TestMethod]
    public void AssignElevatorToFloor_CallsExpectedMethods()
    {
        // Arrange
        var elevators = new List<Elevator>
        {
            new Elevator(1, 10),
             new Elevator(2, 5)
        };
        var floors = new List<Floor>
        {
            new Floor(),
            new Floor()
        };
        var elevatorControl = new ElevatorControl(floors, elevators);
        // Act
        elevatorControl.AssignElevatorToFloor();

       
    }

}
