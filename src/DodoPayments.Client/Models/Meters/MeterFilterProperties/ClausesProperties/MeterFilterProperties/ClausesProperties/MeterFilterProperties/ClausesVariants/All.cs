using System.Collections.Generic;
using DodoPayments.Client.Core;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;

/// <summary>
/// Array of filter conditions
/// </summary>
public sealed record class Level2FilterConditions(
    List<ClausesProperties::MeterFilterCondition> Value
) : Clauses, IVariant<Level2FilterConditions, List<ClausesProperties::MeterFilterCondition>>
{
    public static Level2FilterConditions From(List<ClausesProperties::MeterFilterCondition> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

/// <summary>
/// Array of level 3 nested filters (final level)
/// </summary>
public sealed record class Level2NestedFilters(List<ClausesProperties::MeterFilter> Value)
    : Clauses,
        IVariant<Level2NestedFilters, List<ClausesProperties::MeterFilter>>
{
    public static Level2NestedFilters From(List<ClausesProperties::MeterFilter> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
