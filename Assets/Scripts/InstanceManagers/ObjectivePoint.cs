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
            newPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4.7f, 4.7f), 0f);
        } while((newPosition - playerStartTransform.position).magnitude < distanceFromPlayer);
        transform.position = newPosition;
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
                newPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4.7f, 4.7f), 0f);
            } while((newPosition - transform.position).magnitude < distanceFromPlayer);
            transform.position = newPosition;
        }
    }
}
