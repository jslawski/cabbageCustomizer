using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// When playing a new sound using the AudioManager, you must first create a new AudioChannelSettings and specify
/// how you would like your sound to be played.  These settings, as well as the desired AudioClip, should then be
/// passed to the AudioManager for playing.
/// </summary>
public class AudioChannelSettings
{
    public bool loop = false;
    public float minPitch = 1f;
    public float maxPitch = 1f;
    public float volume = 1f;
    public string mixerName = "";

    public Transform sourceTransform;

    public AudioChannelSettings(bool loop = false, float minPitch = 1.0f, float maxPitch = 1.0f, float volume = 1.0f, string mixerName = "", Transform sourceTransform = null)
    {
        this.loop = loop;
        this.minPitch = minPitch;
        this.maxPitch = maxPitch;
        this.volume = volume;
        this.mixerName = mixerName;
        this.sourceTransform = sourceTransform;
    }
}

/// <summary>
/// An AudioChannel is a GameObject that is responsible for playing a designated AudioSource.
/// Instances of this GameObject are created and managed automatically by the AudioManager.
/// </summary>
public class AudioChannel : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    private AudioChannelSettings channelSettings;

    private AudioSource source;

    public int channelId;

    public void Setup(AudioClip clip, AudioChannelSettings settings)
    {
        this.source = GetComponent<AudioSource>();

        this.source.clip = clip;
        this.source.outputAudioMixerGroup = this.mixer.FindMatchingGroups(settings.mixerName)[0];
        this.channelSettings = settings;

        if (this.channelSettings.sourceTransform == null)
        {
            this.channelSettings.sourceTransform = this.transform;
        }

        this.channelId = AudioManager.instance.GetNewChannelId();

        if (this.channelSettings.sourceTransform == this.transform)
        {
            this.gameObject.name = this.channelId.ToString() + "_" + clip.name + "_NoSource";
        }
        else
        {
            this.gameObject.name = this.channelId.ToString() + "_" + clip.name + "_" + settings.sourceTransform.gameObject.name;
        }
        
    }

    public void Play()
    {
        StartCoroutine(this.PlayCoroutine()); 
    }

    private IEnumerator PlayCoroutine()
    {        
        this.source.pitch = Random.Range(this.channelSettings.minPitch, this.channelSettings.maxPitch);
        this.source.volume = this.channelSettings.volume;
        this.source.loop = this.channelSettings.loop;
        this.transform.position = this.channelSettings.sourceTransform.position;

        this.source.Play();        

        while (this.source.isPlaying == true)
        {
            yield return null;

            if (this.channelSettings.sourceTransform != null)
            {
                this.transform.position = this.channelSettings.sourceTransform.position;
            }
        }

        this.Stop();
    }

    public void PlaySlideUp(float durationInSeconds)
    {
        this.source.loop = true;
        StartCoroutine(this.PlaySlideCoroutine(this.channelSettings.minPitch, this.channelSettings.maxPitch, durationInSeconds));
    }

    public void PlaySlideDown(float durationInSeconds)
    {
        this.source.loop = true;
        StartCoroutine(this.PlaySlideCoroutine(this.channelSettings.maxPitch, this.channelSettings.minPitch, durationInSeconds));
    }

    private IEnumerator PlaySlideCoroutine(float startPitch, float endPitch, float duration)
    {
        float pitchIncrementPerFrame = ((endPitch - startPitch) / duration) * Time.fixedDeltaTime;

        this.source.pitch = startPitch;
        this.transform.position = this.channelSettings.sourceTransform.position;

        this.source.Play();

        for (float i = 0; i < duration; i += Time.fixedDeltaTime)
        {
            yield return new WaitForFixedUpdate();

            if (this.channelSettings.sourceTransform != null)
            {
                this.transform.position = this.channelSettings.sourceTransform.position;
            }

            this.source.pitch += pitchIncrementPerFrame;
        }

        this.Stop();
    }

    public void PlayPingPong(float period)
    {
        this.source.loop = true;
        StartCoroutine(this.PlayPingPongCoroutine(period));
    }

    private IEnumerator PlayPingPongCoroutine(float period)
    {
        float pitchIncrementPerFrame = ((this.channelSettings.maxPitch - this.channelSettings.minPitch) / period) * Time.fixedDeltaTime;
        float pitchDirection = 1;

        this.source.pitch = this.channelSettings.minPitch;
        this.transform.position = this.channelSettings.sourceTransform.position;

        this.source.Play();

        while (this.source.isPlaying == true)
        {
            yield return new WaitForFixedUpdate();

            if (this.channelSettings.sourceTransform != null)
            {
                this.transform.position = this.channelSettings.sourceTransform.position;
            }

            this.source.pitch += (pitchIncrementPerFrame * pitchDirection);

            if (this.source.pitch >= this.channelSettings.maxPitch)
            {
                pitchDirection = -1;
            }
            else if (this.source.pitch <= this.channelSettings.minPitch)
            {
                pitchDirection = 1;
            }
        }

        this.Stop();
    }

    public void PlayPeriodically(float period)
    {
        StartCoroutine(this.PlayPeriodicallyCoroutine(period));
    }

    private IEnumerator PlayPeriodicallyCoroutine(float period)
    {        
        this.source.pitch = Random.Range(this.channelSettings.minPitch, this.channelSettings.maxPitch);
        this.transform.position = this.channelSettings.sourceTransform.position;

        this.source.Play();

        while (true)
        {
            yield return new WaitForSeconds(period);

            this.source.pitch = Random.Range(this.channelSettings.minPitch, this.channelSettings.maxPitch);

            if (this.channelSettings.sourceTransform != null)
            {
                this.transform.position = this.channelSettings.sourceTransform.position;
            }

            this.source.Play();
        }        
    }

    public void Stop()
    {
        StopAllCoroutines();
        this.source.Stop();
        this.ReleaseChannel();
    }

    private void ReleaseChannel()
    {
        AudioManager.instance.ReleaseChannel(this);
        this.gameObject.name = "Unused";
    }
}
