﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Delay);
    }
}
