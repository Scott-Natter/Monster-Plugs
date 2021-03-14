using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    public bool isConnectedtoPlug;
    void Update()
    {
        if (isConnectedtoPlug)
        {
            print("works");
        }
    }
}
