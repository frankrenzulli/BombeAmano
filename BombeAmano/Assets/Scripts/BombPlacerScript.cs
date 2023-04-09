using System.Collections;
using UnityEngine;

public class BombPlacerScript : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombActivatingTime = 3f;
    public int bombsAmount = 1;
    private int bombsRemaining;

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
}
