using TMPro;
using UnityEngine;

public class StatsCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _livesCounter;

    [SerializeField]
    private TextMeshProUGUI _scoreCounter;

    [SerializeField]
    private LowerTrigger _lowerTrigger;
    
    [SerializeField]
    private int _lives;
    
    // Start is called before the first frame update
    void Start()
    {
        _livesCounter.text += _lives;
        _lowerTrigger.OnTriggerActive.AddListener(DecreaseLivesCounter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecreaseLivesCounter()
    {
        _livesCounter.text = _livesCounter.text.Replace(_lives.ToString(), "");
        _lives--;
        _livesCounter.text += _lives.ToString();
    }
}
