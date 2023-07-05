using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load1stArea : MonoBehaviour
{
    public string loadWhat;

    public void OnButtonPress()
    {
        SceneManager.LoadScene(loadWhat);
    }
}
