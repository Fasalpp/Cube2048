using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Camera cam;
    private Vector3 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        UpadateTargetPos();
    }

    private void FixedUpdate()
    {
        MoveToPointer();
    }
    void UpadateTargetPos()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray,out RaycastHit hitInfo, 100f, groundLayer))
        {
            targetPosition = hitInfo.point;
        }
    }

    void MoveToPointer()
    {
        Vector3 direction = (targetPosition - transform.position);
        direction.y = 0;

        if(direction.magnitude > 0.1f)
        {
            Vector3 move = direction.normalized * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);

            Quaternion target = Quaternion.LookRotation(direction);
            rb.rotation = Quaternion.Slerp(rb.rotation, target, 10f * Time.fixedDeltaTime);
        }
    }
}
