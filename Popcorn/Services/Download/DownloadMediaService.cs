﻿using GalaSoft.MvvmLight.Messaging;
using Popcorn.Messaging;
using Popcorn.Models.Media;
using System;

namespace Popcorn.Services.Download
{
    /// <summary>
    /// Media download service for torrent download
    /// </summary>
    /// <typeparam name="T"><see cref="IMediaFile"/></typeparam>
    public class DownloadMediaService<T> : DownloadService<T> where T : MediaFile
    {
        /// <summary>
        /// Action to execute when a media has been buffered
        /// </summary>
        /// <param name="media"><see cref="MediaFile"/></param>
        /// <param name="reportDownloadProgress">Download progress</param>
        protected override void BroadcastMediaBuffered(T media, Progress<double> reportDownloadProgress)
        {
            Messenger.Default.Send(new PlayMediaMessage(media.FilePath, reportDownloadProgress));
        }
    }
}