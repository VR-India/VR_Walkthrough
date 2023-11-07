using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    int i = 0;
    public ChibiDialogueAudio chibiDialogueAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if(i == 0 && collision.collider.tag == "PokeBall")
        {
            SoundManager.instance.PlayClipOneShot(chibiDialogueAudio.roboAudiosScribtableObject.GetClip("welldone"));
            RoboKyle.Instance.AnimateRobo("happy");
            i = 1;
        }
    }
}
