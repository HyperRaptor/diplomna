using NUnit.Framework;
using UnityEngine;
using TMPro;
using System.Reflection;

public class EconTests
{
    private static void InitializeEcon(Econ econ, int initialMoney)
    {
        // Econ.Start expects a GameObject named "Money" with a TMP_Text component
        var moneyObj = new GameObject("Money");
        moneyObj.AddComponent<TextMeshProUGUI>();

        econ.money = initialMoney;

        var startMethod = typeof(Econ).GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
        startMethod?.Invoke(econ, null);
    }

    [Test]
    public void Deduct_ReturnsFalse_WhenNotEnoughMoney()
    {
        var go = new GameObject("Econ");
        var econ = go.AddComponent<Econ>();
        InitializeEcon(econ, 5);

        var result = econ.Deduct(10);

        Assert.IsFalse(result);
        Assert.AreEqual(5, econ.money);
    }

    [Test]
    public void Deduct_ReturnsTrue_AndReducesMoney_WhenEnoughMoney()
    {
        var go = new GameObject("Econ");
        var econ = go.AddComponent<Econ>();
        InitializeEcon(econ, 20);

        var result = econ.Deduct(10);

        Assert.IsTrue(result);
        Assert.AreEqual(10, econ.money);
    }
}

