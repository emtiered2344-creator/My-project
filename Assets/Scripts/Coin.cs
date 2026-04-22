using UnityEngine;

public class Coin : MonoBehaviour
{
    public float timeDecay = 5f; // Time in seconds before the coin disappears
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeDecay)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OrderManager.Instance.money += CoinSpawn.Instance.moneyPerCoin;
            Destroy(gameObject);
        }
    }
}
