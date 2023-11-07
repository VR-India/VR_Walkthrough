using UnityEngine;

public class QuestButtonsHighlighter : MonoBehaviour
{
    [Header("Debug")]
    public TMPro.TMP_Text buttonPressText;
    public TMPro.TMP_Text indexCount;
    public Color color;

    void Update()
    {
        ButtonChecker();
        indexCount.text = "Index : " + GameManager.instance.index;
    }

    void ButtonChecker()
    {
        if (BNG.InputBridge.Instance.LeftTrigger > 0) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[7], color);
            GameManager.instance.ValidatteMyClick("LeftTrigger"); 
            buttonPressText.text = "LeftTrigger"; 
        }
        else if (BNG.InputBridge.Instance.RightTrigger > 0) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[2], color); 
            buttonPressText.text = "RightTrigger";
        }
        else if (BNG.InputBridge.Instance.AButton) 
        {
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[0], color);
            buttonPressText.text = "A Button";
        }
        else if (BNG.InputBridge.Instance.BButton) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[1], color); 
            buttonPressText.text = "B Button"; 
        }
        else if (BNG.InputBridge.Instance.XButton) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[5], color); 
            buttonPressText.text = "X Button";
        }
        else if (BNG.InputBridge.Instance.YButton) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[6], color); 
            buttonPressText.text = "Y Button";
        }
        else if (BNG.InputBridge.Instance.LeftGrip > 0) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[8], color); 
            buttonPressText.text = "Left Grip";
        }
        else if (BNG.InputBridge.Instance.RightGrip > 0) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[3], color); 
            buttonPressText.text = "Right Grip";
        }
        else if (BNG.InputBridge.Instance.LeftThumbstickAxis.magnitude != 0) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[9], color); 
            buttonPressText.text = "LeftThumbstickAxis";
        }
        else if (BNG.InputBridge.Instance.RightThumbstickAxis.magnitude != 0) 
        { 
            //GameManager.instance.MaterialSwitcher(ButtonsMesh.instance.displayControllerMesh[4], color); 
            buttonPressText.text = "RightThumbstickAxis";
        }
        else
        {
            
            foreach (MeshRenderer item in ButtonsMesh.instance.displayControllerMesh)
            {
                //GameManager.instance.MaterialResetter(item);
            }           
        }
    }

}
