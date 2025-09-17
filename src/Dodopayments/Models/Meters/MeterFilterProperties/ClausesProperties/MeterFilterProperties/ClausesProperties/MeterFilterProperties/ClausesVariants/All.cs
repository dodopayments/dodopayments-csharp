using System.Collections.Generic;
using Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;

/// <summary>
/// Array of filter conditions
/// </summary>
public sealed record class Level2FilterConditions(List<MeterFilterCondition2> Value)
    : Clauses2,
        IVariant<Level2FilterConditions, List<MeterFilterCondition2>>
{
    public static Level2FilterConditions From(List<MeterFilterCondition2> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

/// <summary>
/// Array of level 3 nested filters (final level)
/// </summary>
public sealed record class Level2NestedFilters(List<MeterFilter3> Value)
    : Clauses2,
        IVariant<Level2NestedFilters, List<MeterFilter3>>
{
    public static Level2NestedFilters From(List<MeterFilter3> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
