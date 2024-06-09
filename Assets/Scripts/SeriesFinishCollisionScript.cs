using UnityEngine;

public class SeriesFinishCollisionScript : MonoBehaviour
{
    [SerializeField] SeriesCreationScript seriesCreationScript;
    [SerializeField] LavelRoomRotateScript lavelRoomRotateScript;

    private void OnTriggerEnter(Collider other)
    {
        lavelRoomRotateScript.LavelRoomRotate();
        seriesCreationScript.SeriesCreation(1);
        Destroy(other.gameObject);
    }
}
