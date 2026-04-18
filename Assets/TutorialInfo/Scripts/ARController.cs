using UnityEngine;
using Vuforia;
using TMPro; // Nécessite l'import de TextMeshPro

public class ARController : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;
    public TextMeshProUGUI textAffichage; // Glisse ici un texte d'UI
    public GameObject objetAR; // L'objet 3D à animer

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnStatusChanged;
        }
        objetAR.SetActive(false);
    }

    private void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
    }

    private void OnTrackingFound()
    {
        objetAR.SetActive(true);
        DemanderIA();
    }

    void DemanderIA()
    {
        // Simulation d'un appel API (ex: OpenAI ou Google Vision)
        textAffichage.text = "IA : Analyse de l'image en cours...";

        // Simulation de délai de réponse
        Invoke("AfficherResultatIA", 2.0f);
    }

    void AfficherResultatIA()
    {
        textAffichage.text = "IA : J'ai reconnu un [Nom de l'objet]. C'est un outil utilisé pour [Description].";
    }
}