using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal, vertical;
    public float daSpeed = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * daSpeed, vertical * daSpeed);
    }

    void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}
