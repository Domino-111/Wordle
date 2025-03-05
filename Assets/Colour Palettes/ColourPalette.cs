using UnityEngine;

[CreateAssetMenu(fileName = "Colour Palette")]
public class ColourPalette : ScriptableObject
{
    public Color backgroundColour = new Color(0, 0, 0, 1);

    public Color panelColour = new Color(0, 0, 0, 1);
    public Color rowColour = new Color(0, 0, 0, 1);
    public Color cellColour = new Color(0, 0, 0, 1);

    public Color regularTextColour = new Color(0, 0, 0, 1);
    public Color hot = new Color(0, 0, 0, 1);
    public Color warm = new Color(0, 0, 0, 1);
    public Color cold = new Color(0, 0, 0, 1);
}
