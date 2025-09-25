using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Lock
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private Collider2D collisionBox;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(!other.gameObject.CompareTag("Player"))
           return; 
        
        SceneManager.LoadScene(levelToLoad);
    }

    protected override void Unlock()
    {
       SoundManager.Instance.PlaySoundEffect("open");
        collisionBox.isTrigger = true;
    }
}
