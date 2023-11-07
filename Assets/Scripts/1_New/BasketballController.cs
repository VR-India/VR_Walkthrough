using UnityEngine;

public class BasketballController : MonoBehaviour
{
    public ParticleSystem confetti;
    TMPro.TextMeshPro scoreText;
    public ChibiDialogueAudio chibiDialogueAudio;
    int score;
    bool x = true;
    void Start()
    {
        scoreText = GetComponentInChildren<TMPro.TextMeshPro>();
    }
    void OnTriggerExit(Collider col)
    {
        if(col.name == "Ball")
        {
            confetti.Play();
            score++;
            scoreText.text = "Score : " + score.ToString();
            if(x == true)
            {
                int temp = chibiDialogueAudio.dialogueIndex;
                chibiDialogueAudio.dialogueIndex = 11;
                chibiDialogueAudio.toPlay = true;
                x = false;
                //chibiDialogueAudio.dialogueIndex = temp;
            }
        }
    }
}
