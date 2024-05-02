# YoutubeiOSPlayerHelperNuget

Currently uses version 1.0.4 release of the youtube-ios-player-helper

https://github.com/youtube/youtube-ios-player-helper

## Updating bound youtube-ios-player-helper framework
1. Clone the youtube-ios-player-helper repo (or download its source)
2. Archive framework for devices
```
xcodebuild archive \
    -project youtube-ios-player-helper.xcodeproj \
    -scheme youtube-ios-player-helper \
    -configuration "Release" \
    -sdk "iphoneos" \
    -arch "arm64" \
    -archivePath "build/archives/youtube-ios-player-helper-ios-arm64" \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES \
    SKIP_INSTALL=NO
```
3. Archive framework for simulator
```
xcodebuild archive \
    -project youtube-ios-player-helper.xcodeproj \
    -scheme youtube-ios-player-helper \
    -configuration "Release" \
    -sdk "iphonesimulator" \
    ONLY_ACTIVE_ARCH=NO \
    -archivePath "build/archives/youtube-ios-player-helper-ios-arm64_x86_64-simulator" \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES \
    SKIP_INSTALL=NO
```
4. Assemble generated archives into an `xcframework`
```
xcodebuild -create-xcframework \
        -framework "build/archives/youtube-ios-player-helper-ios-arm64.xcarchive/Products/Library/Frameworks/YouTubeiOSPlayerHelper.framework" \
        -framework "build/archives/youtube-ios-player-helper-ios-arm64_x86_64-simulator.xcarchive/Products/Library/Frameworks/YouTubeiOSPlayerHelper.framework" \
        -output "build/YouTubeiOSPlayerHelper.xcframework"
```
5. Copy generated `YouTubeiOSPlayerHelper.xcframework` to this project's root folder (replacing the older `.xcframework`)
