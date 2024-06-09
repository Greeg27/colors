using UnityEngine;

public class LostBallsScript : MonoBehaviour
{
    [SerializeField] TimerScript timerScript;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        timerScript.TimeDecrease();
    }
}
