using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollection : MonoBehaviour
{
    private int _score;
    public TMP_Text scoreText;
    public TMP_Text hiveText;
    private Collider2D _touching;
    [SerializeField] private int lastAddFrame = -1;
    public ParticleSystem beeParticles;
    public BeePopUp beePopup;


    private void Awake()
    {
        // Optional safety so you don’t get NREs if you forget to assign
        if (!beePopup) beePopup = FindFirstObjectByType<BeePopUp>();
        if (!scoreText) scoreText = FindFirstObjectByType<TMP_Text>();
        if (!beeParticles) beeParticles = FindFirstObjectByType<ParticleSystem>();
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            _touching = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == _touching)
        {
            _touching = null;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (_touching != null)
        {
            AddScore(1);
                _touching = null;
        }
    }
    
    

    private void AddScore(int points)
    {
        // Debounce: if somehow called twice in same frame, ignore the second
        if (Time.frameCount == lastAddFrame) return;
        lastAddFrame = Time.frameCount;

        int prev = _score;
        _score += points;

        // Detect crossing multiples of 10 (handles 9->11, 18->22, etc.)
        int prevTier = prev / 10;
        int newTier  = _score / 10;

        if (newTier > prevTier)
        {
            int crossed = newTier - prevTier;

            if (beeParticles) beeParticles.Emit(crossed);

            if (beePopup)
            {
                // show one popup for every crossed multiple (10, 20, …)
                for (int k = prevTier + 1; k <= newTier; k++)
                    beePopup.ShowAchievement($"A  BEE  HAS  BEEN  ADDED  TO  THE  HIVE!");
            }
            else
            {
                Debug.LogWarning("BeePopUp reference not assigned on PlayerCollection.");
            }
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText) scoreText.text = $"<b>POLLEN :</b> {_score}";
        if (hiveText)  hiveText.text  = ""; // set whatever you need here
    }
}






