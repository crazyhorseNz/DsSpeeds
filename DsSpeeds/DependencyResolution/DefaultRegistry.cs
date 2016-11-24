// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Commands;
using Commands.SpeedClaims;
using Data;
using Marten;
using Read;
using Read.Models;
using Shared;
using StructureMap;
using StructureMap.Configuration.DSL.Expressions;
using StructureMap.Pipeline;

namespace DsSpeeds.DependencyResolution
{
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });

            ForSingletonOf<IDocumentStore>()
                .Use("Build the DocumentStore", () => DocumentStore.For(MartenDocumentStore.StoreOptions));

            For<IDocumentSession>()
                .LifecycleIs<ContainerLifecycle>() // not really necessary in some frameworks
                .Use("Dirty Tracked Session", c => c.GetInstance<IDocumentStore>().DirtyTrackedSession());

            For<ICommand>()
                .AddInstances(expr =>
                {
                    //expr.Type<CreateSpeedClaim>().Named(nameof(CreateSpeedClaim))
                    RegisterCommand<CreateAircraftCommand>(expr);
                    RegisterCommand<CreateCountryCommand>(expr);
                    RegisterCommand<CreatePersonCommand>(expr);
                    RegisterCommand<CreateSiteCommand>(expr);
                    RegisterCommand<CreateSpeedClaimCommand>(expr);
                });

            For<IReadModel>()
                .AddInstances(expr =>
                {
                    RegisterReadModel<RecordedSpeedReadModel>(expr);
                    RegisterReadModel<SiteReadModel>(expr);
                });
        }


        private SmartInstance<TCommand, ICommand> RegisterCommand<TCommand>(IInstanceExpression<ICommand> expr)
            where TCommand : ICommand
        {
            return expr.Type<TCommand>().Named(nameof(TCommand));
        }

        private SmartInstance<TReadModel, IReadModel> RegisterReadModel<TReadModel>(IInstanceExpression<IReadModel> expr)
            where TReadModel : IReadModel
        {
            return expr.Type<TReadModel>().Named(nameof(TReadModel));
        }

        #endregion
    }
}