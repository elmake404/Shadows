﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            CanvasManager.Instance.BallCounter();
            enabled = false;
        }
    }
}