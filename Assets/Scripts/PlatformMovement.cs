using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    float Speed;

    [SerializeField]
    BoxCollider2D Box;

    float GroundWidth;

    private void Start()
    {
        GroundWidth = Box.size.x;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);

        if (transform.position.x <= -GroundWidth)
        {
            transform.position = new Vector2(transform.position.x + 2 * GroundWidth, transform.position.y);
        }

    }
}
