using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{

    private void OnTriggerEnter()
    {
        GameManager.instance.EndLevel();
        Debug.Log("end Game trigger");
    }
}
