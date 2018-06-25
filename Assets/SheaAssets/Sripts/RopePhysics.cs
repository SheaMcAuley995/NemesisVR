using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePhysics : MonoBehaviour
{

    public Vector3 destiny;
    public float speed = 1;
    public float distance = 2;



    public GameObject nodePrefab;

    public GameObject player;

    public GameObject lastNode;

    public LineRenderer lr;

    int vertexCount = 2;

    public List<GameObject> Nodes = new List<GameObject>();

    bool done = false;
    // Use this for initialization
    void Start()
    {

        lr = GetComponent<LineRenderer>();
        lastNode = transform.gameObject;
        Nodes.Add(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destiny, speed);


        if (transform.position != destiny)
        {
            if (Vector3.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }
        }
        else if (done == false)
        {
            done = true;

            while (Vector3.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }


            lastNode.GetComponent<HingeJoint>().connectedBody = player.GetComponent<Rigidbody>();
            lastNode.GetComponent<Rigidbody>().mass = 2.5f;
        }

        RenderLine();
    }

    void RenderLine()
    {
        lr.SetVertexCount(vertexCount);
        int i;
        for (i = 0; i < Nodes.Count; i++)
        {
            lr.SetPosition(i, Nodes[i].transform.position);
        }

        lr.SetPosition(i, player.transform.position);
    }

    void CreateNode()
    {
        Vector3 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += lastNode.transform.position;

        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity);

        go.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint>().connectedBody = go.GetComponent<Rigidbody>();

        lastNode = go;

        Nodes.Add(lastNode);
        vertexCount++;
    }
}