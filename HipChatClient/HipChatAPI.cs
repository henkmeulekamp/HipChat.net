using System;
using System.Collections.Generic;

namespace HipChat
{
    public class HipChatAPI : IHipChatAPI
    {
        private readonly HipChatClient client;

        public HipChatAPI(String apiKey)
        {
            this.client = new HipChatClient(apiKey);
        }

        public IList<Entities.Room> GetRooms()
        {
            return this.client.ListAllRooms();
        }

        public IList<Entities.Message> GetRoomHistory(int RoomID)
        {
            this.client.RoomId = RoomID;

            return this.client.ListHistoryAsNativeObjects();
        }

        public IList<Entities.Message> GetRoomHistory(int RoomID, DateTime Date)
        {
            this.client.RoomId = RoomID;

            return this.client.ListHistoryAsNativeObjects(Date);
        }

        public void SendMessage(int RoomID, String From, string Message)
        {
            this.client.RoomId = RoomID;

            this.client.SendMessage(Message, RoomID, From);
        }
    }
}