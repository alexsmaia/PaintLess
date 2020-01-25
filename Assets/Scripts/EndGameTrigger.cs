using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{

    public GameManager gameManager;

    private void OnTriggerEnter()
    {
        gameManager.EndLevel();
    }
}
