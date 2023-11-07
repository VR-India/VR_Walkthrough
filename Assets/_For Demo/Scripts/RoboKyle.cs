using UnityEngine;
public class RoboKyle : MonoBehaviour
{
    public static RoboKyle Instance;
    private void Awake() { Instance = this; }
    public Texture2D[] emojis;
    public Material faceMaterial;
    public Animator animator;
    public Sounds roboVoiceOvers;
    public void AnimateRobo(string animName) { animator.Play(animName); }
    public void SetEmoji(Texture2D emoji) { faceMaterial.SetTexture("_BaseMap", emoji); }
    public enum RoboState { idle, happy, talk }
    //public RoboState roboState;

    //private void Update()
    //{
    //    switch (roboState)
    //    {
    //        case RoboState.idle:
    //            AnimateRobo("idle");
    //            //SetEmoji(emojis[0]);
    //            break;
    //        case RoboState.happy:
    //            AnimateRobo("happy");
    //            //SetEmoji(emojis[1]);
    //            break;
    //        case RoboState.talk:
    //            AnimateRobo("talk");
    //            //SetEmoji(emojis[2]);
    //            break;
    //    }
    //}
}