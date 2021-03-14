using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    private bool isConnected;
    void Update()
    {
        if (isConnected)
        {
            print("works");
        }
    }
}
