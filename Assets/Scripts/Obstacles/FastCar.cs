using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastCar : MonoBehaviour
{
    private int lives = 3;

    [SerializeField]
    private Obstacle obs;

    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private MeshRenderer plane;

    private TargetIndicator targetIndicator;
    private bool activated;


    void Start()
    {
        gameObject.GetComponent<Rigidbody>();
    } 

    void Update(){
        
        NotifyPlayer();
        /*if(transform.position.z > GameManager.Instance.playerpos.position.z)
            rb.constraints = RigidbodyConstraints.None;*/
        obs.forwardSpeed = GameManager.Instance.playerSpeed + 11f;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("PlayerBack"))
        {
            GameManager.Instance.GameOver();

        }
        else if (other.collider.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            other.gameObject.GetComponent<Obstacle>().Destroy();
            if (lives == 0)
                obs.Destroy();
        }
    }

    void NotifyPlayer()
    {
        if (GameManager.Instance.playerpos.position.z - transform.position.z < 100)
        {
            targetIndicator.UpdateTargetIndicator();
            if (targetIndicator.isInSIght())
                plane.enabled = false;
            else if (!activated)
            {
                activated = true;
                plane.enabled = true;

            }

            Blink();

        }
    }

    private bool blinked = false;
    private void Blink()
    {
        if (blinked)
            return;
        if (GameManager.Instance.playerpos.position.z - transform.position.z > 50)
            return;
        blinked = true;
        StartCoroutine(BlinkAnimation());
    }

    private IEnumerator BlinkAnimation()
    {
        plane.enabled = false;
        yield return new WaitForSeconds(0.2f);
        plane.enabled = true;
        yield return new WaitForSeconds(0.2f);
        plane.enabled = false;
        yield return new WaitForSeconds(0.2f);
        plane.enabled = true;
        
    }

    private void OnDisable()
    {
        if (targetIndicator == null)
            return;
        targetIndicator.gameObject.SetActive(false);
    }

    private bool first = true;
    private void OnEnable()
    {
        if (first)
        {
            first = false;
            return;
        }

        activated = false;
        blinked = false;
        lives = 3;
        targetIndicator = Instantiate(exclamationMark, GameManager.Instance.canvas.transform).GetComponent<TargetIndicator>();
        targetIndicator.InitialiseTargetIndicator(gameObject, GameManager.Instance.camera, GameManager.Instance.canvas);
    }
}
