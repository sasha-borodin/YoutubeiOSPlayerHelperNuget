using System;
using ObjCRuntime;

namespace YouTubeiOSPlayerHelper
{

	public enum YTPlayerState : int
	{
		Unstarted,
		Ended,
		Playing,
		Paused,
		Buffering,
		Cued,
		Unknown
	}

	public enum YTPlaybackQuality : int
	{
		Small,
		Medium,
		Large,
		Hd720,
		Hd1080,
		HighRes,
		Auto,
		Default,
		Unknown
	}

	public enum YTPlayerError : int
	{
		InvalidParam,
		HTML5Error,
		VideoNotFound,
		NotEmbeddable,
		Unknown
	}
}

