namespace NRP_Server
{
    class Portal
    {
        public int no { get; private set; }
        public int mapid { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }
        public int move_mapid { get; private set; }
        public int move_x { get; private set; }
        public int move_y { get; private set; }

        public Portal(int _no, int _mapid, int _x, int _y, int _move_mapid, int _move_x, int _move_y)
        {
            no = _no;
            mapid = _mapid;
            x = _x;
            y = _y;
            move_mapid = _move_mapid;
            move_x = _move_x;
            move_y = _move_y;
        }
    }
}
