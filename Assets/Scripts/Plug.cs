using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour
{
    public GameObject CordParent;
    public Gradient CordMat;
    private GameObject CordLine;
    private GameObject CordStart;
    private LineRenderer Cord;

    // Start is called before the first frame update
    void Start()
    {
        CordLine = new GameObject("Line"+ this.gameObject);
        CordLine.transform.parent = CordParent.transform;
        CordLine.AddComponent<LineRenderer>();
        Cord = CordLine.GetComponent<LineRenderer>();
        Cord.widthMultiplier = 0.3f;
        Cord.material = new Material(Shader.Find("Sprites/Default"));
        Cord.colorGradient = CordMat;
        CordStart = new GameObject("CordStart");
        CordStart.transform.parent = CordParent.transform;
        CordStart.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 3, 0);
        Cord.SetPosition(0, CordStart.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Cord.SetPosition(1, this.transform.position);
    }
}
