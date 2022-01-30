using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        ObjectPool.Instance.ReturnAllObjectsToPool();
        SceneManager.LoadScene("main");
    }
}
