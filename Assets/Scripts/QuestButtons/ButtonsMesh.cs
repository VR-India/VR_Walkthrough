using System.Collections.Generic;
using UnityEngine;
public class ButtonsMesh : MonoBehaviour
{
    public List<MeshRenderer> handControllerMesh, displayControllerMesh;
    public static ButtonsMesh instance;
    private void Awake() { instance = this; }
}