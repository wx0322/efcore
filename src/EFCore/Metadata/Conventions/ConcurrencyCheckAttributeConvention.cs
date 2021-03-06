// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

#nullable enable

namespace Microsoft.EntityFrameworkCore.Metadata.Conventions
{
    /// <summary>
    ///     A convention that configures a property as a concurrency token if it has the <see cref="ConcurrencyCheckAttribute" />.
    /// </summary>
    public class ConcurrencyCheckAttributeConvention : PropertyAttributeConventionBase<ConcurrencyCheckAttribute>
    {
        /// <summary>
        ///     Creates a new instance of <see cref="ConcurrencyCheckAttributeConvention" />.
        /// </summary>
        /// <param name="dependencies"> Parameter object containing dependencies for this convention. </param>
        public ConcurrencyCheckAttributeConvention([NotNull] ProviderConventionSetBuilderDependencies dependencies)
            : base(dependencies)
        {
        }

        /// <summary>
        ///     Called after a property is added to the entity type with an attribute on the associated CLR property or field.
        /// </summary>
        /// <param name="propertyBuilder"> The builder for the property. </param>
        /// <param name="attribute"> The attribute. </param>
        /// <param name="clrMember"> The member that has the attribute. </param>
        /// <param name="context"> Additional information associated with convention execution. </param>
        protected override void ProcessPropertyAdded(
            IConventionPropertyBuilder propertyBuilder,
            ConcurrencyCheckAttribute attribute,
            MemberInfo clrMember,
            IConventionContext context)
        {
            propertyBuilder.IsConcurrencyToken(true, fromDataAnnotation: true);
        }
    }
}
