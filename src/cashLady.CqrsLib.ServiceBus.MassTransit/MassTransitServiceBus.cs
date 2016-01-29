using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MassTransit;

namespace CashLady.CqrsLib.ServiceBus.MassTransit
{
    public class MassTransitServiceBus : IEventPublisher, ICommandSender
    {
        private readonly IBusControl _serviceBus;

        public MassTransitServiceBus(IBusControl serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public void Publish<T>(T @event) where T : Event
        {
           // SendMessage<T>(@event);
            //serviceBus.Publish<T>(@event);
        }

        public void Send<T>(T command) where T : Command
        {
            SendMessage<T>(command);
        }

        private void SendMessage<T>(T message) where T :class
        {

            //Expression<Action> templateExpression = () => this.serviceBus<T>.Publish(message);
            _serviceBus.Publish(message);
            //var templateMethod = ((MethodCallExpression)templateExpression.Body).Method;
            //var genericMethod = templateMethod.GetGenericMethodDefinition();
            //var specificMethod = genericMethod.MakeGenericMethod(type);
            //specificMethod.Invoke(this.serviceBus, new object[] { message });
        }
    }
}
