using UnityEngine;

public class UIToggleable : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite toggledSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool toggled = false;

    public void Toggle()
    {
        toggled = !toggled;
        spriteRenderer.sprite = toggled ? toggledSprite : defaultSprite;
    }



}
