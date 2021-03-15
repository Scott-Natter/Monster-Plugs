using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int PlugsPerLevel, PortsPerLevel;
    private int LevelNum = 0;
    public Vector3 InitialPlugSpawn;
    public GameObject PlugHolder, Plug, PortHolder, Port, CordHolder, PortLocations;
    public TimerCountDown Timer;
    public float overallCharge;
    private float overallChargeMax = 100f;
    public ChargeBar overallChargeBar;

    public GameObject EndScreen;
    public Text SavedMonstersText;
    void Start()
    {
        overallCharge = overallChargeMax;
        overallChargeBar.SetCharge(overallCharge);
        PlugsPerLevel = 1;
        PortsPerLevel = 2;
        for (int i = 0; i < PlugsPerLevel; i++)
        {
            var NewPlug = Instantiate(Plug, new Vector3(InitialPlugSpawn.x + i, InitialPlugSpawn.y, 0), Quaternion.identity);
            NewPlug.transform.parent = PlugHolder.transform;
        }
        for (int j = 0; j < PortsPerLevel; j++)
        {
            var NewPort = Instantiate(Port, new Vector3(PortLocations.transform.GetChild(j).transform.position.x, PortLocations.transform.GetChild(j).transform.position.y, 0), Quaternion.identity);
            NewPort.transform.parent = PortHolder.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.TimerDone == true && overallCharge > 0)
        {
            foreach (Transform child in CordHolder.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in PlugHolder.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in PortHolder.transform)
            {
                Destroy(child.gameObject);
            }
            Timer.TimerDone = false;
            Timer.secondsLeft = 45;
            NewLevel();  
        }
        if (overallChargeBar.transform.GetComponent<Slider>().value <= 0)
        {
            EndScreen.SetActive(true);
            SavedMonstersText.text = "You saved " + LevelNum + " monsters!";
            //Trigger Lose State and display levelnum + 1
        }
    }

    void NewLevel()
    {
        LevelNum += 1;
        if (LevelNum < 3)
        {
            PlugsPerLevel = Random.Range(1,3);
            PortsPerLevel = Random.Range(3, 5);
        }
        else if (LevelNum < 6)
        {
            PlugsPerLevel = Random.Range(2, 4);
            PortsPerLevel = Random.Range(4, 6);
        }
        else if (LevelNum >= 6)
        {
            PlugsPerLevel = Random.Range(3, 5);
            PortsPerLevel = Random.Range(5, 8);
        }

        for (int i = 0; i < PlugsPerLevel; i++)
        {
            var NewPlug = Instantiate(Plug, new Vector3(InitialPlugSpawn.x + (2 * i), InitialPlugSpawn.y, 0), Quaternion.identity);
            NewPlug.transform.parent = PlugHolder.transform;
        }
        for (int j = 0; j < PortsPerLevel; j++)
        {
            var NewPort = Instantiate(Port, new Vector3(PortLocations.transform.GetChild(j).transform.position.x, PortLocations.transform.GetChild(j).transform.position.y, 0), Quaternion.identity);
            NewPort.transform.parent = PortHolder.transform;
        }
    }
}
