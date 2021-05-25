using UnityEngine;

static class AudioHelper
{
    public static void PlayRandomSoundAtCamera(AudioClip[] clips)
    {
        PlayRandomSound(clips, Camera.main.transform.position, 1f);
    }

    public static void PlayRandomSoundAtCamera(AudioClip[] clips, float volume)
    {
        PlayRandomSound(clips, Camera.main.transform.position, volume);
    }

    public static void PlayRandomSound(AudioClip[] clips, Vector3 position, float volume)
    {
        if (clips.Length == 0 || clips == null)
            return;

        // Camera.current is sometimes null
        // https://answers.unity.com/questions/173525/when-is-current-camera-null.html
        // https://docs.unity3d.com/ScriptReference/Camera-current.html
        AudioSource.PlayClipAtPoint(
            clips[UnityEngine.Random.Range(0, clips.Length)],
            position,
            volume
        );
    }
}
