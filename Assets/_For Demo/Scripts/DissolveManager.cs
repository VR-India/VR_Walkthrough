using UnityEngine;
public class DissolveManager : MonoBehaviour
{
    public static DissolveManager instance;
    private void Awake() { instance = this; }
    public float value;
    public void Dissolve(Material[] render)
    {
        if (value < 1)  value += 0.002f;
        foreach (Material mat in render)
        {
            mat.SetFloat("_Dissolve", value);
        }
    }
    public void UnDissolve(Material[] render)
    {
        if (value > 0) value -= 0.002f;
        foreach (Material mat in render)
        {
            mat.SetFloat("_Dissolve", value);
        }
    }
    public void ResetDissolve(Material[] render)
    {
        foreach (Material mat in render)
        {
            mat.SetFloat("_Dissolve", 1);
        }
    }
}