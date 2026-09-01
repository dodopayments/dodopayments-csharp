using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Blocklist.Customers;

/// <summary>
/// Where a block came from. `Api` marks an API-key caller, which carries no dashboard
/// actor. The other values name the screen the merchant used.
/// </summary>
[JsonConverter(typeof(BlockedCustomerSourceConverter))]
public enum BlockedCustomerSource
{
    BlocklistPage,
    CustomerPage,
    PaymentPage,
    DisputePage,
    Api,
}

sealed class BlockedCustomerSourceConverter : JsonConverter<BlockedCustomerSource>
{
    public override BlockedCustomerSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "blocklist_page" => BlockedCustomerSource.BlocklistPage,
            "customer_page" => BlockedCustomerSource.CustomerPage,
            "payment_page" => BlockedCustomerSource.PaymentPage,
            "dispute_page" => BlockedCustomerSource.DisputePage,
            "api" => BlockedCustomerSource.Api,
            _ => (BlockedCustomerSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BlockedCustomerSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BlockedCustomerSource.BlocklistPage => "blocklist_page",
                BlockedCustomerSource.CustomerPage => "customer_page",
                BlockedCustomerSource.PaymentPage => "payment_page",
                BlockedCustomerSource.DisputePage => "dispute_page",
                BlockedCustomerSource.Api => "api",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
