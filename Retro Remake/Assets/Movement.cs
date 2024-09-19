using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, jump = KeyCode.Space;
    public float speed = 3, jumpHeight = 10;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetKey() is for HOLDING a key
        // Input.GetKeyDown() is for PRESSING a key
        // Input.GetKeyUp() is for RELEASING a key

        if (Input.GetKey(left)) //Check for the player HOLDING DOWN the left button
        {
            //gte the GameObject's Rigidbody2D component and set it's velocity to the left at the given speed.
            _rb.velocity = Vector2.left * speed;
        }

        if (Input.GetKey(up)) //Check for the player HOLDING DOWN the up button
        {
            //gte the GameObject's Rigidbody2D component and set it's velocity to the up at the given speed.
            _rb.velocity = Vector2.up * speed;
        }

        if (Input.GetKey(down)) //Check for the player HOLDING DOWN the down button
        {
            //gte the GameObject's Rigidbody2D component and set it's velocity to the down at the given speed.
            _rb.velocity = Vector2.down * speed;
        }

        if (Input.GetKey(right)) //Check for the player HOLDING DOWN the right button
        {
            //gte the GameObject's Rigidbody2D component and set it's velocity to the right at the given speed.
            _rb.velocity = Vector2.right * speed;
        }

        if (Input.GetKey(jump)) //Check for the player PRESSING the jump button
        {
            //gte the GameObject's Rigidbody2D component and set it's velocity to the right at the given speed.
            _rb.velocity = Vector2.up * jumpHeight;
        }
    }
}
