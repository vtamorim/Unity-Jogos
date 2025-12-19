using System.Collections;
using TMPro;
using UnityEngine;

public class TMPwriter : MonoBehaviour
{
    [Header("Referência")]
    [SerializeField] private TMP_Text textTMP;

    [Header("Configurações")]
    [SerializeField] private float delayEntreLetras = 2f;
    [SerializeField] private float delayEntreFalas = 1.5f;

    [Header("Falas")]
    [TextArea(2, 5)]
    [SerializeField] private string[] falas;

    private int indiceAtual = 0;
    private Coroutine rotina;

    void Awake()
    {
        if (textTMP == null)
            textTMP = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        indiceAtual = 0;
        IniciarFala();
    }

    void IniciarFala()
    {
        if (rotina != null)
            StopCoroutine(rotina);

        textTMP.text = falas[indiceAtual];
        rotina = StartCoroutine(Escrever());
    }

    IEnumerator Escrever()
    {
        textTMP.maxVisibleCharacters = 0;
        textTMP.ForceMeshUpdate();

        int total = textTMP.textInfo.characterCount;

        for (int i = 0; i <= total; i++)
        {
            textTMP.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delayEntreLetras);
        }

        yield return new WaitForSeconds(delayEntreFalas);
        ProximaFala();
    }

    void ProximaFala()
    {
        indiceAtual++;

        if (indiceAtual >= falas.Length)
        {
            // acabou o diálogo
            return;
        }

        IniciarFala();
    }

    public void MostrarTudo()
    {
        if (rotina != null)
            StopCoroutine(rotina);

        textTMP.maxVisibleCharacters = textTMP.textInfo.characterCount;
    }
}
