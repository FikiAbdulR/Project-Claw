using UnityEngine;

public class ClawMovement : MonoBehaviour
{
    public static ClawMovement instance;

    public float moveSpeed = 5.0f;
    public float minX = -0.775f;
    public float maxX = 0.775f;
    public float minZ = -1.65f;
    public float maxZ = 1.65f;

    public bool isMoving = true;
    private Rigidbody rb;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMoving = true;
    }

private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        movement = movement.normalized * moveSpeed * Time.deltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        rb.MovePosition(newPosition);
    }
}
