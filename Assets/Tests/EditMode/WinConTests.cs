using NUnit.Framework;
using UnityEngine;
using TMPro;
using System.Reflection;

public class WinConTests
{
    [Test]
    public void WinCon_ActivatesGameWin_WhenEndTimeReached()
    {
        // Setup GameEnd with its required TMP_Text reference
        var gameWin = new GameObject("GameWin");
        var textObj = new GameObject("GameEndText");
        var tmp = textObj.AddComponent<TextMeshProUGUI>();

        var gameEnd = gameWin.AddComponent<GameEnd>();
        gameEnd.textToChange = tmp;
        gameWin.SetActive(false);

        var winObj = new GameObject("WinCon");
        var winCon = winObj.AddComponent<WinCon>();
        winCon.gameWin = gameWin;
        winCon.endTime = 0f;

        // Directly invoke Update once; with endTime = 0, it should trigger immediately
        var update = typeof(WinCon).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
        update?.Invoke(winCon, null);

        Assert.IsTrue(gameWin.activeSelf);
        Assert.AreEqual("You have won!", tmp.text);
    }
}

