using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] PlugsPerLevel, PortsPerLevel;
    private int LevelNum = 0;
    public Vector3 InitialPortSpawn;

    public GameObject PlugHolder, Plug, PortHolder, Port, CordHolder;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlugsPerLevel[LevelNum]; i++)
        {
            var NewPlug = Instantiate(Plug, new Vector3(InitialPortSpawn.x + i, InitialPortSpawn.y, 0), Quaternion.identity);
            NewPlug.transform.parent = PlugHolder.transform;
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
            
            LevelNum += 1;
            for (int i = 0; i < PlugsPerLevel[LevelNum]; i++)
            {
                var NewPlug = Instantiate(Plug, new Vector3(InitialPortSpawn.x + (2 * i), InitialPortSpawn.y, 0), Quaternion.identity);
                NewPlug.transform.parent = PlugHolder.transform;
            }
        }
    }
}
