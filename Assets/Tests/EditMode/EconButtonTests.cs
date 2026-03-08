using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Reflection;

public class EconButtonTests
{
    private class TestEconButton : EconButton
    {
        public int ExecuteCount { get; private set; }

        protected override void Execute()
        {
            base.Execute();
            ExecuteCount++;
        }
    }

    [Test]
    public void ButtonClick_DoesNotExceedMax()
    {
        // Set up Global + Econ + Money UI so ShopButton has everything it needs
        var global = new GameObject("Global");
        var econ = global.AddComponent<Econ>();
        econ.money = 100;

        var moneyObj = new GameObject("Money");
        moneyObj.AddComponent<TextMeshProUGUI>();

        // Initialize Econ (sets its private display field)
        var econStart = typeof(Econ).GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
        econStart?.Invoke(econ, null);

        // Set up the button hierarchy and its Count text
        var parent = new GameObject("Parent");
        var countObj = new GameObject("Count");
        countObj.transform.SetParent(parent.transform);
        countObj.AddComponent<TextMeshProUGUI>();

        var buttonObj = new GameObject("EconButton");
        buttonObj.transform.SetParent(parent.transform);

        var econButton = buttonObj.AddComponent<TestEconButton>();
        econButton.max = 1;
        econButton.cost = 10;

        // Manually call EconButton.Start (which calls base.Start and wires up Count)
        var start = typeof(EconButton).GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
        start?.Invoke(econButton, null);

        econButton.ButtonClick();
        econButton.ButtonClick();

        Assert.AreEqual(1, econButton.ExecuteCount);
        //Assert.AreEqual(1, 2);
    }
}

