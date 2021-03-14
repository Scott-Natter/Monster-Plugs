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
    private Vector3 InitialPosition;
    private Vector3 ConnectedPosition;
    private Port ConnectedPort;

    public bool isDragging;
    public bool isConnected;

    // Start is called before the first frame update
    void Start()
    {
        CordLine = new GameObject("Line" + this.gameObject);
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
        InitialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Cord.SetPosition(1, this.transform.position);

        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        isConnected = false;
        if(ConnectedPort != null)
        {
            ConnectedPort.isConnectedtoPlug = false;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (!isConnected)
        {
            this.transform.position = InitialPosition;
        }
        if (isConnected)
        {
            this.transform.position = ConnectedPosition;
            ConnectedPort.isConnectedtoPlug = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Port" && col.gameObject.GetComponent<Port>().isConnectedtoPlug is false)
        {
            isConnected = true;
            ConnectedPosition = col.transform.position;
            ConnectedPort = col.gameObject.GetComponent<Port>();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        isConnected = false;
        ConnectedPort = null;
    }
}
