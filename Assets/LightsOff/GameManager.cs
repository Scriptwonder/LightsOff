using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private bool InnerWorldOn = false;
    [SerializeField] private bool ExitThroughOuter = false;
    public bool PuzzleSolved = true;
    public GameObject triggerObject;
    public GameObject exitObject;
    public GameObject exitObjectHandle;
    public GameObject puzzleObject;
    public GameObject player;
    public GameObject outerWorld;
    public GameObject innerWorld;
    public AudioSource outerSource;
    public AudioSource innerSource;

    [SerializeField] private List<GameObject> outerWorlds;
    [SerializeField] private List<GameObject> doors;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // if (!StartOnInner) {
        //     outerSource.Play();
        // } else {
        //     innerSource.Play();
        // }
        outerSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        //reload scene when press f
        if (Input.GetKeyDown(KeyCode.F))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SwitchWorlds()
    {
        if (InnerWorldOn)
        {
            InnerWorldOn = false;
            innerWorld.SetActive(false);
            outerWorld.SetActive(true);
            exitObject.SetActive(false);
            if (puzzleObject != null)
            {puzzleObject.SetActive(false);}

            //Camera cam = Camera.main;
            //cam.clearFlags = CameraClearFlags.Skybox;
            innerSource.Stop();
            outerSource.Play();
            //player.transform.position = outerWorld.position;
            if (ExitThroughOuter) {
                exitObject.SetActive(true);
            }
        }
        else
        {
            InnerWorldOn = true;
            innerWorld.SetActive(true);
            outerWorld.SetActive(false);
            exitObject.SetActive(true);
            if (puzzleObject != null)
            {puzzleObject.SetActive(true);}

            //Camera cam = Camera.main;
            //cam.clearFlags = CameraClearFlags.SolidColor;
            outerSource.Stop();
            innerSource.Play();
            //player.transform.position = innerWorld.position;
        }
    }

    public void ChangeWorld(int index) {
        innerWorld.SetActive(false);
        innerWorld = outerWorlds[index-1];
        //resetDoors(index);
    }

    public void resetDoors(int index) {
        foreach (GameObject door in doors) {
            if (door.GetComponent<DoorTrigger>().worldIndex != index) {
                if (door.activeSelf) {
                door.SetActive(false);
            } else {
                door.SetActive(true);
            }
            }
            
        }
    }

    public void NextScene()
    {
        if (PuzzleSolved) {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1 < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            } else {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                //PlaytimeTracker.Instance.trackPlaytime();
            }
        }
    }

    public void PuzzleSolve()
    {
        PuzzleSolved = true;
        if (exitObjectHandle != null) {
            exitObjectHandle.SetActive(true);
        }
    }
 
}
