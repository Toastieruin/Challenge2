using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    Animator anim;

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;

    public Text countText;
    public Text winText;
    public Text livesText;
    public Text pointText;

    private int count;
    private int point;
    private int enemy;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        count = 0;
        SetCountText();
        winText.text = "";
        point = 0;
        SetPointText();
        enemy = 0;
        lives = 3;
        SetlivesText();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        if (Input.GetKey("escape"))
            Application.Quit();
        
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
      if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
        if (collision.collider.tag == "Platform")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            point = count - enemy;
            SetPointText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            lives = lives - 1;
            SetlivesText();
            enemy = enemy + 1;
            other.gameObject.SetActive(false);
            point = count - enemy;
            SetPointText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 4)
        {
            SceneManager.LoadScene(1);
        }
    }

    void SetPointText()
    {
        pointText.text = "Point: " + point.ToString();

        if (point == 4)
        {
            winText.text = "You Win!";
        }
    }

    void SetlivesText()
    {
        livesText.text = "Lives:" + lives.ToString();
        if (lives <= 0)
        {
            winText.text = "You Lose";
            Destroy(rb2d)
        ;
        }
    }
}
