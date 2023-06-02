using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// This class changes the alpha value of a panel when user hovers over panel

public class HoverOverPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image panelImage;
    private Color normalColor;
    public float hoverAlpha = 1.0f;
    public float normalAlpha = 0.3f;

    private void Start()
    {
        panelImage = GetComponent<Image>();
        normalColor = panelImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color hoverColor = normalColor;
        hoverColor.a = hoverAlpha;
        panelImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color normalColorWithAlpha = normalColor;
        normalColorWithAlpha.a = normalAlpha;
        panelImage.color = normalColorWithAlpha;
    }
}
