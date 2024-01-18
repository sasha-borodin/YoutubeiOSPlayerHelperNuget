using Foundation;
using ObjCRuntime;
using UIKit;
using WebKit;

namespace YouTubeiOSPlayerHelper
{

	[Static]
	partial interface Constants
	{
		// extern double youtube_ios_player_helperVersionNumber;
		[Field("youtube_ios_player_helperVersionNumber", "__Internal")]
		double youtube_ios_player_helperVersionNumber { get; }

		// extern const unsigned char [] youtube_ios_player_helperVersionString;
		[Field("youtube_ios_player_helperVersionString", "__Internal")]
		NSString youtube_ios_player_helperVersionString { get; }
	}

	// typedef void (^YTIntCompletionHandler)(int, NSError * _Nullable);
	delegate void YTIntCompletionHandler(int arg0, [NullAllowed] NSError arg1);

	// typedef void (^YTFloatCompletionHandler)(float, NSError * _Nullable);
	delegate void YTFloatCompletionHandler(float arg0, [NullAllowed] NSError arg1);

	// typedef void (^YTDoubleCompletionHandler)(double, NSError * _Nullable);
	delegate void YTDoubleCompletionHandler(double arg0, [NullAllowed] NSError arg1);

	// typedef void (^YTStringCompletionHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void YTStringCompletionHandler([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	// typedef void (^YTArrayCompletionHandler)(NSArray * _Nullable, NSError * _Nullable);
	delegate void YTArrayCompletionHandler([NullAllowed] NSObject[] arg0, [NullAllowed] NSError arg1);

	// typedef void (^YTURLCompletionHandler)(NSURL * _Nullable, NSError * _Nullable);
	delegate void YTURLCompletionHandler([NullAllowed] NSUrl arg0, [NullAllowed] NSError arg1);

	// typedef void (^YTPlayerStateCompletionHandler)(YTPlayerState, NSError * _Nullable);
	delegate void YTPlayerStateCompletionHandler(YTPlayerState arg0, [NullAllowed] NSError arg1);

	// typedef void (^YTPlaybackQualityCompletionHandler)(YTPlaybackQuality, NSError * _Nullable);
	delegate void YTPlaybackQualityCompletionHandler(YTPlaybackQuality arg0, [NullAllowed] NSError arg1);

	// @protocol YTPlayerViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface YTPlayerViewDelegate
	{
		// @optional -(void)playerViewDidBecomeReady:(YTPlayerView * _Nonnull)playerView;
		[Export("playerViewDidBecomeReady:")]
		void PlayerViewDidBecomeReady(YTPlayerView playerView);

		// @optional -(void)playerView:(YTPlayerView * _Nonnull)playerView didChangeToState:(YTPlayerState)state;
		[Export("playerView:didChangeToState:")]
		void PlayerView(YTPlayerView playerView, YTPlayerState state);

		// @optional -(void)playerView:(YTPlayerView * _Nonnull)playerView didChangeToQuality:(YTPlaybackQuality)quality;
		[Export("playerView:didChangeToQuality:")]
		void PlayerView(YTPlayerView playerView, YTPlaybackQuality quality);

		// @optional -(void)playerView:(YTPlayerView * _Nonnull)playerView receivedError:(YTPlayerError)error;
		[Export("playerView:receivedError:")]
		void PlayerView(YTPlayerView playerView, YTPlayerError error);

		// @optional -(void)playerView:(YTPlayerView * _Nonnull)playerView didPlayTime:(float)playTime;
		[Export("playerView:didPlayTime:")]
		void PlayerView(YTPlayerView playerView, float playTime);

		// @optional -(UIColor * _Nonnull)playerViewPreferredWebViewBackgroundColor:(YTPlayerView * _Nonnull)playerView;
		[Export("playerViewPreferredWebViewBackgroundColor:")]
		UIColor PlayerViewPreferredWebViewBackgroundColor(YTPlayerView playerView);

		// @optional -(UIView * _Nullable)playerViewPreferredInitialLoadingView:(YTPlayerView * _Nonnull)playerView;
		[Export("playerViewPreferredInitialLoadingView:")]
		[return: NullAllowed]
		UIView PlayerViewPreferredInitialLoadingView(YTPlayerView playerView);
	}

	// @interface YTPlayerView : UIView
	[BaseType(typeof(UIView))]
	interface YTPlayerView
	{
		// @property (readonly, nonatomic) WKWebView * _Nullable webView;
		[NullAllowed, Export("webView")]
		WKWebView WebView { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		YTPlayerViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<YTPlayerViewDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(BOOL)loadWithVideoId:(NSString * _Nonnull)videoId;
		[Export("loadWithVideoId:")]
		bool LoadWithVideoId(string videoId);

		// -(BOOL)loadWithPlaylistId:(NSString * _Nonnull)playlistId;
		[Export("loadWithPlaylistId:")]
		bool LoadWithPlaylistId(string playlistId);

		// -(BOOL)loadWithVideoId:(NSString * _Nonnull)videoId playerVars:(NSDictionary * _Nullable)playerVars;
		[Export("loadWithVideoId:playerVars:")]
		bool LoadWithVideoId(string videoId, [NullAllowed] NSDictionary playerVars);

		// -(BOOL)loadWithPlaylistId:(NSString * _Nonnull)playlistId playerVars:(NSDictionary * _Nullable)playerVars;
		[Export("loadWithPlaylistId:playerVars:")]
		bool LoadWithPlaylistId(string playlistId, [NullAllowed] NSDictionary playerVars);

		// -(BOOL)loadWithPlayerParams:(NSDictionary * _Nullable)additionalPlayerParams;
		[Export("loadWithPlayerParams:")]
		bool LoadWithPlayerParams([NullAllowed] NSDictionary additionalPlayerParams);

		// -(void)playVideo;
		[Export("playVideo")]
		void PlayVideo();

		// -(void)pauseVideo;
		[Export("pauseVideo")]
		void PauseVideo();

		// -(void)stopVideo;
		[Export("stopVideo")]
		void StopVideo();

		// -(void)seekToSeconds:(float)seekToSeconds allowSeekAhead:(BOOL)allowSeekAhead;
		[Export("seekToSeconds:allowSeekAhead:")]
		void SeekToSeconds(float seekToSeconds, bool allowSeekAhead);

		// -(void)cueVideoById:(NSString * _Nonnull)videoId startSeconds:(float)startSeconds;
		[Export("cueVideoById:startSeconds:")]
		void CueVideoById(string videoId, float startSeconds);

		// -(void)cueVideoById:(NSString * _Nonnull)videoId startSeconds:(float)startSeconds endSeconds:(float)endSeconds;
		[Export("cueVideoById:startSeconds:endSeconds:")]
		void CueVideoById(string videoId, float startSeconds, float endSeconds);

		// -(void)loadVideoById:(NSString * _Nonnull)videoId startSeconds:(float)startSeconds;
		[Export("loadVideoById:startSeconds:")]
		void LoadVideoById(string videoId, float startSeconds);

		// -(void)loadVideoById:(NSString * _Nonnull)videoId startSeconds:(float)startSeconds endSeconds:(float)endSeconds;
		[Export("loadVideoById:startSeconds:endSeconds:")]
		void LoadVideoById(string videoId, float startSeconds, float endSeconds);

		// -(void)cueVideoByURL:(NSString * _Nonnull)videoURL startSeconds:(float)startSeconds;
		[Export("cueVideoByURL:startSeconds:")]
		void CueVideoByURL(string videoURL, float startSeconds);

		// -(void)cueVideoByURL:(NSString * _Nonnull)videoURL startSeconds:(float)startSeconds endSeconds:(float)endSeconds;
		[Export("cueVideoByURL:startSeconds:endSeconds:")]
		void CueVideoByURL(string videoURL, float startSeconds, float endSeconds);

		// -(void)loadVideoByURL:(NSString * _Nonnull)videoURL startSeconds:(float)startSeconds;
		[Export("loadVideoByURL:startSeconds:")]
		void LoadVideoByURL(string videoURL, float startSeconds);

		// -(void)loadVideoByURL:(NSString * _Nonnull)videoURL startSeconds:(float)startSeconds endSeconds:(float)endSeconds;
		[Export("loadVideoByURL:startSeconds:endSeconds:")]
		void LoadVideoByURL(string videoURL, float startSeconds, float endSeconds);

		// -(void)cuePlaylistByPlaylistId:(NSString * _Nonnull)playlistId index:(int)index startSeconds:(float)startSeconds;
		[Export("cuePlaylistByPlaylistId:index:startSeconds:")]
		void CuePlaylistByPlaylistId(string playlistId, int index, float startSeconds);

		// -(void)cuePlaylistByVideos:(NSArray * _Nonnull)videoIds index:(int)index startSeconds:(float)startSeconds;
		[Export("cuePlaylistByVideos:index:startSeconds:")]
		void CuePlaylistByVideos(NSObject[] videoIds, int index, float startSeconds);

		// -(void)loadPlaylistByPlaylistId:(NSString * _Nonnull)playlistId index:(int)index startSeconds:(float)startSeconds;
		[Export("loadPlaylistByPlaylistId:index:startSeconds:")]
		void LoadPlaylistByPlaylistId(string playlistId, int index, float startSeconds);

		// -(void)loadPlaylistByVideos:(NSArray * _Nonnull)videoIds index:(int)index startSeconds:(float)startSeconds;
		[Export("loadPlaylistByVideos:index:startSeconds:")]
		void LoadPlaylistByVideos(NSObject[] videoIds, int index, float startSeconds);

		// -(void)nextVideo;
		[Export("nextVideo")]
		void NextVideo();

		// -(void)previousVideo;
		[Export("previousVideo")]
		void PreviousVideo();

		// -(void)playVideoAt:(int)index;
		[Export("playVideoAt:")]
		void PlayVideoAt(int index);

		// -(void)playbackRate:(YTFloatCompletionHandler _Nullable)completionHandler;
		[Export("playbackRate:")]
		void PlaybackRate([NullAllowed] YTFloatCompletionHandler completionHandler);

		// -(void)setPlaybackRate:(float)suggestedRate;
		[Export("setPlaybackRate:")]
		void SetPlaybackRate(float suggestedRate);

		// -(void)availablePlaybackRates:(YTArrayCompletionHandler _Nullable)completionHandler;
		[Export("availablePlaybackRates:")]
		void AvailablePlaybackRates([NullAllowed] YTArrayCompletionHandler completionHandler);

		// -(void)setLoop:(BOOL)loop;
		[Export("setLoop:")]
		void SetLoop(bool loop);

		// -(void)setShuffle:(BOOL)shuffle;
		[Export("setShuffle:")]
		void SetShuffle(bool shuffle);

		// -(void)videoLoadedFraction:(YTFloatCompletionHandler _Nullable)completionHandler;
		[Export("videoLoadedFraction:")]
		void VideoLoadedFraction([NullAllowed] YTFloatCompletionHandler completionHandler);

		// -(void)playerState:(YTPlayerStateCompletionHandler _Nullable)completionHandler;
		[Export("playerState:")]
		void PlayerState([NullAllowed] YTPlayerStateCompletionHandler completionHandler);

		// -(void)currentTime:(YTFloatCompletionHandler _Nullable)completionHandler;
		[Export("currentTime:")]
		void CurrentTime([NullAllowed] YTFloatCompletionHandler completionHandler);

		// -(void)duration:(YTDoubleCompletionHandler _Nullable)completionHandler;
		[Export("duration:")]
		void Duration([NullAllowed] YTDoubleCompletionHandler completionHandler);

		// -(void)videoUrl:(YTURLCompletionHandler _Nullable)completionHandler;
		[Export("videoUrl:")]
		void VideoUrl([NullAllowed] YTURLCompletionHandler completionHandler);

		// -(void)videoEmbedCode:(YTStringCompletionHandler _Nullable)completionHandler;
		[Export("videoEmbedCode:")]
		void VideoEmbedCode([NullAllowed] YTStringCompletionHandler completionHandler);

		// -(void)playlist:(YTArrayCompletionHandler _Nullable)completionHandler;
		[Export("playlist:")]
		void Playlist([NullAllowed] YTArrayCompletionHandler completionHandler);

		// -(void)playlistIndex:(YTIntCompletionHandler _Nullable)completionHandler;
		[Export("playlistIndex:")]
		void PlaylistIndex([NullAllowed] YTIntCompletionHandler completionHandler);

		// -(void)removeWebView;
		[Export("removeWebView")]
		void RemoveWebView();
	}
}

