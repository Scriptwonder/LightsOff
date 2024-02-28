using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float interactDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    bool ScreenTap()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }

    public void Interact()
    {
        RaycastHit hit;
        // Shoot a raycast from the center of the screen forward
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                if (hit.collider.GetComponent<DoorTrigger>() != null)
                {
                    hit.collider.GetComponent<DoorTrigger>().Interact();
                }
                GameManager.Instance.SwitchWorlds();
            }
        }
    }
}
