using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Refunds;

/// <summary>
/// The kind of reference number that the card network or the bank gives to a refund.
/// </summary>
[JsonConverter(typeof(RefundNetworkReferenceTypeConverter))]
public enum RefundNetworkReferenceType
{
    AcquirerReferenceNumber,
    SystemTraceAuditNumber,
    RetrievalReferenceNumber,
    Other,
}

sealed class RefundNetworkReferenceTypeConverter : JsonConverter<RefundNetworkReferenceType>
{
    public override RefundNetworkReferenceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "acquirer_reference_number" => RefundNetworkReferenceType.AcquirerReferenceNumber,
            "system_trace_audit_number" => RefundNetworkReferenceType.SystemTraceAuditNumber,
            "retrieval_reference_number" => RefundNetworkReferenceType.RetrievalReferenceNumber,
            "other" => RefundNetworkReferenceType.Other,
            _ => (RefundNetworkReferenceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundNetworkReferenceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundNetworkReferenceType.AcquirerReferenceNumber => "acquirer_reference_number",
                RefundNetworkReferenceType.SystemTraceAuditNumber => "system_trace_audit_number",
                RefundNetworkReferenceType.RetrievalReferenceNumber => "retrieval_reference_number",
                RefundNetworkReferenceType.Other => "other",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
