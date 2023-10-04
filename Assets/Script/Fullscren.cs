using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscren : MonoBehaviour
{
    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("changed screen mode");
    }
}
