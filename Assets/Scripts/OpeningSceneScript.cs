using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneScript : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(1);

    }
}
