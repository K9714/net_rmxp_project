using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;

namespace NRP_Server
{
    // 강제 연결 끊기
    // (Socket).Shutdown(System.Net.Sockets.SocketShutdown.Both);

    // Thread safe
    // https://stackoverflow.com/questions/6180066/socket-locking-across-threads

    class Handler
    {
        public bool IsEnded { get; set; }
        private ManualResetEvent allDone = new ManualResetEvent(false);
        Socket serverSock;
        public void Start()
        {
            IsEnded = false;
            // Server Event
            ConsoleEvent.Initialize();
            // Socket
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSock.Bind(new IPEndPoint(IPAddress.Any, Config.PORT));
                serverSock.Listen(Config.MAX_NUM);
                // MySQL 연결
                BootLoader.Initialize();
                Msg.Info("서버가 정상적으로 실행되었습니다.");
                // 멀티쓰레드 시작
                ServerThread.Initialize();
                ServerThread.Start();
                while (true)
                {
                    allDone.Reset();
                    if (IsEnded)
                    {
                        serverSock.Close(0);
                        break;
                    }
                    // 승인이 끝난 경우 AcceptCallBack을 실행 - 대상 소켓은 서버 소켓
                    serverSock.BeginAccept(new AsyncCallback(AcceptCallBack), serverSock);
                    allDone.WaitOne();
                }
                Msg.Close("Handler 정상 종료 완료.");
            }
            catch (Exception e)
            {
                Msg.Error(e.ToString());
            }

        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            try
            {
                // 요청이 끝난 대상의 소켓은 서버의 소켓
                Socket listener = (Socket)ar.AsyncState;
                // 서버의 소켓에서 마지막 요청을 보냈던 소켓을 받음
                Socket clientSock = listener.EndAccept(ar);

                Msg.Info("[" + ((IPEndPoint)clientSock.RemoteEndPoint).Address.ToString() + "] " + "유저가 접속했습니다.");

                // 유저정보를 대입. 가장 중요한 소켓은 살린다
                ClientInfo clientData = new ClientInfo(clientSock);
                clientData.BufferSize = 512;
                // 모든 유저 브로드캐스트에 추가
                Packet.BroadCast += clientData.SendPacket;
                clientSock.BeginReceive(clientData.Buffer, 0, clientData.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallBack), clientData);
            }
            catch (ObjectDisposedException)
            {
                allDone.Set();
                return;
            }
            catch (Exception e)
            {
                Msg.Error(e.ToString());
                return;
            }
            allDone.Set();
        }
        private void ReadCallBack(IAsyncResult ar)
        {
            // 보낸 유저의 데이터를 받아옴
            // 다시 대기한다.
            ClientInfo clientData = (ClientInfo)ar.AsyncState;
            try
            {
                // 일괄 처리로 옮김
                if (Packet.RecvData(ar))
                {
                    clientData.socket.BeginReceive(clientData.Buffer, 0, clientData.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallBack), clientData);
                }
                else
                {
                    // 연결이 끊긴 경우
                    removeClient(clientData, ((IPEndPoint)clientData.socket.RemoteEndPoint).Address.ToString());
                }
            }
            catch (Exception e)
            {
                // 보통은 연결 끊김
                Msg.Error(e.ToString());
                if (!clientData.closed)
                    removeClient(clientData, ((IPEndPoint)clientData.socket.RemoteEndPoint).Address.ToString());
            }
        }
        private void removeClient(ClientInfo clientData, string ip)
        {
            // 브로드캐스트 제거
            Packet.BroadCast -= clientData.SendPacket;
            // 강제 종료
            clientData.close();
            // 변수 클리어
            if (UserData.Users.ContainsKey(clientData))
            {
                UserData.Users[clientData].saveData(true);
                UserData.Users.Remove(clientData);
            }
            Msg.Info("[" + ip + "] " + "유저가 접속 종료했습니다.");
        }

        public void ShutDown()
        {
            try
            {
                allDone.Set();
            }
            catch (Exception e)
            {
                Msg.Error(e.ToString());
            }
            finally
            {
                serverSock.Shutdown(SocketShutdown.Both);
            }
        }
    }
}