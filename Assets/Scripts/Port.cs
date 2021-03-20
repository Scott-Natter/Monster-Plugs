using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    public float currentCharge;
    public float maximumCharge = 100.0f;
    public float depletionRate = 0.025f;
    public float chargeRate = 0.1f;

    AudioSource audioSource;
    public ChargeBar chargeBar;
    public ChargeBar overallChargeBar;
    public bool isConnectedtoPlug;
    private GameObject EnergyBar;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        overallChargeBar = GameObject.Find("/Canvas/ChargeBar").GetComponent<ChargeBar>();
        currentCharge = maximumCharge;
        chargeBar.SetMaxCharge(maximumCharge);
        //EnergyBar = this.transform.GetChild(0).gameObject;
    }
    void FixedUpdate()
    {
        if (isConnectedtoPlug && currentCharge <= 100f)
        {
            //Will get replaced by a charging rate specific to
            //the plug that is in the port
            currentCharge = currentCharge + chargeRate;
        }
        else if (!isConnectedtoPlug && currentCharge >= 0)
        {
            currentCharge = currentCharge - depletionRate;
        }
        else if (currentCharge <= 0)
        {
            overallChargeBar.DepleteCharge(depletionRate);
            //subtract from overall health
            currentCharge = 0;
        }

        // Set the UI ChargeBar's "health"
        chargeBar.SetCharge(currentCharge);
    }
    public void PlayDisconnectSound()
    {
        audioSource.Play();
    }
}
