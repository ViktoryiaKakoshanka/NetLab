﻿using System.Windows;

namespace TimerApplication.Followers
{
    public static class Follower2
    {
        public static void ShowMessage()
        {
            MessageBox.Show("class Follower2");
        }

        public static void ShowNewMessage(object sender, EndTimerEventAgs e)
        {
            MessageBox.Show($"class Follower2 : ShowNewMessage(object sender, EndTimerEventAgs e) = {e.UserCount}");
        }
    }
}