using BNG;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlowManagerNew : MonoBehaviour
{
    public TMPro.TMP_Text stepsText;
    public QuestButtonsHighlighter qt;

    [Space(20)]
    [Header("Balloon and Confetti")]
    public BalloonAndConfetti bc;

    #region Controllers UI Button References

    [Space(20)]
    [Header("Controllers UI Button Highlighter References", order = 0)]
    [Header("UI Left Controller", order = 1)]
    public Image leftThumbstick;
    public Image x,y,leftGrip,leftTrigger;

    [Space(20)]
    [Header("UI Right Controller",order = 1)]
    public Image rightThumbstick;
    public Image a,b,rightGrip,rightTrigger;

    #endregion

    public PlayerRotation pr;
    public LocomotionManager lm;
    public GameObject Tablee;
    public DissolveObjects db;
    public RectTransform questCanvas;

    public GameObject bngButton;

    [Space(20)]
    public GameObject playerControllersLeft;
    public GameObject playerControllersRight;
    public GameObject questCanvasUi;

    [Space(20)]
    public ChibiDialogueAudio cb;
    public Animator roboParent;
    public BNG.Grabber leftHandGrabber, rightHandGrabber;

    void Start()
    {
        bc.balloon.SetActive(false);
        bc.confetti.SetActive(false);

        playerControllersLeft.SetActive(false);
        playerControllersRight.SetActive(false);
        questCanvasUi.SetActive(false);

        StartCoroutine(DisplayRoboAfterDelay());
    }
    void Update()
    {
        IndexSetter();
    }
    void IndexSetter()
    {
        switch(GameManager.instance.index)
        {
            case 0:
                ImageColourResetter();
                //playerControllersLeft.SetActive(false);
                //playerControllersRight.SetActive(false);
                //questCanvasUi.SetActive(false);
                break;
            // For Button A and X
            case 1:
                playerControllersLeft.SetActive(true);
                playerControllersRight.SetActive(true);
                questCanvasUi.SetActive(true);
                ImageColourResetter();
                a.color = GameManager.instance.color;
                x.color = GameManager.instance.color;
                bc.BalloonAndConfettiAction();
                if(BNG.InputBridge.Instance.AButtonDown || BNG.InputBridge.Instance.XButtonDown)
                {
                    GameManager.instance.index = 2;
                    cb.dialogueIndex = 6;
                    cb.toPlay = true;
                }
                break;
            // For Button B and Y
            case 2:
                ImageColourResetter();
                b.color = GameManager.instance.color;
                y.color = GameManager.instance.color;
                bc.BalloonAndConfettiAction();
                if(BNG.InputBridge.Instance.BButtonDown || BNG.InputBridge.Instance.YButtonDown)
                {
                    GameManager.instance.index = 3;
                    cb.dialogueIndex = 7;
                    cb.toPlay = true;
                }
                break;
            // For Right Joystick
            case 3:
                ImageColourResetter();
                rightThumbstick.GetComponentInParent<Image>().color = GameManager.instance.color;
                pr.enabled = true;


                if(BNG.InputBridge.Instance.RightThumbstickAxis.magnitude != 0)
                {
                    GameManager.instance.index = 4;
                    cb.dialogueIndex = 8;
                    cb.toPlay = true;
                    
                    pr.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                    questCanvas.localPosition = new Vector3(0f,1.7f,3.5f);
                    questCanvas.rotation = Quaternion.Euler(0,0,0);
                    roboParent.Play("Move");
                }
                break;
            // For Left Joystick
            case 4:
                ImageColourResetter();
                leftThumbstick.GetComponentInParent<Image>().color = GameManager.instance.color;
                lm.enabled = true;
                Tablee.SetActive(true);
                db.isActive = true;
                if(BNG.InputBridge.Instance.LeftThumbstickAxis.magnitude != 0)
                {
                    GameManager.instance.index = 5;
                    cb.dialogueIndex = 9;
                    cb.toPlay = true;
                }
                break;
            // Right Trigger
            case 5:
                ImageColourResetter();
                rightTrigger.color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.RightTrigger > 0)
                {
                    GameManager.instance.index = 7;
                    cb.dialogueIndex = 10;
                    cb.toPlay = true;
                }
                break;
            // Left Trigger
            case 6:
                ImageColourResetter();
                leftTrigger.color = GameManager.instance.color;
                if(BNG.InputBridge.Instance.LeftTrigger > 0)
                {
                    GameManager.instance.index = 7; //Skip to 7
                    cb.dialogueIndex++;
                    cb.toPlay = true;
                }
                break;
            // Right Grip
            case 7:
                ImageColourResetter();
                rightGrip.color = GameManager.instance.color;



                if((BNG.InputBridge.Instance.RightGrip > 0 || BNG.InputBridge.Instance.LeftTrigger > 0)
                    && (leftHandGrabber.HeldGrabbable != null || rightHandGrabber.HeldGrabbable != null))
                {
                    GameManager.instance.index = 10;

                    handModal.enabled = true;
                    leftGrip.color = GameManager.instance.color;
                    leftHandController_Player.SetActive(false);
                    rightHandController_Player.SetActive(false);
                    //cb.dialogueIndex = 10;
                    //cb.toPlay = true;
                }

                break;
            // Left Grip
            case 8:
                ImageColourResetter();
                handModal.enabled = true;
                leftGrip.color = GameManager.instance.color;
                leftHandController_Player.SetActive(false);
                rightHandController_Player.SetActive(false);
                if(BNG.InputBridge.Instance.LeftGrip > 0)
                {
                    GameManager.instance.index = 0;
                    cb.dialogueIndex++;
                    cb.toPlay = true;
                    bngButton.SetActive(true);
                }
                break;
            default:
                print("Invalid Index Value");
                break;
        }
    }
    public HandModelSelector handModal;
    public GameObject leftHandController_Player,rightHandController_Player;
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

    IEnumerator DisplayRoboAfterDelay()
    {
        yield return new WaitForSeconds(2);
        cb.gameObject.SetActive(true);
    }

}