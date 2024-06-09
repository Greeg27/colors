using UnityEngine;

[RequireComponent (typeof(PlayerMovementScript))]

public class PlayerInputScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] LayerMask layerMask;

    private PlayerMovementScript playerMovementScript;
    private Ray castPoint;

    private void Awake()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
    }

    void Update()
    {
        MouseTargetPosition();
        EscPush();
    }

    private void MouseTargetPosition()
    {
        castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(castPoint, out RaycastHit hit, float.MaxValue, layerMask))
        {
            playerMovementScript.Movement(hit.point);
        }
    }

    private void EscPush()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            gameManager.Pause();
        }
    }
}
