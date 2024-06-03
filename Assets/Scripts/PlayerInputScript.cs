using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    [SerializeField] PlayerMovementScript playerMovementScript;
    [SerializeField] GameManager gameManager;
    [SerializeField] LayerMask layerMask;

    private Ray castPoint;

    private void Awake()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
    }

    void Update()
    {
        castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(castPoint, out RaycastHit hit, float.MaxValue, layerMask))
        {
            playerMovementScript.Movement(hit.point);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            gameManager.Pause();
        }
    }
}
