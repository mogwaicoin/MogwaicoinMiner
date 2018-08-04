using MogwaicoinMiner.Core.Interfaces;
using MogwaicoinMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MogwaicoinMiner.View
{

    interface IView
    {
        void InitializeView();
        void StartView();
        void UpdateMinerList();
        void UpdateSettingsCarousal();
        void UpDateMinerState();
        void ShowHardwareMissingError();
        void RegisterForTimer(OneMinerTimerEvent fun);
        TSQueue<DownloadRequest> DownloadRequestQueue { get; set; }

    }
}
