using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSettings : MonoBehaviour
{
    public Sprite nebulaRed;
    public Sprite nebulaBlue;
    public Sprite nebulaAqua;
    public GameSettings gameSettings;
    // Start is called before the first frame update
    void Start()
    {      
        
    }

    // Update is called once per frame
    void Update()
    {
        backgroundChange(gameSettings.score);
    }

    private void backgroundChange(int score)
    {
        switch(score)
        {
            case 500000:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = nebulaAqua;
                break;
            case 100000:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = nebulaBlue;
                break;
        }

    }
}
