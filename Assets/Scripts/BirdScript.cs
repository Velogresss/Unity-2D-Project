using UnityEngine;
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI passedLabel;
    [SerializeField]
    private GameObject alert;
    [SerializeField]
    private TMPro.TextMeshProUGUI alertLabel;

    private Rigidbody2D rigidBody;
    private int score;
    private bool needClear;

    [SerializeField]
    private int maxLives = 3;
    private int currentLives;
    [SerializeField]
    private TMPro.TextMeshProUGUI livesLabel; 

    void Start()
    {
        Debug.Log("BirdScript Start");
        rigidBody = GetComponent<Rigidbody2D>();
        score = 0;
        currentLives = maxLives;
        needClear = false;
        HideAlert();
        UpdateLivesDisplay(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, 300) * Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (alert.activeSelf)
            {
                HideAlert();
            }
            else
            {
                ShowAlert("Paused");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Collision!! " + other.gameObject.name);
            needClear = true;
            LoseLife(); 
        }
        else if (other.gameObject.CompareTag("Pass"))
        {
            GainLife(); 
            Destroy(other.gameObject); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pass"))
        {
            Debug.Log("+1");
            score++;
            passedLabel.text = score.ToString("D3");
        }
    }

    private void ShowAlert(string message)
    {
        alert.SetActive(true);
        alertLabel.text = message;
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void HideAlert()
    {
        alert.SetActive(false);
        Time.timeScale = 1f;
        if (needClear)
        {
            foreach (var pipe in GameObject.FindGameObjectsWithTag("Pass"))
            {
                GameObject.Destroy(pipe);
            }
            needClear = false;
        }
    }

    private void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLivesDisplay();
        }

        if (currentLives <= 0)
        {
            ShowAlert("Game Over!");
        }
        else
        {
            ShowAlert("OOOPS!"); 
        }
    }

    private void GainLife()
    {
        currentLives++;
        UpdateLivesDisplay();  
    }

    private void UpdateLivesDisplay()
    {
        livesLabel.text = $"Lives: {currentLives}";
    }
}