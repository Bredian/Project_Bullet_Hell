using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectivePoint : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public UnityEvent<int> OnScoreChange;
    [SerializeField] private float angularSpeed;
    [SerializeField] private float distanceFromPlayer;
    [SerializeField] private AudioSource pickupStar;
    void Start()
    {
        OnScoreChange.AddListener((dead) =>
        {
            pickupStar.Play();
        });
        Transform playerStartTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 newPosition;
        do
        {
            
            float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 0.73f, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 0.73f);
            float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 0.73f, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 0.73f);
            newPosition = new Vector3(spawnX, spawnY, 0f);
        } while((newPosition - playerStartTransform.position).magnitude < distanceFromPlayer);
        transform.position = newPosition;
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, angularSpeed);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            score++;
            OnScoreChange.Invoke(score);
            Vector3 newPosition;
            do
            {
                float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 0.73f, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 0.73f);
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 0.73f, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 0.73f);
                newPosition = new Vector3(spawnX, spawnY, 0f);
            } while((newPosition - transform.position).magnitude < distanceFromPlayer);
            transform.position = newPosition;
        }
    }
}
