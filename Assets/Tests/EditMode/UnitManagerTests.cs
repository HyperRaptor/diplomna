using NUnit.Framework;
using UnityEngine;

public class UnitManagerTests
{
    private class TestSpiralMovement : SpiralMovement
    {
        public void SetSpeed(int value) => speed = value;
        public int GetSpeed() => speed;
    }

    [Test]
    public void ChangeState_TogglesSatelliteSpeeds()
    {
        var managerObj = new GameObject("UnitManager");
        var manager = managerObj.AddComponent<UnitManager>();
        manager.normalSpeed = 1;
        manager.fastSpeed = 3;

        UnitManager.Instance = manager;

        var sat = new GameObject("Satellite");
        var movement = sat.AddComponent<TestSpiralMovement>();
        movement.SetSpeed(manager.normalSpeed);
        manager.Sattelites.Add(sat);

        // First state: not pressed -> normalSpeed
        typeof(UnitManager)
            .GetMethod("Update", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.Invoke(manager, null);
        Assert.AreEqual(manager.normalSpeed, movement.GetSpeed());

        // Toggle state
        manager.ChangeState();
        typeof(UnitManager)
            .GetMethod("Update", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.Invoke(manager, null);
        Assert.AreEqual(manager.fastSpeed, movement.GetSpeed());
    }
}

