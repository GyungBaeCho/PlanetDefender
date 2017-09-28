using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeTower : MonoBehaviour {
    public Planet   _planet;

    public void Change()
    {
        _planet.SwitchTower();
    }
}
