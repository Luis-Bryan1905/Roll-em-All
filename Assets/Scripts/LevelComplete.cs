using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public GameObject LevelCompleteMenu; // Attach your GameObject you'd like to active/deactive in the inspector
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelCompleteMenu.SetActive(true);
            Player.GetComponent<Rigidbody>().isKinematic = true; // Disable player movement
        }


    }
}
