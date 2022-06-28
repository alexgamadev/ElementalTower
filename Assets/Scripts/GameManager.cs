using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    Timer _timer;

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        _timer = GetComponent<Timer>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _timer.StartTimer(true);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            _timer.StartTimer(true);
        }
    }

    public Timer GetTimer()
    {
        return _timer;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
