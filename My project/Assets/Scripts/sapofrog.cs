using System.Collections;
using UnityEngine;
public class sapofrog : MonoBehaviour

{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject balao;
    private bool ativado = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (ativado) return;

        if (other.CompareTag("Player"))
        {
            ativado = true;
            dialogueUI.SetActive(true);
            StartCoroutine(MostrarDialogoComAtraso());
        }
    }

    IEnumerator MostrarDialogoComAtraso()
    {
        yield return new WaitForSeconds(0.3f);
        balao.SetActive(true);
    }
}
