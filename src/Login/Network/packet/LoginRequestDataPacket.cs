﻿using Login.Enum;
using Shared.Util.Log.Factories;

namespace Login.Network.packet
{
    public class LoginRequestDataPacket : Shared.Network.DataPacket
    {
        public new const short NetworkId = (short) PacketType.C2SLogin;

        // Player Data From Client
        public string Identifier;
        public string Username;
        public string Password;
        public string Arguments;
        public string MacAddress;
        
        public override short Pid()
        {
            return NetworkId;
        }

        public override void Decode()
        {
            Username = ToString(16, 13);
            Password = ToString(37, 20);
            Arguments = ToString(160, 224);
            MacAddress = ToString(buffer.Length-24, 12);
            Identifier = ToString(77, 41);
        }

        public override void Encode()
        {
            
        }

        public void Debug()
        {
            LogFactory.GetLog("Main").LogInfo("Username: " + Username);
            LogFactory.GetLog("Main").LogInfo("Password: " + Password);
            LogFactory.GetLog("Main").LogInfo("Arguments: " + Arguments);
            LogFactory.GetLog("Main").LogInfo("MacAddress: " + MacAddress);
            LogFactory.GetLog("Main").LogInfo("Identifier: " + Identifier);
        }
    }
}