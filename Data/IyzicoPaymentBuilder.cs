﻿namespace Nop.Plugin.Payments.Iyzico.Data
{
    using System.Data;
    using FluentMigrator;
    using FluentMigrator.Builders.Create.Table;
    using Nop.Core.Domain.Customers;
    using Nop.Data.Extensions;
    using Nop.Data.Mapping.Builders;
    using Nop.Plugin.Payments.Iyzico.Domain;

    public class IyzicoPaymentBuilder : NopEntityBuilder<IyzicoPayment>
    {
        /// <summary>
        /// Apply entity IyzicoPayment
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .InSchema(IyzicoDefaults.DB_PAYMENT_SCHEMA)
                //map the primary key (not necessary if it is Id field)
                .WithColumn(nameof(IyzicoPayment.Id)).AsInt32().Identity().PrimaryKey()
                //map the additional properties as foreign keys
                .WithColumn(nameof(IyzicoPayment.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: Rule.Cascade)
                .WithColumn(nameof(IyzicoPayment.BasketId)).AsString(50).NotNullable().Indexed()
                .WithColumn(nameof(IyzicoPayment.PaymentId)).AsString(50).NotNullable()
                .WithColumn(nameof(IyzicoPayment.Amount)).AsDecimal().NotNullable()
                .WithColumn(nameof(IyzicoPayment.Installment)).AsInt32().Nullable()
                .WithColumn(nameof(IyzicoPayment.CreatedOnUtc)).AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            ;
        }
    }
}
