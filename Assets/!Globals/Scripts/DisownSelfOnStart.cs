﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisownSelfOnStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.SetParent(null);
    }
}
