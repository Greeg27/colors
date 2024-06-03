using System.Collections;
using UnityEngine;

public class SeriesCreationScript : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] int seriesLength;
    [SerializeField] int seriesNumber;
    [SerializeField] int seriesInterval;

    private int firstXPosition;
    private System.Random rand = new System.Random();

    private void Awake()
    {
        firstXPosition = seriesLength / 2 * -1;
        Creation();
        //StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        for (int i = 0; i < seriesNumber; i++) 
        {
            yield return new WaitForSeconds(seriesInterval);
            Creation();
        }
        StopAllCoroutines();
    }

    public void Creation()
    {
        for (int j = 0; j < seriesNumber; j++)
        {
            for (int i = 0; i < seriesLength; i++)
            {
                Instantiate(objects[rand.Next(3)], new Vector3(firstXPosition + i, 1.5f, 5 + j), Quaternion.identity);
            }
        }
        
    }
}
