using ExitGames.Client.Photon;
using Photon.Realtime;

namespace QFramework.NetworkExtension
{


    public class INetworkOperation : OperationResponse
    {
    }

    public class INetworkResponse : OperationResponse
    {
        public INetworkResponse(OperationResponse peo)
        {
            SynchronizationProperties(peo, this);
        }

        void SynchronizationProperties(OperationResponse src, INetworkResponse des)
        {
            des.ReturnCode = src.ReturnCode;
            des.Parameters = src.Parameters;
            des.DebugMessage = src.DebugMessage;
        }
    }

    public class INetEventData : EventData
    {
        public object customData;
        public ParameterDictionary param;
        public INetEventData(EventData peo)
        {
            SynchronizationProperties(peo, this);
        }

        void SynchronizationProperties(EventData src, INetEventData des)
        {
            des.Code = src.Code;
            des.param = src.Parameters;
            des.customData = src.CustomData;
        }
    }

    public class INetPlayer : Player
    {
        public string userId;
        public bool hasRejoined;
        public bool isMasterClient;
        public INetPlayer(Player player, string nickName, int actorNumber, bool isLocal, Hashtable playerProperties) : base
        (nickName, actorNumber, isLocal, playerProperties)
        {
            this.TagObject = player.TagObject;
            this.userId = player.UserId;
            this.hasRejoined = player.HasRejoined;
            this.isMasterClient = player.IsMasterClient;
        }

    }

    public class INetRoom : Room
    {
        public INetRoom(string roomName, RoomOptions options, bool isOffline = false)
            : base(roomName, options)
        {

        }
    }

    public class INetRoomInfo
    {
        /// <summary>���ڴ��ã�������ǲ��ٱ��г��ķ���(��ʾ�������رջ�����).</summary>
        public bool RemovedFromList;

        public Hashtable customProperties = new Hashtable();

        public byte maxPlayers = 0;

        public int playerCount;

        public string[] expectedUsers;

        public bool isOpen = true;

        public bool isVisible = true;

        public string name;

        public int masterClientId;

        public string[] propertiesListedInLobby;

    }

    public class INetLobbyInfo
    {
        /// <summary>��ǰ����˴������������.</summary>
        public int PlayerCount;

        /// <summary>��ǰ��������.</summary>
        public int RoomCount;

        public override string ToString()
        {
            return string.Format("TypedLobbyInfo] rooms: {2} players: {3}", this.RoomCount, this.PlayerCount);
        }
    }

    public enum INetDisconnectCause
    {
        /// <summary>No error was tracked.</summary>
        None,

        /// <summary>��Ϊ��ַ������߷�����δ����.</summary>
        ExceptionOnConnect,

        /// <summary>Dns����������ʧ�ܡ����쳣�������Դ��󼶱��¼.</summary>
        DnsExceptionOnConnect,

        /// <summary>��������ַ��ʽ����.</summary>
        ServerAddressInvalid,

        /// <summary>һЩ�����µķ���������ʧ��</summary>
        Exception,

        /// <summary>���������ӳ�ʱ�Ͽ�.</summary>
        ServerTimeout,

        /// <summary>�ͻ������ӳ�ʱ�Ͽ�.</summary>
        ClientTimeout,

        /// <summary>����Ͽ�����ͻ��˵�����.</summary>
        DisconnectByServerLogic,

        /// <summary>��������δ֪ԭ��Ͽ��˿ͻ���.</summary>
        DisconnectByServerReasonUnknown,

        /// <summary>��Photon Cloud����֤��Ч��AppId.</summary>
        InvalidAuthentication,

        /// <summary>��֤��Photon������Ч�Ŀͻ���ֵ���Զ�����֤���������Ǳ��.</summary>
        CustomAuthenticationFailed,

        /// <summary>��Ʊ������.</summary>
        AuthenticationTicketExpired,

        /// <summary>CCU����.</summary>
        MaxCcuReached,

        /// <summary>�������.</summary>
        InvalidRegion,

        /// <summary>��ǰ����ͻ���(ͨ��û����Ȩ)�����õĲ���.</summary>
        OperationNotAllowedInCurrentState,

        /// <summary>�ͻ������߼�(c#����)�Ͽ�����.</summary>
        DisconnectByClientLogic,


        /// <remarks>����Ƶ���Ͽ�����.</remarks>
        DisconnectByOperationLimit,

        /// <summary>�ͻ����յ����Է������ġ��Ͽ�������Ϣ��.</summary>
        DisconnectByDisconnectMessage
    }

    public class INetFriendInfo
    {
        public string UserId;

        public bool IsOnline;

        public string Room;

        public bool IsInRoom;
    }
}