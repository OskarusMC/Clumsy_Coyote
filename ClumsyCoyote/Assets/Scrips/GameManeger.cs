using UnityEngine;

public class GameManeger : MonoBehaviour
{

    public static GameManeger Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
