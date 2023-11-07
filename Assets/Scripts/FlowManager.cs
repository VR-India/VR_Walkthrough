using BNG;
using UnityEngine;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    public TMPro.TMP_Text stepsText;
    public QuestButtonsHighlighter qt;
    public UnityEngine.UI.Button StartButton;

    [Space(20)]
    [Header("Balloon and COnfetti")]
    public GameObject leftBalloon;
    public GameObject leftConfetti,rightBalloon,rightConfetti;


    [Space(20)]
    [Header("UI Left Controller")]
    public Image leftThumbstick;
    public Image x,y,leftGrip,leftTrigger;

    [Space(20)]
    [Header("UI Right Controller")]
    public Image rightThumbstick;
    public Image a,b,rightGrip,rightTrigger;

    [Space(20)]
    [Header("Reference required for Game Flow")]
    public GameObject Table;
    public GameObject PlayerControllerPlayerRotation,backCanvas;
    void Start()
    {
        leftBalloon.SetActive(false);
        rightBalloon.SetActive(false);
        leftConfetti.SetActive(false);
        rightConfetti.SetActive(false);
    }
    void Update()
    {
        
        IndexSetter();
    }

    void BalloonAndConfetti()
    {
        if(BNG.InputBridge.Instance.AButtonDown)
        {
            rightBalloon.SetActive(true);
            rightBalloon.GetComponent<SkinnedMeshRenderer>().material.color = new Color(Random.Range(0,255),Random.Range(0,255),Random.Range(0,255));
            rightConfetti.SetActive(false);
        }
        if(BNG.InputBridge.Instance.XButtonDown)
        {
            leftBalloon.SetActive(true);
            leftBalloon.GetComponent<SkinnedMeshRenderer>().material.color = new Color(Random.Range(0,255),Random.Range(0,255),Random.Range(0,255));
            leftConfetti.SetActive(false);
        }
        if(BNG.InputBridge.Instance.BButtonDown)
        {
            rightBalloon.SetActive(false);
            rightConfetti.SetActive(true);
        }
        if(BNG.InputBridge.Instance.YButtonDown)
        {
            leftBalloon.SetActive(false);
            leftConfetti.SetActive(true);
        }
    }
    void IndexSetter()
    {
        switch(GameManager.instance.index)
        {
            case 0:
                ImageColourResetter();
                break;
            // For Button A and X
            case 1:
                ImageColourResetter();
                a.color = GameManager.instance.color;
                x.color = GameManager.instance.color;
                BalloonAndConfetti();
                if(BNG.InputBridge.Instance.AButtonDown || BNG.InputBridge.Instance.XButtonDown){GameManager.instance.index = 2;}
                break;
            // For Button B and Y
            case 2:
                ImageColourResetter();
                b.color = GameManager.instance.color;
                y.color = GameManager.instance.color;
                BalloonAndConfetti();
                if(BNG.InputBridge.Instance.BButtonDown || BNG.InputBridge.Instance.YButtonDown){GameManager.instance.index = 3;}
                break;
            // For Right Joystick
            case 3:
                ImageColourResetter();
                RotatePlayer();
                rightThumbstick.GetComponentInParent<Image>().color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.RightThumbstickAxis.magnitude != 0){GameManager.instance.index = 4;}
                break;
            // For Left Joystick
            case 4:
                ImageColourResetter();
                Table.SetActive(true);
                PlayerControllerPlayerRotation.GetComponent<LocomotionManager>().enabled = true;
                leftThumbstick.GetComponentInParent<Image>().color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.LeftThumbstickAxis.magnitude != 0){GameManager.instance.index = 5;}
                break;
            // Right Trigger
            case 5:
                ImageColourResetter();
                rightTrigger.color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.RightTrigger > 0){GameManager.instance.index = 6;}
                break;
            // Left Trigger
            case 6:
                ImageColourResetter();
                leftTrigger.color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.LeftTrigger > 0){GameManager.instance.index = 7;}
                break;
            // Right Grip
            case 7:
                ImageColourResetter();
                rightGrip.color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.RightGrip > 0){GameManager.instance.index = 8;}
                break;
            // Left Grip
            case 8:
                ImageColourResetter();
                leftGrip.color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.LeftGrip > 0){GameManager.instance.index = 0; StartButton.gameObject.SetActive(true);}
                break;
            default:
                print("Invalid Index Value");
                break;
        }
    }
    void ImageColourResetter()
    {
        a.color = Color.white;
        b.color = Color.white;
        x.color = Color.white;
        y.color = Color.white;
        leftTrigger.color = Color.white;
        leftGrip.color = Color.white;
        leftThumbstick.color = Color.white;
        rightTrigger.color = Color.white;
        rightGrip.color = Color.white;
        rightThumbstick.color = Color.white;
    }

    bool toRotate = true;
    void RotatePlayer()
    {
        if(toRotate)
            {
                backCanvas.SetActive(true);
                PlayerControllerPlayerRotation.GetComponent<PlayerRotation>().enabled = true;
                PlayerControllerPlayerRotation.transform.rotation = Quaternion.Euler(0,180,0);
                toRotate = false;
            }
        else
            return;
    }
}
