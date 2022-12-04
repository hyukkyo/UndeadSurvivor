using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    public static WorldScrolling instance;
    public PlayerMove player;

    private void Awake()
    {
        instance = this;
    }
}
