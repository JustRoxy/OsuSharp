using OsuSharp.Interfaces;

namespace OsuSharp.Domain;

public sealed class BeatmapsetUpdateEvent : Event, IBeatmapsetUpdateEvent
{
    public IEventBeatmapsetModel Beatmapset { get; internal set; } = null!;

    public IEventUserModel User { get; internal set; } = null!;

    internal BeatmapsetUpdateEvent()
    {
            
    }
}