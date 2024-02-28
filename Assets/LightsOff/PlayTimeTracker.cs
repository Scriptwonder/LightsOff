using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class PlaytimeTracker : MonoBehaviour
{
    public static PlaytimeTracker Instance;

    public float playtimeSeconds;

    public TextMeshProUGUI playtimeText;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        trackPlaytime();
    }

    void StartPlaytime()
    {
        playtimeSeconds = 0f;
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == 0) {
            trackPlaytime();
        }
        
    }

    void Update()
    {
        // Update the playtime every frame
        playtimeSeconds += Time.deltaTime;
    }

    public void trackPlaytime()
    {
        // Track the playtime
        if (PlaytimeTracker.Instance != null)
        {
            // Convert seconds to minutes
            float minutesPlayed = PlaytimeTracker.Instance.playtimeSeconds / 60f;
            if (playtimeText == null && GameObject.Find("PlaytimeText") != null) {
                playtimeText = GameObject.Find("PlaytimeText").GetComponent<TextMeshProUGUI>();
            }
            if (playtimeText != null) {
                playtimeText.text = "Best Score: " + minutesPlayed.ToString("F2") + " minutes";
            }
            StartPlaytime();
        }
    }
}
