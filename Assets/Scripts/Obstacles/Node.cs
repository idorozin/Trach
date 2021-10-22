
using UnityEngine;


public class Node
{
    public Vector3 position;
    public bool used = false;

    public Node(Vector3 position, bool used = false)
    {
        this.position = position;
        this.used = used;
    }

    public void Used()
    {
        used = true;
    }

}
