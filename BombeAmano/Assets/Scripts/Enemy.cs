using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    GameManager gm;
    public float moveTime = 0.5f; // Tempo di movimento del nemico
    public LayerMask blockingLayer; // Layer che blocca il movimento del nemico

    private Transform target; // Transform del nemico
    private bool isMoving; // Indica se il nemico sta già muovendosi
    private Vector2[] directions = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; // Direzioni possibili per il movimento del nemico

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        target = GetComponent<Transform>(); // Ottiene il Transform del nemico
    }

    void Update()
    {
        // Se il nemico non sta già muovendosi, sceglie una nuova direzione randomica
        if (!isMoving)
        {
            Vector2 direction = directions[Random.Range(0, directions.Length)];

            // Calcola la posizione target in base alla direzione scelta
            Vector3 targetPosition = target.position + new Vector3(direction.x, direction.y, 0);

            // Effettua il raycast per verificare se la direzione scelta è bloccata
            RaycastHit2D hit;
            if (!Physics2D.Linecast(target.position, targetPosition, blockingLayer))
            {
                // Se la direzione non è bloccata, muove il nemico verso la posizione target
                StartCoroutine(SmoothMovement(targetPosition));
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Explosion")
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator SmoothMovement(Vector3 end)
    {
        isMoving = true;
        float inverseMoveTime = 1f / moveTime;

        float sqrRemainingDistance = (target.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(target.position, end, inverseMoveTime * Time.deltaTime);
            target.position = newPosition;
            sqrRemainingDistance = (target.position - end).sqrMagnitude;
            yield return null;
        }

        isMoving = false;
    }
    
}