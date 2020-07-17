
using UnityEngine;


public class Node
{
    public Vector3 position;
    public bool used = false;

    public Node(Vector3 position)
    {
        this.position = position;
    }

    public void Used()
    {
        used = true;
    }

}
