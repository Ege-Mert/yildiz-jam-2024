using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameFinish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheTime());
    }

   IEnumerator TheTime()
   {
    yield return new WaitForSeconds(8);
    SceneManager.LoadScene(0);
   }
}
