using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace NRP_Server
{
    class ClientInfo
    {
        private readonly object sendSyncRoot = new object();
        private Socket workSocket;
        private byte[] RecvBuffer;
        private byte[] pBuffer;
        public string LastDataString;
        public bool closed = false;

        public ClientInfo(Socket sockData)
        {
            workSocket = sockData;
        }
        public Socket socket
        {
            get { return workSocket; }
        }
        public byte[] Buffer
        {
            get { return RecvBuffer; }
        }
        public int BufferSize
        {
            get { return RecvBuffer.Length; }
            set { RecvBuffer = new byte[value]; }
        }
        // 임시 버퍼
        public byte[] PacketBuffer
        {
            get { return pBuffer; }
        }
        // 임시 버퍼 추가하기
        public void PacketBufferAdd(byte[] data, int size)
        {
            Array.Resize(ref data, size);
            if (pBuffer == null)
            {
                pBuffer = data;
                return;
            }
            byte[] new_pBuffer = pBuffer;
            pBuffer = new byte[new_pBuffer.Length + data.Length];

            Array.Copy(new_pBuffer, pBuffer, new_pBuffer.Length);
            Array.Copy(data, 0, pBuffer, new_pBuffer.Length, data.Length);
        }
        // 임시 버퍼 제거하기
        public void PacketBufferDelete(int size)
        {
            if (pBuffer.Length - (size + 3) == 0)
            {
                pBuffer = null;
                return;
            }
            byte[] new_pBuffer = pBuffer;
            int new_size = new_pBuffer.Length - (size + 3);
            pBuffer = new byte[new_size];

            Array.Copy(new_pBuffer, size + 3, pBuffer, 0, new_size);
        }


        // 소켓 닫기
        public void close()
        {
            closed = true;
            socket.Shutdown(SocketShutdown.Both);
            socket.Dispose();
            socket.Close();
        }

        public void SendPacket(Hashtable data)
        {
            lock (sendSyncRoot)
            {
                string packetData = StringConverter.Encode(data);
                int size = Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(packetData)).Length;

                // 헤더의 크기는 3으로 고정한다.(전체 바이트의 크기 전달용)
                byte[] header = Encoding.UTF8.GetBytes(size.ToString().ToCharArray());
                Array.Resize(ref header, 3);

                byte[] body = Encoding.UTF8.GetBytes(packetData);
                byte[] packet = new byte[header.Length + body.Length];

                // 복사할 배열, 그 배열의 시작점, 복사될 배열, 그 배열의 복사 시작점, 복사할 배열의 끝점
                Array.Copy(header, 0, packet, 0, header.Length);
                Array.Copy(body, 0, packet, header.Length, body.Length);

                // 보낼 데이터, 시작위치, 길이, 타입, 메서드, 파라미터
                workSocket.BeginSend(packet, 0, packet.Length, SocketFlags.None, new AsyncCallback(SendCallBack), workSocket);
            }
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                var socket = (Socket)ar.AsyncState;
                socket.EndSend(ar);
                //Msg.Info("패킷 송신 완료");
            }
            catch (SocketException e)
            {
                Msg.Error(e.ToString());
            }
        }
    }
}
