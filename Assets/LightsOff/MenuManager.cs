using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public AudioSource clickSound;
    public List<TextMeshProUGUI> texts;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Camera.main.backgroundColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIElement())
            {
                //play click sound
                clickSound.Play();
                CanvasChange();
            }
        }
    }

    private void CanvasChange()
    {
        
        if (cam.backgroundColor == Color.black)
        {
            cam.backgroundColor = Color.white;
            foreach (TextMeshProUGUI text in texts)
            {
                text.color = Color.black;
            }
        }
        else
        {
            cam.backgroundColor = Color.black;
            foreach (TextMeshProUGUI text in texts)
            {
                text.color = Color.white;
            }
        }
        

        
    }

    private bool IsPointerOverUIElement()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
