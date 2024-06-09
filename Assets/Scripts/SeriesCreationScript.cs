using UnityEngine;

public class SeriesCreationScript : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject Roll;

    private System.Random rand = new System.Random();
    private Transform thisTransform;

    private int columns, rows;
    private float firstXPosition;

    public void SetParametrs(int Columns, int Rows)
    {
        columns = Columns; rows = Rows;
        thisTransform = GetComponent<Transform>();
        firstXPosition = (Columns - 1) / -2f;
        SeriesCreation(5);
    }

    public void SeriesCreation(int offset)
    {
        for (int j = 0; j > -rows; j--)
        {
            for (int i = 0; i < columns; i++)
            {
                Instantiate(objects[rand.Next(objects.Length)], new Vector3(firstXPosition + i, 3f, j - offset), Quaternion.identity, thisTransform);
            }
        }

        Instantiate(Roll);
    }

}
