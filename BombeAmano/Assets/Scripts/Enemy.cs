using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    GameManager gm;
    public float moveTime = 0.5f; 
    public LayerMask blockingLayer;


    private bool isMoving; 
    private Vector2[] directions = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        // Ottieni il riferimento all'EnemyManager
        EnemyManager enemyManager = FindObjectOfType<EnemyManager>();

        // Aggiungi te stesso alla lista dell'EnemyManager
        enemyManager.enemyList.Add(this.gameObject);
    }

    void Update()
    {

        if (!isMoving)
        {
            Vector2 direction = directions[Random.Range(0, directions.Length)];

            Vector3 targetPosition = transform.position + new Vector3(direction.x, direction.y, 0);


            if (!Physics2D.Linecast(transform.position, targetPosition, blockingLayer))
            {
                StartCoroutine(SmoothMovement(targetPosition));
            }
        }

    }



    IEnumerator SmoothMovement(Vector3 end)
    {
        isMoving = true;
        float inverseMoveTime = 1f / moveTime;

        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
            transform.position = newPosition;
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }

        isMoving = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Explosion2"))
        {
            // Rimuovi te stesso dalla lista dell'EnemyManager
            EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
            enemyManager.enemyList.Remove(this.gameObject);

            Debug.Log("Ok");
            Destroy(gameObject);
        }
    }
}
