using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Brands;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.WebhookEvents;
using Meters = DodoPayments.Client.Models.Meters;
using Payments = DodoPayments.Client.Models.Payments;
using Payouts = DodoPayments.Client.Models.Payouts;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _properties = [];

    public IReadOnlyDictionary<string, JsonElement> Properties
    {
        get { return this._properties.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, ThemeModel>(),
            new ApiEnumConverter<string, Currency>(),
            new ApiEnumConverter<string, Theme>(),
            new ApiEnumConverter<string, Payments::IntentStatus>(),
            new ApiEnumConverter<string, Payments::PaymentMethodTypes>(),
            new ApiEnumConverter<string, Payments::Status>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::TimeInterval>(),
            new ApiEnumConverter<string, Subscriptions::Status>(),
            new ApiEnumConverter<string, Subscriptions::ProrationBillingMode>(),
            new ApiEnumConverter<string, LicenseKeyStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, EventType>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, Refunds::RefundStatus>(),
            new ApiEnumConverter<string, Refunds::Status>(),
            new ApiEnumConverter<string, DisputeStageModel>(),
            new ApiEnumConverter<string, DisputeStatusModel>(),
            new ApiEnumConverter<string, DisputeStage>(),
            new ApiEnumConverter<string, DisputeStatus>(),
            new ApiEnumConverter<string, Payouts::Status>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, TypeModel>(),
            new ApiEnumConverter<string, Type1>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, VerificationStatus>(),
            new ApiEnumConverter<string, Webhooks::PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type>(),
            new ApiEnumConverter<string, Webhooks::PayloadTypeModel>(),
            new ApiEnumConverter<string, Webhooks::TypeModel>(),
            new ApiEnumConverter<string, Webhooks::PayloadType1>(),
            new ApiEnumConverter<string, Webhooks::Type1>(),
            new ApiEnumConverter<string, Webhooks::PayloadType2>(),
            new ApiEnumConverter<string, Webhooks::Type2>(),
            new ApiEnumConverter<string, Webhooks::PayloadType3>(),
            new ApiEnumConverter<string, Webhooks::Type3>(),
            new ApiEnumConverter<string, Webhooks::PayloadType4>(),
            new ApiEnumConverter<string, Webhooks::Type4>(),
            new ApiEnumConverter<string, Webhooks::PayloadType5>(),
            new ApiEnumConverter<string, Webhooks::Type5>(),
            new ApiEnumConverter<string, Webhooks::PayloadType6>(),
            new ApiEnumConverter<string, Webhooks::Type6>(),
            new ApiEnumConverter<string, Webhooks::PayloadType7>(),
            new ApiEnumConverter<string, Webhooks::Type7>(),
            new ApiEnumConverter<string, Webhooks::PayloadType8>(),
            new ApiEnumConverter<string, Webhooks::Type8>(),
            new ApiEnumConverter<string, Webhooks::PayloadType9>(),
            new ApiEnumConverter<string, Webhooks::Type9>(),
            new ApiEnumConverter<string, Webhooks::PayloadType10>(),
            new ApiEnumConverter<string, Webhooks::Type10>(),
            new ApiEnumConverter<string, Webhooks::PayloadType11>(),
            new ApiEnumConverter<string, Webhooks::Type11>(),
            new ApiEnumConverter<string, Webhooks::PayloadType12>(),
            new ApiEnumConverter<string, Webhooks::Type12>(),
            new ApiEnumConverter<string, Webhooks::PayloadType13>(),
            new ApiEnumConverter<string, Webhooks::Type13>(),
            new ApiEnumConverter<string, Webhooks::PayloadType14>(),
            new ApiEnumConverter<string, Webhooks::Type14>(),
            new ApiEnumConverter<string, Webhooks::PayloadType15>(),
            new ApiEnumConverter<string, Webhooks::Type15>(),
            new ApiEnumConverter<string, Webhooks::PayloadType16>(),
            new ApiEnumConverter<string, Webhooks::Type16>(),
            new ApiEnumConverter<string, Webhooks::PayloadType17>(),
            new ApiEnumConverter<string, Webhooks::Type17>(),
            new ApiEnumConverter<string, Webhooks::PayloadType18>(),
            new ApiEnumConverter<string, Webhooks::Type18>(),
            new ApiEnumConverter<string, Webhooks::PayloadType19>(),
            new ApiEnumConverter<string, Webhooks::Type19>(),
            new ApiEnumConverter<string, Webhooks::PayloadType20>(),
            new ApiEnumConverter<string, Webhooks::Type20>(),
            new ApiEnumConverter<string, Webhooks::PayloadType21>(),
            new ApiEnumConverter<string, Webhooks::Type21>(),
            new ApiEnumConverter<string, Webhooks::PayloadType22>(),
            new ApiEnumConverter<string, Webhooks::Type22>(),
            new ApiEnumConverter<string, Webhooks::PayloadType23>(),
            new ApiEnumConverter<string, Webhooks::Type23>(),
            new ApiEnumConverter<string, Webhooks::PayloadType24>(),
            new ApiEnumConverter<string, Webhooks::Type24>(),
            new ApiEnumConverter<string, Webhooks::PayloadType25>(),
            new ApiEnumConverter<string, Webhooks::Type25>(),
            new ApiEnumConverter<string, Webhooks::PayloadType26>(),
            new ApiEnumConverter<string, Webhooks::Type26>(),
            new ApiEnumConverter<string, Webhooks::PayloadType27>(),
            new ApiEnumConverter<string, Webhooks::Type27>(),
            new ApiEnumConverter<string, Webhooks::PayloadType28>(),
            new ApiEnumConverter<string, Webhooks::Type28>(),
            new ApiEnumConverter<string, Webhooks::PayloadType29>(),
            new ApiEnumConverter<string, Webhooks::Type29>(),
            new ApiEnumConverter<string, Webhooks::PayloadType30>(),
            new ApiEnumConverter<string, Webhooks::Type30>(),
            new ApiEnumConverter<string, Webhooks::PayloadType31>(),
            new ApiEnumConverter<string, Webhooks::Type31>(),
            new ApiEnumConverter<string, Webhooks::PayloadType32>(),
            new ApiEnumConverter<string, Webhooks::Type32>(),
            new ApiEnumConverter<string, Webhooks::PayloadType33>(),
            new ApiEnumConverter<string, Webhooks::Type33>(),
            new ApiEnumConverter<string, Webhooks::PayloadType34>(),
            new ApiEnumConverter<string, Webhooks::Type34>(),
            new ApiEnumConverter<string, Webhooks::PayloadType35>(),
            new ApiEnumConverter<string, Webhooks::Type35>(),
            new ApiEnumConverter<string, Webhooks::PayloadType36>(),
            new ApiEnumConverter<string, Webhooks::Type36>(),
            new ApiEnumConverter<string, Webhooks::PayloadType37>(),
            new ApiEnumConverter<string, Webhooks::Type37>(),
            new ApiEnumConverter<string, Webhooks::PayloadType38>(),
            new ApiEnumConverter<string, Webhooks::Type38>(),
            new ApiEnumConverter<string, Webhooks::PayloadType39>(),
            new ApiEnumConverter<string, Webhooks::Type39>(),
            new ApiEnumConverter<string, Webhooks::PayloadType40>(),
            new ApiEnumConverter<string, Webhooks::Type40>(),
            new ApiEnumConverter<string, WebhookEventType>(),
            new ApiEnumConverter<string, PayloadType>(),
            new ApiEnumConverter<string, PayloadTypeModel>(),
            new ApiEnumConverter<string, PayloadType1>(),
            new ApiEnumConverter<string, PayloadType2>(),
            new ApiEnumConverter<string, PayloadType3>(),
            new ApiEnumConverter<string, Meters::Type>(),
            new ApiEnumConverter<string, Meters::Operator>(),
            new ApiEnumConverter<string, Meters::OperatorModel>(),
            new ApiEnumConverter<string, Meters::Operator1>(),
            new ApiEnumConverter<string, Meters::Operator2>(),
            new ApiEnumConverter<string, Meters::Conjunction>(),
            new ApiEnumConverter<string, Meters::ConjunctionModel>(),
            new ApiEnumConverter<string, Meters::Conjunction1>(),
            new ApiEnumConverter<string, Meters::Conjunction2>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties);
}
