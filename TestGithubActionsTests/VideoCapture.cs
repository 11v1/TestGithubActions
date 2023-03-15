namespace TestGithubActionsTests
{
    using System;
    using global::FlaUI.Core.Capturing;
    using global::FlaUI.Core.Tools;
    using FlaUIRecorder = global::FlaUI.Core.Capturing.VideoRecorder;

    public sealed class VideoCapture
    {
        public IDisposable Start(string fileName, string pathName, string ffmpegPath)
        {
            SystemInfo.RefreshAll();

            var recorder = new FlaUIRecorder(new VideoRecorderSettings { VideoQuality = 26, ffmpegPath = ffmpegPath, TargetVideoPath = pathName }, r =>
            {
                var img = Capture.MainScreen();
                img.ApplyOverlays(new InfoOverlay(img)
                {
                    RecordTimeSpan = r.RecordTimeSpan,
                    OverlayStringFormat = @"{dt:HH\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc}) / " + fileName,
                },
                    new MouseOverlay(img));
                return img;
            });

            return recorder;
        }
    }
}