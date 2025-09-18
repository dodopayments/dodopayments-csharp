using System.Collections.Generic;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;

/// <summary>
/// Array of filter conditions
/// </summary>
public sealed record class Level1FilterConditions(
    List<ClausesProperties::MeterFilterCondition> Value
) : Clauses, IVariant<Level1FilterConditions, List<ClausesProperties::MeterFilterCondition>>
{
    public static Level1FilterConditions From(List<ClausesProperties::MeterFilterCondition> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

/// <summary>
/// Array of level 2 nested filters
/// </summary>
public sealed record class Level1NestedFilters(List<ClausesProperties::MeterFilter> Value)
    : Clauses,
        IVariant<Level1NestedFilters, List<ClausesProperties::MeterFilter>>
{
    public static Level1NestedFilters From(List<ClausesProperties::MeterFilter> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
