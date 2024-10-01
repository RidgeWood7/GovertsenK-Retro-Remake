using System.Xml.Serialization;
using UnityEngine;


public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] runSprite;
    public Sprite climbSprite;
    public int spriteIndex;

    private new Rigidbody2D rigidbody;
    private new Collider2D collider;

    private Collider2D[] results;
    private Vector2 direction;

    public float moveSpeed = 1f;
    public float jumpStrength = 1f;

    private bool grounded;
    private bool climbing;

    public Vector2 size;
    public Vector2 size2;

    public Vector3 offset;
    public Vector3 offset2;

    public LayerMask groundlayer;
    public LayerMask ladderlayer;

    public float turnspeed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        results = new Collider2D[4];
    }

   private void OnEnable()
   {
       InvokeRepeating(nameof(AnimateSprite), 1f / 12f, 1f/12f);
   }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void CheckCollision()
    {
        grounded = Physics2D.BoxCast(transform.position + offset, size, 0f, Vector2.zero, 0, groundlayer);

        climbing = Physics2D.BoxCast(transform.position + offset2, size2, 0f, Vector2.zero, 0, ladderlayer);
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + offset, size);

        Gizmos.DrawCube(transform.position + offset2, size2);
    }

    private void Update()
    {
        CheckCollision();
        if (climbing)
        {
            direction.y = Input.GetAxis("Vertical") * moveSpeed;
        }

        else if (grounded && Input.GetButtonDown("Jump"))
        {
            direction.y =jumpStrength;
        }
        if (grounded)
        {
            direction.y = Mathf.Max(direction.y, -1f);
        }
        else
        {
            direction += Physics2D.gravity * Time.deltaTime;
        }

        direction.x = Mathf.Lerp(direction.x, Input.GetAxis("Horizontal") * moveSpeed, Time.deltaTime * turnspeed);

        if (direction.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        } else if (direction.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * Time.fixedDeltaTime);
    }
    private void AnimateSprite()
    {
        if (climbing)
        {
            spriteRenderer.sprite = climbSprite;
        }

        else if (direction.x != 0f)
        {
            spriteIndex++;

            if (spriteIndex >= runSprite.Length)
            {
                spriteIndex = 0;
            }

            spriteRenderer.sprite = runSprite[spriteIndex];
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            enabled = false;
            FindObjectOfType<GameManager>().LevelComplete();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            enabled = false;
            FindObjectOfType<GameManager>().LevelFailed();
        }
    }
}
