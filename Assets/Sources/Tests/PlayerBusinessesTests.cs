using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Server.PlayerLogic;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerBusinessesTests
{
    private Player _player;

    private PlayerBusinessesGate _gate;

    [SetUp]
    public void SetUp()
    {
        _player = new();
        _gate = new(_player);
    }

    [Test]
    public void BusinessAddTest()
    {
        Assert.AreEqual(0, _player.BusinessesList.Businesses.Count);

        _gate.AddBusiness(new("Test"));

        Assert.AreEqual(1, _player.BusinessesList.Businesses.Count);
        Assert.AreEqual("Test", _player.BusinessesList.Businesses[0].Name);
    }
}
