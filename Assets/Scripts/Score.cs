using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private SaveData saveData;

    public float CurrentScore { get; private set; }
    public float TheBestScore {  get; private set; }
    public bool IsPlaying { get; private set; }

    private void Awake()
    {
        CurrentScore = 0;
        LoadTheBestScore();
        TheBestScore = saveData.highestScore;
        IsPlaying = false;
    }

    private void Update()
    {
        if (IsPlaying)
            CurrentScore += Time.deltaTime;
    }

    public void SetStarter()
    {
        CurrentScore = 0;
        IsPlaying = true;
    }
    
    public void SetTheBest()
    {
        if (saveData.highestScore < CurrentScore)
        {
            saveData.highestScore = CurrentScore;
            TheBestScore = CurrentScore;
            string saveString = JsonUtility.ToJson(saveData);
            SaveSystem.Save("save", saveString);
        }

        IsPlaying = false;
    }

    private void LoadTheBestScore()
    {
        string loadedData = SaveSystem.Load("save");

        if (loadedData != null)
        {
            saveData = JsonUtility.FromJson<SaveData>(loadedData);
        }
        else
        {
            saveData = new SaveData();
        }
    }
}
