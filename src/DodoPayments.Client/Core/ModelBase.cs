using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Brands;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Webhooks;
using Meters = DodoPayments.Client.Models.Meters;
using Payments = DodoPayments.Client.Models.Payments;
using Payouts = DodoPayments.Client.Models.Payouts;
using Products = DodoPayments.Client.Models.Products;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using WebhookEvents = DodoPayments.Client.Models.WebhookEvents;

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
            new ApiEnumConverter<string, Products::Type>(),
            new ApiEnumConverter<string, Products::TypeModel>(),
            new ApiEnumConverter<string, Products::Type1>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, VerificationStatus>(),
            new ApiEnumConverter<string, PayloadType>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, PayloadTypeModel>(),
            new ApiEnumConverter<string, TypeModel>(),
            new ApiEnumConverter<string, PayloadType1>(),
            new ApiEnumConverter<string, Type1>(),
            new ApiEnumConverter<string, PayloadType2>(),
            new ApiEnumConverter<string, Type2>(),
            new ApiEnumConverter<string, PayloadType3>(),
            new ApiEnumConverter<string, Type3>(),
            new ApiEnumConverter<string, PayloadType4>(),
            new ApiEnumConverter<string, Type4>(),
            new ApiEnumConverter<string, PayloadType5>(),
            new ApiEnumConverter<string, Type5>(),
            new ApiEnumConverter<string, PayloadType6>(),
            new ApiEnumConverter<string, Type6>(),
            new ApiEnumConverter<string, PayloadType7>(),
            new ApiEnumConverter<string, Type7>(),
            new ApiEnumConverter<string, PayloadType8>(),
            new ApiEnumConverter<string, Type8>(),
            new ApiEnumConverter<string, PayloadType9>(),
            new ApiEnumConverter<string, Type9>(),
            new ApiEnumConverter<string, PayloadType10>(),
            new ApiEnumConverter<string, Type10>(),
            new ApiEnumConverter<string, PayloadType11>(),
            new ApiEnumConverter<string, Type11>(),
            new ApiEnumConverter<string, PayloadType12>(),
            new ApiEnumConverter<string, Type12>(),
            new ApiEnumConverter<string, PayloadType13>(),
            new ApiEnumConverter<string, Type13>(),
            new ApiEnumConverter<string, PayloadType14>(),
            new ApiEnumConverter<string, Type14>(),
            new ApiEnumConverter<string, PayloadType15>(),
            new ApiEnumConverter<string, Type15>(),
            new ApiEnumConverter<string, PayloadType16>(),
            new ApiEnumConverter<string, Type16>(),
            new ApiEnumConverter<string, PayloadType17>(),
            new ApiEnumConverter<string, Type17>(),
            new ApiEnumConverter<string, PayloadType18>(),
            new ApiEnumConverter<string, Type18>(),
            new ApiEnumConverter<string, PayloadType19>(),
            new ApiEnumConverter<string, Type19>(),
            new ApiEnumConverter<string, PayloadType20>(),
            new ApiEnumConverter<string, Type20>(),
            new ApiEnumConverter<string, PayloadType21>(),
            new ApiEnumConverter<string, Type21>(),
            new ApiEnumConverter<string, PayloadType22>(),
            new ApiEnumConverter<string, Type22>(),
            new ApiEnumConverter<string, PayloadType23>(),
            new ApiEnumConverter<string, Type23>(),
            new ApiEnumConverter<string, PayloadType24>(),
            new ApiEnumConverter<string, Type24>(),
            new ApiEnumConverter<string, PayloadType25>(),
            new ApiEnumConverter<string, Type25>(),
            new ApiEnumConverter<string, PayloadType26>(),
            new ApiEnumConverter<string, Type26>(),
            new ApiEnumConverter<string, PayloadType27>(),
            new ApiEnumConverter<string, Type27>(),
            new ApiEnumConverter<string, PayloadType28>(),
            new ApiEnumConverter<string, Type28>(),
            new ApiEnumConverter<string, PayloadType29>(),
            new ApiEnumConverter<string, Type29>(),
            new ApiEnumConverter<string, PayloadType30>(),
            new ApiEnumConverter<string, Type30>(),
            new ApiEnumConverter<string, PayloadType31>(),
            new ApiEnumConverter<string, Type31>(),
            new ApiEnumConverter<string, PayloadType32>(),
            new ApiEnumConverter<string, Type32>(),
            new ApiEnumConverter<string, PayloadType33>(),
            new ApiEnumConverter<string, Type33>(),
            new ApiEnumConverter<string, PayloadType34>(),
            new ApiEnumConverter<string, Type34>(),
            new ApiEnumConverter<string, PayloadType35>(),
            new ApiEnumConverter<string, Type35>(),
            new ApiEnumConverter<string, PayloadType36>(),
            new ApiEnumConverter<string, Type36>(),
            new ApiEnumConverter<string, PayloadType37>(),
            new ApiEnumConverter<string, Type37>(),
            new ApiEnumConverter<string, PayloadType38>(),
            new ApiEnumConverter<string, Type38>(),
            new ApiEnumConverter<string, PayloadType39>(),
            new ApiEnumConverter<string, Type39>(),
            new ApiEnumConverter<string, PayloadType40>(),
            new ApiEnumConverter<string, Type40>(),
            new ApiEnumConverter<string, WebhookEvents::WebhookEventType>(),
            new ApiEnumConverter<string, WebhookEvents::PayloadType>(),
            new ApiEnumConverter<string, WebhookEvents::PayloadTypeModel>(),
            new ApiEnumConverter<string, WebhookEvents::PayloadType1>(),
            new ApiEnumConverter<string, WebhookEvents::PayloadType2>(),
            new ApiEnumConverter<string, WebhookEvents::PayloadType3>(),
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
