using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    private float xMin, xMax, yMin, yMax;  // Batas posisi di layar

    private void Start()
    {
        // Initialize Rigidbody2D and calculate initial velocities and frictions
        rb = GetComponent<Rigidbody2D>();

        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);

        // Dapatkan ukuran collider pemain
        Collider2D playerCollider = GetComponent<Collider2D>();
        float colliderHalfWidth = playerCollider.bounds.extents.x;
        float colliderHalfHeight = playerCollider.bounds.extents.y;

        // Dapatkan batas layar berdasarkan kamera
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Menghitung batas dengan mempertimbangkan ukuran collider pemain
        xMin = Camera.main.transform.position.x - cameraWidth + colliderHalfWidth;
        xMax = Camera.main.transform.position.x + cameraWidth - colliderHalfWidth;
        yMin = Camera.main.transform.position.y - cameraHeight + colliderHalfHeight;
        yMax = Camera.main.transform.position.y + cameraHeight - colliderHalfHeight;
    }

    private void FixedUpdate()
    {
        Move();
        ClampPosition();  // Batasi posisi pesawat
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(inputX, inputY).normalized;

        rb.velocity = moveDirection * maxSpeed;
    }

    private void ClampPosition()
    {
        // Membatasi posisi pesawat agar tetap dalam layar
        Vector2 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yMin, yMax);

        // Terapkan posisi yang sudah dibatasi
        rb.position = clampedPosition;
    }

    private Vector2 GetFriction()
    {
        // Return friction based on whether the player is moving
        return rb.velocity.magnitude > 0 ? stopFriction : Vector2.zero;
    }

    public bool IsMoving()
    {
        // Return true if there is significant movement
        return rb.velocity.magnitude > 0.1f;
    }
}