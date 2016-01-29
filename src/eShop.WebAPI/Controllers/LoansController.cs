using System;
using System.Web.Http;
using CashLady.CqrsLib;
using CashLady.Domain.Version1.Commands;
using eShop.WebAPI.Models;
using MassTransit;

namespace eShop.WebAPI.Controllers
{
    public class LoansController : ApiController
    {
        private readonly ICommandSender _command;

        public LoansController(ICommandSender command)
        {
            _command = command;
        }

        public IHttpActionResult Get()
        {
            

            return Ok();
        }

        public IHttpActionResult Post(LoanRequest loanRequest)
        {
            _command.Send(new ApplyForLoan()
            {
                Apr = 10,
                MonthlyPayment = loanRequest.MonthlyPayment,
                OriginationFee = loanRequest.OriginationFee,
                Term = loanRequest.Term,
                TotalInterest = loanRequest.TotalInterest,
                TotalRepayment = loanRequest.TotalRepayment
            });

            return Ok();
        }

        //public IHttpActionResult Get()
            //{
            //    var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            //    {
            //        var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });

            //        x.ReceiveEndpoint(host, "eShop.WebAPI:SomethingHappened", e =>
            //          e.Consumer<SomethingHappenedConsumer>());
            //    });
            //    var busHandle = bus.Start();
            //   // Console.ReadKey();
            //    busHandle.Stop();//.Wait();

            //    return Ok();
            //}
        }
}