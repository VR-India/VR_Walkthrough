using UnityEngine;

public class BalloonAndConfetti : MonoBehaviour
{
    public GameObject balloon,confetti;

    
    public void BalloonAndConfettiAction()
    {
        if(BNG.InputBridge.Instance.AButtonDown || BNG.InputBridge.Instance.XButtonDown)
        {
            balloon.SetActive(true);
            //balloon.GetComponent<SkinnedMeshRenderer>().material.color = new Color(Random.Range(0,255),Random.Range(0,255),Random.Range(0,255));
            balloon.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
            confetti.SetActive(false);
            Debug.Log("Calling Balloon");
        }
        if(BNG.InputBridge.Instance.BButtonDown || BNG.InputBridge.Instance.YButtonDown)
        {
            balloon.SetActive(false);
            confetti.SetActive(true);
            Debug.Log("Calling Confetti");
        }
    }
}
