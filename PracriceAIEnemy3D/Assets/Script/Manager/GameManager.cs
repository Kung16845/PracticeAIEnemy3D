using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("Manager Script")]
    public StateMachineManager stateMachineManager;
    [Header("Player")]
    [SerializeField] Player player;
    public Player Player => player;
    [Header("Header")]
    [SerializeField] Enemy enemy;
    public Enemy Enemy => enemy;
    [SerializeField] GameObject areaEnemy;
    public GameObject AreaEnemy => areaEnemy;
    private void Awake()
    {
        // กำหนด Instance ให้เป็นอ็อบเจกต์นี้
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
