using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    [SerializeField] private Text dialogueText;
    [SerializeField] private List<string> dialogues;
    [SerializeField] private List<float> timers;

    private int index = -1;

    private Coroutine coroutine;

    public void ShowNextDialogue() {
        coroutine = StartCoroutine(ChangeText());
    }

    public void HideDialogue() {
        dialogueText.text = "";
    }

    private IEnumerator ChangeText() {
        index++;
        dialogueText.text = dialogues[index];

        yield return new WaitForSeconds(timers[index]);

        dialogueText.text = "";
    }

}
