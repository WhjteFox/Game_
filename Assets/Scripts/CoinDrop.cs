using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    public int amount;
    public GameObject template;
    public void CoinDroper()
    {
        if (template != null){
        for(int i=0; i < amount; i++){
            GameObject coin = Instantiate(template);
            coin.gameObject.transform.position = new Vector2(gameObject.transform.position.x+Random.Range(-2,2),gameObject.transform.position.y-1);
        }}
    }
}
