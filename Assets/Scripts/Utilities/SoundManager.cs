using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{


    [SerializeField] private AudioSource backGroundMusicSource;
    [SerializeField] private AudioSource fxSource;
    [SerializeField] private AudioData audioData;
    [SerializeField] private LevelActions levelActions;
    [SerializeField] private UserActions userActions;
    [SerializeField] private GamePlayActions gamePlayActions;

    private const string MusicPrefKey = "MusicState";
    private void OnEnable()
    {
        levelActions.onLevelGenerated += PlayBackgroundMusic;
        userActions.OnClick += OnUserTap;
        levelActions.onLevelClear += OnLevelClear;
    }
    private void OnDisable()
    {
        levelActions.onLevelGenerated -= PlayBackgroundMusic;
        userActions.OnClick -= OnUserTap;
        levelActions.onLevelClear -= OnLevelClear;
    }



    private void PlayBackgroundMusic()
    {
        Invoke("StartBackgroundMusic", 1);

    }
    private void StartBackgroundMusic()
    {
        if (backGroundMusicSource != null && audioData.backgroundMusic != null)
        {
            backGroundMusicSource.clip = audioData.backgroundMusic;
            backGroundMusicSource.loop = true;
            LoadMusicState();
        }
    }
    private void OnLevelClear()
    {
        PlayFX(audioData.winnerFx);

        PauseAudio();
    }
    private void OnUserTap(GameElement gameElement)
    {
        PlayFX(audioData.tapFx);
    }

    private void PlayFX(AudioClip clip)
    {
        if (fxSource != null && clip != null)
        {
            fxSource.PlayOneShot(clip);
        }
    }
    private void PauseAudio()
    {
        backGroundMusicSource.Pause();
    }

    public void MusicToggle()
    {
        bool isMusicOn = backGroundMusicSource.isPlaying;
        SetMusicState(!isMusicOn);  // Toggle the current state
        SaveMusicState();
    }

    private void SaveMusicState()
    {
        PlayerPrefs.SetInt(MusicPrefKey, backGroundMusicSource.mute ? 0 : 1);
        PlayerPrefs.Save();
    }

    private void LoadMusicState()
    {
        bool isMusicOn = PlayerPrefs.GetInt(MusicPrefKey, 1) == 1; // Default to music on if key doesn't exist
        SetMusicState(isMusicOn);
    }

    private void SetMusicState(bool isMusicOn)
    {
        backGroundMusicSource.mute = !isMusicOn;
        fxSource.mute = !isMusicOn;

        if (isMusicOn)
        {
            backGroundMusicSource.Play();
        }
        else
        {
            backGroundMusicSource.Pause();
        }
    }
}
