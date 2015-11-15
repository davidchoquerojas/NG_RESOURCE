using System;
using Microsoft.AspNet.SignalR;

namespace Metricaencuesta
{
    public class AppNotification : Hub
    {
        public void setConectionID(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }
        public void sendNotification(string groupName)
        {
            try
            {
                Clients.Group(groupName).reciveNotification(1);
            }
            catch (Exception ex)
            {
                new Elmah.Error(ex);
            }
        }
    }
}