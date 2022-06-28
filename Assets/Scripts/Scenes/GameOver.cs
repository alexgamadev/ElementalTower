using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
}
