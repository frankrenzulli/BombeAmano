using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedIncrease = 5f;
    public float powerUpDuration = 1f;

    private P1Movement player;
    private bool isActive = false;
    private float timeLeft = 0f;
    private float originalSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player = collision.GetComponent<P1Movement>();
            ActivatePowerUp();
            gameObject.SetActive(false);

        }
    }

    private void ActivatePowerUp()
    {
        if (!isActive)
        {
            isActive = true;
            timeLeft = powerUpDuration;
            originalSpeed = player.GetSpeed();
            player.SetSpeed(originalSpeed + speedIncrease); // aumenta la velocità del giocatore
            StartCoroutine(PowerUpTimer()); // avvia la coroutine per il conto alla rovescia del power up
        }
    }
    private void DeactivatePowerUp()
    {
        if (isActive)
        {
            isActive = false;
            player.SetSpeed(2); // ripristina la velocità originale del giocatore 
        }
    }

    private IEnumerator PowerUpTimer()
    {
        while (timeLeft > 0f)
        {
            yield return new WaitForSeconds(1f); // attendi un secondo
            timeLeft -= 1f; // sottrai un secondo al tempo rimanente
        }
        DeactivatePowerUp(); // disattiva il power up quando il tempo è scaduto
    }

}
