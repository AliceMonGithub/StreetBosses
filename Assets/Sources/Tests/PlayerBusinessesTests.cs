using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Server.PlayerLogic;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerBusinessesTests
{
    private Player _player;

    [SetUp]
    public void SetUp()
    {
        _player = new();
    }

    [Test]
    public void BusinessAddTest()
    {
        Assert.AreEqual(0, _player.BusinessesList.Businesses.Count);

        _player.BusinessesList.AddBusiness(new("Test"));

        Assert.AreEqual(1, _player.BusinessesList.Businesses.Count);
    }

    [Test]
    public void BlankToBusinessTest()
    {
        _player.BusinessesList.AddBusiness(new("Test"));

        Assert.IsTrue(_player.BusinessesList.ContainsBusiness("Test"));
        Assert.IsFalse(_player.BusinessesList.ContainsBusiness("False"));
    }
}
