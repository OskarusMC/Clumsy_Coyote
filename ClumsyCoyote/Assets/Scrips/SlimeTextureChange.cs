using UnityEngine;

public class SlimeTextureChange : MonoBehaviour
{
    public Sprite Sprite1;
    public Sprite Sprite2;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        if (Random.Range(1, 3) == 1)
        {
            sr.sprite = Sprite1;
        } else
        {
            sr.sprite = Sprite2;
        }
    }
}