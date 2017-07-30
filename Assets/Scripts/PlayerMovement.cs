using UnityEngine;
using TouchControlsKit;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    Transform playerTransform;
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    private float rotation = 0f;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");

        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        float h;
        float v;
        bool attack = false;

        //Attack
        if (TCKInput.GetButtonDown("Button0")) {
            attack = true;
        }

        // Store the input axes.
#if UNITY_EDITOR
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
#endif
#if UNITY_ANDROID
        h = TCKInput.GetAxis("Joystick0", AxisType.X);
        v = TCKInput.GetAxis("Joystick0", AxisType.Y);
        Debug.Log("h: " + h + " v: " + v);
#endif

        // Animate the player.
        Animating(h, v, attack);

        // Move the player around the scene.
        Move(h, v);

        // Turn the player to face the mouse cursor.
        Turningv2(h, v);

    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Avoid the player to 'fly'
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (newPosition.y >0)
            newPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);
        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(newPosition + movement);
    }

    void Turningv2(float h, float v)
    {
        Vector3 facingrotation = Vector3.Normalize(new Vector3(h, 0f, v));
        if (facingrotation != Vector3.zero)         //This condition prevents from spamming "Look rotation viewing vector is zero" when not moving.
            transform.forward = facingrotation;

    }

    void Animating(float h, float v, bool attack)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool idleing = h == 0f && v == 0f;
        bool walking = h != 0f || v != 0f;
        bool running = h > 0.2f || h < -0.2f || v > 0.2f || v < -0.2f;

        // Tell the animator whether or not the player is walking.
        if (attack)
        {
            anim.SetTrigger("Attack");
        }
        anim.SetBool("IsIdle", idleing);
        anim.SetBool("IsWalking", walking);
        anim.SetBool("IsRunning", running);

        if (running)
        {
            anim.speed = 1;
            speed = 4f;
            walking = false;
        }
        if (walking)
        {
            speed = 2f;
            anim.speed = 1.2f;
        }
    }
}