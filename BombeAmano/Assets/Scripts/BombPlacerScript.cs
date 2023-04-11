using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BombPlacerScript : MonoBehaviour
{
    [Header("Bombs")]
    public GameObject bombPrefab;
    public float bombActivatingTime = 3f;
    public int bombsAmount = 1;
    private int bombsRemaining;

    [Header("Explosion")]
    public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;

    private void OnEnable()
    {
        bombsRemaining = bombsAmount;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && bombsRemaining > 0){
            StartCoroutine(PlaceBombs());
        }
    }

    private IEnumerator PlaceBombs()
    {
        //Arrotonda la posizione della bomba per farla combaciare con le tiles
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(bombActivatingTime);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.startAnim);
        explosion.DestroyTime(explosionDuration);

        Explode(position, Vector2.up ,explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);

        Destroy(bomb);
        bombsRemaining++;
    }

    private void OnTriggerExit2D(Collider2D collision)//quando il player esce dal collider della bomba può spingerla
    {
       
        if(collision.gameObject.tag == "Bomb")
        {
            collision.isTrigger = false;
        }

    }

    private void Explode(Vector2 position, Vector2 direction, int ExplosionRadius /*lunghezza esplosione*/)
    {
        //esce dalla funzione quando il raggio dell'esplosione è uguale a 0
        if(ExplosionRadius <= 0)
        {
            return;
        }

        position += direction;

        if(Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);

        if (ExplosionRadius > 1)
        {
            explosion.SetActiveRenderer(explosion.middleAnim);
        }
        else
        {
            explosion.SetActiveRenderer(explosion.endAnim);
        }
        explosion.SetDirection(direction);
        explosion.DestroyTime(explosionDuration);

        Explode(position, direction, ExplosionRadius - 1);
    }
}
