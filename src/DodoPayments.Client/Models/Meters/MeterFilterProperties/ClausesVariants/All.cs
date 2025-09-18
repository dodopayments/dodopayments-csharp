using System.Collections.Generic;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesVariants;

/// <summary>
/// Direct filter conditions - array of condition objects with key, operator, and value
/// </summary>
public sealed record class DirectFilterConditions(
    List<ClausesProperties::MeterFilterCondition> Value
) : Clauses, IVariant<DirectFilterConditions, List<ClausesProperties::MeterFilterCondition>>
{
    public static DirectFilterConditions From(List<ClausesProperties::MeterFilterCondition> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

/// <summary>
/// Nested filters - supports up to 3 levels deep
/// </summary>
public sealed record class NestedMeterFilters(List<ClausesProperties::MeterFilter> Value)
    : Clauses,
        IVariant<NestedMeterFilters, List<ClausesProperties::MeterFilter>>
{
    public static NestedMeterFilters From(List<ClausesProperties::MeterFilter> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
