using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int collectableQuantity = 0;
    private Text collectableQuantityText;
    private ParticleSystem collectableParticles;
    private AudioSource collectableAudio;

    void Start()
    {
        collectableParticles = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        collectableAudio = GameObject.Find("CollectableAudio").GetComponent<AudioSource>();
        collectableQuantityText = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            collectableParticles.transform.position = transform.position;
            collectableParticles.Play();
            collectableAudio.Play();
            gameObject.SetActive(false);
            collectableQuantity += 1;
            collectableQuantityText.text = collectableQuantity.ToString();
        }
    }
}
