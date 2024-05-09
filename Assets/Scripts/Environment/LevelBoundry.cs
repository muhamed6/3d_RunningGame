using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundry : MonoBehaviour
{

    // Update is called once per frame
    public static float leftSide=-3.5f;
    public static float rightSide= 3.5f;
    public float internalLeft;
    public float internalRight;
    void Update()
    {

        internalLeft=leftSide;
        internalRight=rightSide;
    }
}
