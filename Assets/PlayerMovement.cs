using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 10f;
    public float Gravity = -10f;
    public float JumpHeight = 1f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    private Vector3 Velocity;
    private bool IsGrounded;

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var move = transform.right * x + transform.forward * z;
        Controller.Move(move * Speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }
        Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }
}
