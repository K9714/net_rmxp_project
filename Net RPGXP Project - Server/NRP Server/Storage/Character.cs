using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace NRP_Server
{
    class Character
    {
        public int no { get; protected set; }
        public string name { get; protected set; }
        public string image { get; protected set; }
        public int exp { get; protected set; }
        public int level { get; protected set; }
        public int guild { get; protected set; }
        public int job { get; protected set; }
        virtual public int maxhp { get; protected set; }
        virtual public int maxmp { get; protected set; }
        virtual public int hp { get; protected set; }
        virtual public int mp { get; protected set; }
        virtual public int str { get; protected set; }
        virtual public int dex { get; protected set; }
        virtual public int Int { get; protected set; }
        virtual public int luk { get; protected set; }
        public int pdef { get; protected set; }
        public int mdef { get; protected set; }
        public int point { get; protected set; }

        public int mapid { get; protected set; }
        public int x { get; protected set; }
        public int y { get; protected set; }
        public int direction { get; protected set; }
        public int move_speed { get; protected set; }
    }
}
