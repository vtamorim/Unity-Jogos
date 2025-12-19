using UnityEngine;

public class PassardeFase : MonoBehaviour
{
    [SerializeField] private GameObject mostrarfimdejogo;
    private bool ativado = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (ativado) return;

        if (other.CompareTag("Player"))
        {
            ativado = true;
            mostrarfimdejogo.SetActive(true);
        }
    }
}
