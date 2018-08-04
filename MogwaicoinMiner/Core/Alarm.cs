﻿using MogwaicoinMiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MogwaicoinMiner.Core
{
    public class Alarm
    {
        private const int CORE_ALARM_INTERVAL = 10000;
        private const int CORE_ALARM_DELAY_START = 5000;
        static event OneMinerTimerEvent m_Events;
        static event OneMinerTimerEvent m_EventsPermanent;
        static Timer m_timer = null;
        static Alarm()
        {
            m_timer = new Timer(CheckStatus, null, CORE_ALARM_DELAY_START, CORE_ALARM_INTERVAL);
        }
        static private void CheckStatus(Object stateInfo)
        {
            try
            {
                if (m_Events != null)
                {
                    Delegate[] delegates = m_Events.GetInvocationList();
                    if (delegates.Length > 0)
                        m_Events.Invoke();
                }
                if (m_EventsPermanent != null)
                {
                    Delegate[] delegates = m_EventsPermanent.GetInvocationList();
                    if (delegates.Length > 0)
                        m_EventsPermanent.Invoke();
                }
            }
            catch (Exception e)
            {
                Factory.Instance.Logger.LogError(e.ToString());
            }
        }
        public static void RegisterForTimer(OneMinerTimerEvent fun)
        {
            m_Events += fun;
        }
        public static void RegisterForTimerPermanent(OneMinerTimerEvent fun)
        {
            m_EventsPermanent += fun;
        }
        public static void Clear()
        {
            m_Events = null;
        }
    }
}
