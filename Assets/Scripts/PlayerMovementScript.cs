using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Movement(Vector3 target)
    {
        rb.velocity = (target - transform.position) * GlobalVars.PlayerSpeed;
    }

}
