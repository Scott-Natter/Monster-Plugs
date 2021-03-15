using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    public bool isConnectedtoPlug;
    public int energynum = 100, energyLoss;
    private GameObject EnergyBar;

    private void Start()
    {
        //EnergyBar = this.transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (isConnectedtoPlug)
        {
            print("works");
        }
        if (!isConnectedtoPlug)
        {
            //subtract
        }
        if (energynum <= 0)
        {
            //subtract from overall health
            energynum = 0;
        }
    }
}
