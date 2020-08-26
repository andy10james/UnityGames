using UnityEngine;

public static class PlayerPrefsManager {


    private const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float DEFAULT_MASTER_VOLUME = 0.5f;
    const int DEFAULT_DIFFICULTY = 1;

    public static float GetDefaultMasterVolume () {
        return DEFAULT_MASTER_VOLUME;
    }

    public static void SetMasterVolume (float volume) {
        volume = volume < 0 ? 0 : volume > 1 ? 1 : volume;
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
    }

    public static float GetMasterVolume () {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static int GetDefaultDifficulty () {
        return DEFAULT_DIFFICULTY;
    }

    public static void SetDifficulty (int difficulty) {
        difficulty = difficulty < 0 ? 0 : difficulty > 3 ? 3 : difficulty;
        PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
    }

    public static int GetDifficulty() {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }



}
