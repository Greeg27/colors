using UnityEngine;

public class LevelRoomParamScript : MonoBehaviour
{
    [SerializeField] Transform ground;
    [SerializeField] Transform floor;
    [SerializeField] Transform leftBord;
    [SerializeField] Transform rightBord;
    [SerializeField] Transform cam;
    [SerializeField] Transform player;
    [SerializeField] Transform SeriesFinish;
    [SerializeField] Transform destroyCube;
    [SerializeField] Transform roll;

    public void SetParametrs(float columns, float rows)
    {
        ground.position = new Vector3(0, 0, (rows + 30) / - 2 + 10);

        floor.localScale = new Vector3(columns + 2, floor.localScale.y, rows + 30);

        leftBord.localScale = new Vector3(60, leftBord.localScale.y, rows + 30);
        leftBord.position = new Vector3(columns / -2 - 30, leftBord.position.y, leftBord.position.z);

        rightBord.localScale = new Vector3(60, rightBord.localScale.y, rows + 30);
        rightBord.position = new Vector3(columns / 2 + 30, rightBord.position.y, rightBord.position.z);

        cam.position = new Vector3(0, cam.position.y, (rows + 7) * -1);

        player.position = new Vector3(0, player.position.y, (rows + 7) * -1);

        SeriesFinish.position = new Vector3(0, SeriesFinish.position.y, (rows + 9) * -1);

        destroyCube.position = new Vector3(0, destroyCube.position.y, (rows + 17) * -1);

        roll.localScale = new Vector3(roll.localScale.x, columns / 2 - 0.1f, roll.localScale.z);
    }
}
