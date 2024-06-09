using TMPro;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField] ParticleSystem bonus;
    [SerializeField] TMP_Text scoreValueText;
    [SerializeField] TimerScript timerScript;
    [SerializeField] AudioManagerScript audioManagerScript;

    private MeshRenderer playerMesh;
    private MeshRenderer colMesh;
    private float r, g, b;
    private int score;

    private void Awake()
    {
        playerMesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            audioManagerScript.CollisionAudioPlay(collision.gameObject);
            ColorChange(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void ColorChange(GameObject collision)
    {
        colMesh = collision.gameObject.GetComponent<MeshRenderer>();

        if (colMesh.material.color == playerMesh.material.color)
        {
            score++;
            scoreValueText.text = score.ToString();
            timerScript.TimeIncreasing();

            bonus.transform.position = collision.transform.position;
            bonus.Play();
        }
        else if (playerMesh.material.color == new Color(1, 1, 1))
        {
            playerMesh.material.color = colMesh.material.color;
        }
        else
        {
            if (colMesh.material.color.r + playerMesh.material.color.r > 0) r = 1; else r = 0;
            if (colMesh.material.color.g + playerMesh.material.color.g > 0) g = 1; else g = 0;
            if (colMesh.material.color.b + playerMesh.material.color.b > 0) b = 1; else b = 0;

            playerMesh.material.color = new Color(r, g, b);
        }
    }

}
