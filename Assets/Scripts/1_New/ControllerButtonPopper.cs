
using UnityEngine;

public class ControllerButtonPopper : MonoBehaviour
{
    #region Controller 3D Text References
    [Header("Controller 3D Text References",order = 0)]
    [Header("Left Controller TMP Text",order = 1)]
    public TMPro.TextMeshPro Left_ThumbStick;
    public TMPro.TextMeshPro Y_Button,X_Button,Left_Grip,Left_Trigger;
    [Space(10)]
    [Header("Right TMP Text",order = 2)]
    public TMPro.TextMeshPro Right_ThumbStick;
    public TMPro.TextMeshPro B_Button,A_Button,Right_Grip,Right_Trigger;
    #endregion

    void Update()
    {
        CheckIfButtonIsPressedForTextPopUp();
    }


    void CheckIfButtonIsPressedForTextPopUp()
    {
        if(BNG.InputBridge.Instance.AButton){A_Button.enabled = true;}
        else{A_Button.enabled = false;}
        if(BNG.InputBridge.Instance.BButton){B_Button.enabled = true;}
        else{B_Button.enabled = false;}
        if(BNG.InputBridge.Instance.RightThumbstickAxis.magnitude != 0){Right_ThumbStick.enabled = true;}
        else{Right_ThumbStick.enabled = false;}
        if(BNG.InputBridge.Instance.RightGrip > 0){Right_Grip.enabled = true;}
        else{Right_Grip.enabled = false;}
        if(BNG.InputBridge.Instance.RightTrigger > 0){Right_Trigger.enabled = true;}
        else{Right_Trigger.enabled = false;}

        if(BNG.InputBridge.Instance.XButton){X_Button.enabled = true;}
        else{X_Button.enabled = false;}
        if(BNG.InputBridge.Instance.YButton){Y_Button.enabled = true;}
        else{Y_Button.enabled = false;}
        if(BNG.InputBridge.Instance.LeftThumbstickAxis.magnitude != 0){Left_ThumbStick.enabled = true;}
        else{Left_ThumbStick.enabled = false;}
        if(BNG.InputBridge.Instance.LeftGrip > 0){Left_Grip.enabled = true;}
        else{Left_Grip.enabled = false;}
        if(BNG.InputBridge.Instance.LeftTrigger > 0){Left_Trigger.enabled = true;}
        else{Left_Trigger.enabled = false;}
    }


    
}
