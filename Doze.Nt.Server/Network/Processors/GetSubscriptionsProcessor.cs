using Doze.Nt.Server.Database;
using Doze.Nt.Server.Database.Accessors;
using Jareem.Network.Packets;
using Jareem.Network.Packets.Subscriptions.Data;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpReceiving;
using Jareem.Support.Implements.Observer.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doze.Nt.Server.Network.Processors
{
    public enum GetSubscriptionsProcessorCode
    {
        CannotGetDatabase = 801,
        CannotCreateDatabaseContext = 802,
        CannotGetProductsAccessor = 803,
        CannotGetProductFromAccessor = 804,
        CannotGetUserAccessor = 805,
    }

    class GetSubscriptionsProcessor : IObserver<BaseData>
    {
        public void OnCompleted()
        { }

        public void OnError(Exception error)
        {

        }

        public void OnNext(BaseData value)
        {
            var network = DozeObject.FindObjectOfType<NetworkObject>();
            var rec = value.As<TcpNetworkData>();
            if (rec.PacketContent.Identifier == (int)Packets.GetSubscriptionsRequest)
            {
                var packet = rec.PacketContent.Convert<GetSubscriptionsRequest>();
                if (packet != null)
                {
                    bool result = false;
                    string message = "";
                    List<Subscription> availableSubscriptions = new List<Subscription>();

                    var db = DozeObject.FindObjectOfType<DatabaseObject>();
                    if (db != null)
                    {
                        using (var ctx = db.CreateContext())
                        {
                            var accessor = ctx.GetAccesorOfType<UserSubscriptionsAccessor>();
                            if (accessor != null)
                            {
                                var searchResult = accessor.Where((x) => x.UserId == packet.UserIdentifier).ToList();
                                if(searchResult.Count > 0)
                                {
                                    var userAccessor = ctx.GetAccesorOfType<UserAccessor>();
                                    if (userAccessor != null)
                                    {
                                        var user = userAccessor.SelectOne((x) => x.Id == packet.UserIdentifier);
                                        if (user != null)
                                        {
                                            foreach (var item in searchResult)
                                            {
                                                if (item.IsActive & !item.IsLocked)
                                                {
                                                    if (item.ExpiredAt > DateTime.Now)
                                                    {
                                                        var productAccessor = ctx.GetAccesorOfType<ProductAccessor>();
                                                        if (productAccessor != null)
                                                        {
                                                            var product = productAccessor.SelectOne((x) => x.Id == item.ProductId);
                                                            if (product != null)
                                                            {
                                                                availableSubscriptions.Add(new Subscription(product.Id, product.Title, product.Status, product.IsAvailable, item.BoughtAt, item.ExpiredAt));

                                                                result = true;
                                                            }
                                                            else
                                                            {
                                                                result = false;
                                                                message = $"Error: '{GetSubscriptionsProcessorCode.CannotGetProductFromAccessor}'";

                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            result = false;
                                                            message = $"Error: '{GetSubscriptionsProcessorCode.CannotGetProductsAccessor}'";

                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        result = false;
                                        message = $"Error: '{GetSubscriptionsProcessorCode.CannotGetUserAccessor}'";
                                    }
                                }
                                else
                                {
                                    result = false;
                                    message = $"Not active subscriptions";
                                }
                            }
                            else
                            {
                                result = false;
                                message = $"Error: '{GetSubscriptionsProcessorCode.CannotGetDatabase}'";
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        message = $"Error: '{GetSubscriptionsProcessorCode.CannotGetDatabase}'";
                    }

                    network.GetService().Send(new GetSubscriptionsResponse() { Result = result, Message = message, AvailableSubscriptions = availableSubscriptions }, rec.Connection);
                }
            }
        }
    }
}
