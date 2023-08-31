using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gamemanager : MonoBehaviour
{
    private int star;
    public TextMeshProUGUI startext;
    private int heart;
    public TextMeshProUGUI hearttext;

    private AudioSource audioSource;
    public AudioClip lifeloseclip;
    public AudioClip starclip;

    public GameObject GameoverPanel;

    public float slowingDownRate;
    public float slowMoLength;
    public static bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameover = false;
        heart = 3;
        hearttext.text = heart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(heart == 0)
        {
            GameOver();
            gameover = true;  //setting bool to true so blocks cant spawn after the game is over
        }
        if (Time.timeScale < 1)  //if timescale is less then 1 then perfom the below method
        {
            Time.timeScale += (1f / slowMoLength) * Time.unscaledDeltaTime;  //slowly setting time back 1f

            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);  //Clamping the value to 1 so it wont increase then 1
        }
    }
    public void Addstar()
    {
        audioSource.PlayOneShot(starclip); //Playing audioclip.
        star++;  //Adding value by 1
        startext.text = star.ToString();  //conversion to string
    }
    public void Decreaselife()
    {
        audioSource.PlayOneShot(lifeloseclip); //Playing clip

        heart--; //decreasing heart amount by one
        hearttext.text = heart.ToString(); //converting it to string for showing it as text on display
    }
    public void IncreaceLife()
    {
        if (heart < 3)
        {
            heart++;
            hearttext.text = heart.ToString(); //converting it to string for showing it as text on display
            audioSource.PlayOneShot(starclip);
        }
    }
    public void GameOver()
    {
        //activating gameoverpanel
        GameoverPanel.SetActive(true);

    }
    public void SlowMo()
    {

        Time.timeScale = slowingDownRate;

        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        //Debuging timescale for testing
        Debug.Log("Doing Slowmo");
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
