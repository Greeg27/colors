using TMPro;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField] ParticleSystem bonus;
    [SerializeField] TMP_Text scoreValueText;

    private MeshRenderer playerRenderer;
    private MeshRenderer colRenderer;
    private float r;
    private float g;
    private float b;
    private int score;

    private void Awake()
    {
        playerRenderer = GetComponent<MeshRenderer>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            colRenderer = collision.gameObject.GetComponent<MeshRenderer>();

            if (colRenderer.material.color == playerRenderer.material.color)
            {
                score++;
                scoreValueText.text = score.ToString();

                bonus.transform.position = collision.transform.position;
                bonus.Play();
            }
            else if (playerRenderer.material.color == new Color(1, 1, 1))
            {
                playerRenderer.material.color = colRenderer.material.color;
            }
            else
            {
                if (colRenderer.material.color.r + playerRenderer.material.color.r > 0) r = 1; else r = 0;
                if (colRenderer.material.color.g + playerRenderer.material.color.g > 0) g = 1; else g = 0;
                if (colRenderer.material.color.b + playerRenderer.material.color.b > 0) b = 1; else b = 0;

                playerRenderer.material.color = new Color(r, g, b);
            }

            Destroy(collision.gameObject);
        }
    }
}
