using UnityEngine;

public class PIpescript : MonoBehaviour
{
    float[] rotations = { 0f, 90f, 180f, 270f };

    public float[] correctRotations;

    [SerializeField] bool isPlaced;
    public bool IsPlaced => isPlaced;

    void Start()
    {
        float startRotation;

        // garante que o pipe NÃO começa resolvido
        do
        {
            startRotation = rotations[Random.Range(0, rotations.Length)];
        }
        while (IsCorrectRotation(startRotation));

        transform.eulerAngles = new Vector3(0, 0, startRotation);
        CheckPlacement();
    }

    void OnMouseDown()
    {
        transform.Rotate(0, 0, 90f);
        CheckPlacement();
    }

    void CheckPlacement()
    {
        float z = transform.eulerAngles.z;

        // normaliza
        z = Mathf.Round(z / 90f) * 90f;
        z %= 360;

        isPlaced = false;

        for (int i = 0; i < correctRotations.Length; i++)
        {
            if (Mathf.Abs(z - correctRotations[i]) < 0.1f)
            {
                isPlaced = true;
                break;
            }
        }
    }

    public bool IsCorrectRotation(float rot)
    {
        for (int i = 0; i < correctRotations.Length; i++)
        {
            if (Mathf.Abs(rot - correctRotations[i]) < 0.1f)
                return true;
        }
        return false;
    }


    public float GetRotation()
    {
        return transform.eulerAngles.z;
    }

    public void SetRandomRotationDifferentFrom(float oldRotation)
    {
        float newRot;

        do
        {
            newRot = rotations[Random.Range(0, rotations.Length)];
        }
        while (Mathf.Abs(newRot - oldRotation) < 0.1f);

        transform.eulerAngles = new Vector3(0, 0, newRot);
        CheckPlacement();
    }

    public void ResetPipe(float newRotation)
    {
        isPlaced = false;
        transform.eulerAngles = new Vector3(0, 0, newRotation);
        CheckPlacement();
    }
}
