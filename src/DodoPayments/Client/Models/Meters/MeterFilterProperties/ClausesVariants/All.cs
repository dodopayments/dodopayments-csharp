using System.Collections.Generic;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesVariants;

/// <summary>
/// Direct filter conditions - array of condition objects with key, operator, and value
/// </summary>
public sealed record class DirectFilterConditions(List<MeterFilterCondition> Value)
    : Clauses,
        IVariant<DirectFilterConditions, List<MeterFilterCondition>>
{
    public static DirectFilterConditions From(List<MeterFilterCondition> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

/// <summary>
/// Nested filters - supports up to 3 levels deep
/// </summary>
public sealed record class NestedMeterFilters(List<MeterFilter1> Value)
    : Clauses,
        IVariant<NestedMeterFilters, List<MeterFilter1>>
{
    public static NestedMeterFilters From(List<MeterFilter1> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
