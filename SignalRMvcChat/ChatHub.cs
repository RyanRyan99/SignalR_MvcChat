
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNet.SignalR;
using SignalRMvcChat.Models;
using SignalRMvcChat.Models.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SignalRMvcChat
{
    public class ChatHub : Hub
    {
        public readonly static List<UserViewModel> _Connections = new List<UserViewModel>();
        private readonly static List<RoomViewModel> _Rooms = new List<RoomViewModel>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        public void Send(string roomName, string message)
        {
            if (message.StartsWith("/private"))
                SendPrivate(message);
            else
                SendToRoom(roomName, message);
        }

        private void SendToRoom(string roomName, string message)
        {
            
        }

        public void SendPrivate(string message)
        {
            string[] split = message.Split(')');
            string receiver = split[0].Split('(')[1];
            string userId;
            if (_ConnectionsMap.TryGetValue(receiver, out userId))
            {
                var sender = _Connections.Where(u => u.Username == IdentityName).FirstOrDefault();
                
            }
        }
        public IEnumerable<RoomViewModel> GetRooms()
        {
            using (var db = new ApplicationDbContext())
            {
                // First run?
                if (_Rooms.Count == 0)
                {
                    foreach (var room in db.Rooms)
                    {
                        var roomViewModel = Mapper.Map<Room, RoomViewModel>(room);
                        _Rooms.Add(roomViewModel);
                    }
                }
            }

            return _Rooms.ToList();
        }
        private string IdentityName
        {
            get { return Context.User.Identity.Name; }
        }
    }
}