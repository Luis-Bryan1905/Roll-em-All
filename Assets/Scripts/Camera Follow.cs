using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public GameObject player;
    public  Vector3 Offset;

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + Offset.x, transform.position.y + Offset.y, player.transform.position.z + Offset.z);
    }
}
