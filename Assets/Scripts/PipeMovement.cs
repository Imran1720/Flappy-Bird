using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField]
    float Speed, MinPos, MaxPos;

    private void Start()
    {
        RandomPosition();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);

        if (transform.position.x <= -1.69)
        {
            RandomPosition();
            transform.position = new Vector2(1.1f, transform.position.y);
        }

    }

    void RandomPosition()
    {
        float pos = Random.Range(MinPos, MaxPos);

        transform.position = new Vector2(transform.position.x, pos);
    }
}
