using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlugsPerLevel, PortsPerLevel;
    private int LevelNum = 0;
    public Vector3 InitialPlugSpawn;

    public GameObject PlugHolder, Plug, PortHolder, Port, CordHolder, PortLocations;

    public float overallCharge;
    private float overallChargeMax = 100f;
    public ChargeBar overallChargeBar;

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
        if (Input.GetKeyDown("space"))
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
            NewLevel();  
        }
        if (overallCharge <= 0)
        {
            overallCharge = 0;
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
