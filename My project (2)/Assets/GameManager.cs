using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject winCanvas;

    public PIpescript[] Pipes;
    bool gameFinished = false;
    bool hasWon = false;
    void Start()
    {
        int totalPipes = PipesHolder.transform.childCount;
        Pipes = new PIpescript[totalPipes];

        for (int i = 0; i < totalPipes; i++)
        {
            Pipes[i] = PipesHolder
                .transform
                .GetChild(i)
                .GetComponent<PIpescript>();
        }
    }

    void Update()
    {
        if (!gameFinished)
            CheckWin();
    }

    void CheckWin()
    {
        if (hasWon) return;

        for (int i = 0; i < Pipes.Length; i++)
        {
            if (!Pipes[i].IsPlaced)
                return;
        }

        hasWon = true;
        winCanvas.SetActive(true);
    }

    public void RestartPuzzle()
    {
        hasWon = false;
        winCanvas.SetActive(false);

        for (int i = 0; i < Pipes.Length; i++)
        {
            float newRot;

            do
            {
                newRot = Random.Range(0, 4) * 90f;
            }
            while (Pipes[i].IsCorrectRotation(newRot));

            Pipes[i].ResetPipe(newRot);
        }
    }
}
