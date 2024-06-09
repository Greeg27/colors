using UnityEngine;

public class LavelRoomRotateScript : MonoBehaviour
{
    private float angle, angleBoost;

    public void SetParametrs(float Angle, float AngleBoost)
    {
        angle = -Angle;
        angleBoost = -AngleBoost;

        LavelRoomRotate();
    }

    public void LavelRoomRotate()
    {
        transform.rotation = Quaternion.Euler(angle, 0, 0);
        angle += angleBoost;
    }

}
