using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NRP_Server
{
    public static class ServerThread
    {
        private static Thread runUpdate;
        private static Thread runSkillUpdate;

        public static void Initialize()
        {
            runUpdate = new Thread(delegate () { while (!Program.SocketObject.IsEnded) { Update(); } });
            runSkillUpdate = new Thread(delegate () { while (!Program.SocketObject.IsEnded) { Skill.update(); } });
        }

        public static void Start()
        {
            runUpdate.Start();
            runSkillUpdate.Start();
        }
        public static void Stop()
        {
            Program.SocketObject.IsEnded = true;
            runUpdate.Join();
            runSkillUpdate.Join();
        }
        public static void Restart()
        {
            Stop();
            Start();
        }

        public static void Update()
        {
            foreach (Map map in Map.Maps.Values)
                map.update();

            Thread.Sleep(Config.WAIT_TIME);
        }
    }
}
