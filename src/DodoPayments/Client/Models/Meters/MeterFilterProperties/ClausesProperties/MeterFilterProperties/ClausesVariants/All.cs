using System.Collections.Generic;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;

/// <summary>
/// Array of filter conditions
/// </summary>
public sealed record class Level1FilterConditions(List<MeterFilterCondition1> Value)
    : Clauses1,
        IVariant<Level1FilterConditions, List<MeterFilterCondition1>>
{
    public static Level1FilterConditions From(List<MeterFilterCondition1> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

/// <summary>
/// Array of level 2 nested filters
/// </summary>
public sealed record class Level1NestedFilters(List<MeterFilter2> Value)
    : Clauses1,
        IVariant<Level1NestedFilters, List<MeterFilter2>>
{
    public static Level1NestedFilters From(List<MeterFilter2> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
