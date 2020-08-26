using UnityEngine;

public static class AudioClipHelper {

    public static void PlayClipAt(AudioClip clip, Vector3 pos, float volume = 1.0f) {
        var tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        var aSource = tempGO.AddComponent<AudioSource>();
        aSource.clip = clip;
        aSource.volume = volume;
        aSource.Play();
        Object.Destroy(tempGO, clip.length);
    }

}
