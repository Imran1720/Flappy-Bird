using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField]
    float Speed;

    [SerializeField]
    Rigidbody2D Rb;

    [SerializeField]
    float Angle, MaxAngle, MinAngle;

    public Database db;



    bool CallOnce = true;



    private void Start()
    {
        db.ClickCounter = 0;
        db.IsStarted = false;
        db.Score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            db.ClickCounter++;
        }
        CheckClickCount();
        if (db.IsStarted && db.ClickCounter >= 2)
        {
            GameManager.instance.PlayGame();
            BirdMovement();

        }
        else
        {
            Rb.isKinematic = true;
        }
    }

    private void CheckClickCount()
    {
        if (db.ClickCounter >= 2)
        {
            db.IsStarted = true;
            if (db.IsStarted && CallOnce)
            {
                CallOnce = false;
                Time.timeScale = 1f;

            }
        }
    }

    private void BirdMovement()
    {
        Rb.isKinematic = false;
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager._AudioManager.PlaySound(AudioManager._AudioManager.Wing, SoundPlay());
            Rb.velocity = Vector2.zero;
            Rb.velocity = new Vector2(Rb.velocity.x, Speed);
        }
        BirdRotation();

    }

    void BirdRotation()
    {
        if (Rb.velocity.y > 0)
        {
            if (Angle <= MaxAngle)
            {
                Angle += 0.3f;
            }
        }
        else if (Rb.velocity.y < 0f)
        {
            if (Angle > MinAngle)
            {
                Angle -= 0.1f;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, Angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obstacle"))
        {

            AudioManager._AudioManager.PlaySound(AudioManager._AudioManager.Die, SoundPlay());
            GameManager.instance.GameOver();
            db.IsStarted = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("ScoreCounter"))
        {
            AudioManager._AudioManager.PlaySound(AudioManager._AudioManager.Pass, SoundPlay());
            db.Score++;

        }
    }

    private void OnDestroy()
    {
        if (db.MaxScore < db.Score)
        {
            db.MaxScore = db.Score;
        }
    }

    bool SoundPlay()
    {
        return Time.timeScale == 0 ? false : true;
    }
}
