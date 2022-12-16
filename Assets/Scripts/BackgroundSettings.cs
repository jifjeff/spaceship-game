using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSettings : MonoBehaviour
{
    public Sprite[] backgrounds;
    public GameSettings gameSettings;

    // Update is called once per frame
    void Update()
    {
        backgroundChange(gameSettings.score);
    }

    private void backgroundChange(int score)
    {
        if (score % 200000 == 0)
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite != cycleBackgrounds())
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = cycleBackgrounds();
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = backgrounds[Random.Range(0, backgrounds.Length)];
            }
            
        }

    }
 
    private Sprite cycleBackgrounds()
    {
        return backgrounds[Random.Range(0, backgrounds.Length)];
    }
}
