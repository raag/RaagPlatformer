using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int collectableQuantity = 0;
    public Text collectableQuantityText;
    public ParticleSystem collectableParticles;
    void Start()
    {
        collectableParticles = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            collectableParticles.transform.position = transform.position;
            collectableParticles.Play();
            gameObject.SetActive(false);
            collectableQuantity += 1;
            collectableQuantityText.text = collectableQuantity.ToString();
        }
    }
}
