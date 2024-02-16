using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - Play AudioClips without having to manually add AudioSource components to various GameObjects in your scene.
/// - Play multiple AudioClips concurrently without having them cut each other off.
/// - Play an AudioClip without it getting cut off when the triggering GameObject is destroyed
/// - Apply simple effects to AudioClips such as pitch modulation and looping, periodic play
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private GameObject audioChannelPrefab;

    private List<AudioChannel> playingAudioChannels;

    public int audioChannelCacheSize = 50;
    private Stack<AudioChannel> audioChannelCache;

    private int channelIdCounter = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            this.CreateAudioChannelCache();
        }
    }

    private void CreateAudioChannelCache()
    {
        this.audioChannelCache = new Stack<AudioChannel>();
        this.playingAudioChannels = new List<AudioChannel>();

        for (int i = 0; i < this.audioChannelCacheSize; i++)
        {
            GameObject newAudioChannel = Instantiate(this.audioChannelPrefab, this.transform);
            this.audioChannelCache.Push(newAudioChannel.GetComponent<AudioChannel>());
            newAudioChannel.name = "Unused";
        }
    }

    private AudioChannel GetAudioChannel(AudioClip clip, AudioChannelSettings channelSettings)
    {
        if (this.audioChannelCache.Count < 1)
        {
            Debug.LogError("No Audio Channels available. Audio Channel not assigned.");
            return null;
        }
        
        AudioChannel newChannel = this.audioChannelCache.Pop();        
        newChannel.Setup(clip, channelSettings);        
        return newChannel;
    }

    /// <summary>
    /// Play an AudioClip using the specified AudioChannelSettings
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="channelSettings"></param>
    /// <returns></returns>
    public int Play(AudioClip clip, AudioChannelSettings channelSettings)
    {
        AudioChannel newAudioChannel = this.GetAudioChannel(clip, channelSettings);
        newAudioChannel.Play();
        this.playingAudioChannels.Add(newAudioChannel);
        return newAudioChannel.channelId;
    }

    /// <summary>
    /// Play an AudioClip using the specified AudioChannelSettings that slowly increases its pitch
    /// over the span of a duration
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="channelSettings"></param>
    /// <param name="durationInSeconds"></param>
    /// <returns></returns>
    public int PlaySlideUp(AudioClip clip, AudioChannelSettings channelSettings, float durationInSeconds)
    {
        AudioChannel newAudioChannel = this.GetAudioChannel(clip, channelSettings);
        newAudioChannel.PlaySlideUp(durationInSeconds);
        this.playingAudioChannels.Add(newAudioChannel);
        return newAudioChannel.channelId;
    }
    /// <summary>
    /// Play an AudioClip using the specified AudioChannelSettings that slowly increases its pitch
    /// over the span of a duration
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="channelSettings"></param>
    /// <param name="durationInSeconds"></param>
    /// <returns></returns>
    public int PlaySlideDown(AudioClip clip, AudioChannelSettings channelSettings, float durationInSeconds)
    {
        AudioChannel newAudioChannel = this.GetAudioChannel(clip, channelSettings);
        newAudioChannel.PlaySlideDown(durationInSeconds);
        this.playingAudioChannels.Add(newAudioChannel);
        return newAudioChannel.channelId;
    }

    /// <summary>
    /// Play an AudioClip using the specified AudioChannelSettings that modulates between a high and low pitch
    /// over a specified period
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="channelSettings"></param>
    /// <param name="periodInSeconds"></param>
    /// <returns></returns>
    public int PlayPingPong(AudioClip clip, AudioChannelSettings channelSettings, float periodInSeconds)
    {
        AudioChannel newAudioChannel = this.GetAudioChannel(clip, channelSettings);
        newAudioChannel.PlayPingPong(periodInSeconds);
        this.playingAudioChannels.Add(newAudioChannel);
        return newAudioChannel.channelId;
    }

    /// <summary>
    /// Play an AudioClip using the specified AudioChannelSettings that plays periodically at a specified interval
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="channelSettings"></param>
    /// <param name="periodInSeconds"></param>
    /// <returns></returns>
    public int PlayPeriodically(AudioClip clip, AudioChannelSettings channelSettings, float periodInSeconds)
    {
        AudioChannel newAudioChannel = this.GetAudioChannel(clip, channelSettings);
        newAudioChannel.PlayPeriodically(periodInSeconds);
        this.playingAudioChannels.Add(newAudioChannel);
        return newAudioChannel.channelId;
    }

    /// <summary>
    /// Stop playing an AudioClip
    /// </summary>
    /// <param name="channelId"></param>
    public void Stop(int channelId)
    {
        this.playingAudioChannels.Find(x => x.channelId == channelId).Stop();
    }

    /// <summary>
    /// Get a new unique channel ID for an AudioChannel
    /// </summary>
    /// <returns></returns>
    public int GetNewChannelId()
    {
        this.channelIdCounter++;
        return channelIdCounter;
    }

    /// <summary>
    /// Remove an AudioChannel from the list of currently playing channels and
    /// add it back to the audioChannelCache for future use
    /// </summary>
    /// <param name="releasedChannel"></param>
    public void ReleaseChannel(AudioChannel releasedChannel)
    {
        this.playingAudioChannels.Remove(releasedChannel);
        this.audioChannelCache.Push(releasedChannel);

        releasedChannel.transform.position = this.transform.position;
    }
}
