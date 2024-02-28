using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int worldIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.NextScene();
        }
    }

    public void Interact()
    {
        if (worldIndex != 0)
        {
            GameManager.Instance.ChangeWorld(worldIndex);
        }
    }
}
