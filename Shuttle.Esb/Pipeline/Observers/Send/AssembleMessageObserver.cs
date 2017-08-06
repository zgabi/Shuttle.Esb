﻿using Shuttle.Core.Infrastructure;

namespace Shuttle.Esb
{
    public class AssembleMessageObserver : IPipelineObserver<OnAssembleMessage>
    {
        private readonly IServiceBusConfiguration _configuration;
        private readonly IIdentityProvider _identityProvider;

        public AssembleMessageObserver(IServiceBusConfiguration configuration, IIdentityProvider identityProvider)
        {
            Guard.AgainstNull(configuration, nameof(configuration));
            Guard.AgainstNull(identityProvider, nameof(identityProvider));

            _configuration = configuration;
            _identityProvider = identityProvider;
        }

        public void Execute(OnAssembleMessage pipelineEvent)
        {
            var state = pipelineEvent.Pipeline.State;
            var transportMessageConfigurator =
                state.Get<TransportMessageConfigurator>(StateKeys.TransportMessageConfigurator);

            Guard.AgainstNull(transportMessageConfigurator, nameof(transportMessageConfigurator));
            Guard.AgainstNull(transportMessageConfigurator.Message, "transportMessageConfigurator.Message");

            state.SetTransportMessage(transportMessageConfigurator.TransportMessage(_configuration, _identityProvider));
            state.SetMessage(transportMessageConfigurator.Message);
        }
    }
}