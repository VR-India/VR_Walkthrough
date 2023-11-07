using UnityEngine;

public class DissolveObjects : MonoBehaviour
{
    public Renderer[] render;
    public Material[] mat;

    private void Awake()
    {
        render = GetComponentsInChildren<Renderer>();

        mat = new Material[render.Length];
        for (int i = 0; i < render.Length; i++)
        {
            mat[i] = render[i].material;
        }
       // DissolveManager.instance.ResetDissolve(mat);
    }

    public bool isActive;
    private void Update()
    {
        DissolveUI();
        switch (isActive)
        {
            case true:                
                DissolveManager.instance.UnDissolve(mat);
                break;
            case false:
                DissolveManager.instance.Dissolve(mat);
                break;
        }
    }

    public GameObject monitorCanvas;
    public void DissolveUI()
    {
        if (monitorCanvas != null)
        {
            if (mat[1].GetFloat("_Dissolve") > 0.5f)
            {
                monitorCanvas.SetActive(false);
            }
            if (mat[1].GetFloat("_Dissolve") < 0.4f)
            {
                monitorCanvas.SetActive(true);
            }
        }
    }
}