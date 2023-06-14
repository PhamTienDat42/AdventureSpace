using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectItemSoundEffect;
    private string cherry = "Cherry";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag(cherry))
        {
            Destroy(collision.gameObject);
            cherries++;
            collectItemSoundEffect.Play();  
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
