using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangePanelColor : MonoBehaviour, IPointerClickHandler
{
    public Color clickColor = Color.red; // Color after the panel is clicked
    private Color originalColor; // To store the original color

    private Image panelImage; // The Image component of the panel

    void Start()
    {
        // Retrieve the Image component from this GameObject
        panelImage = GetComponent<Image>();
        originalColor = panelImage.color; // Save the original color
    }

    // This function is called when the GameObject is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // Toggle color between original and click color
        if(panelImage.color == originalColor)
            panelImage.color = clickColor;
        else
            panelImage.color = originalColor;
    }
}
