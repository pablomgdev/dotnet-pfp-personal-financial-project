using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categories_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "funds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    internal_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("funds_pkey", x => x.id);
                    table.UniqueConstraint("AK_funds_internal_id", x => x.internal_id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    internal_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: true),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    is_split = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    transaction_not_split_internal_id = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("transactions_pkey", x => x.id);
                    table.UniqueConstraint("AK_transactions_internal_id", x => x.internal_id);
                });

            migrationBuilder.CreateTable(
                name: "limits",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    internal_id = table.Column<int>(type: "integer", nullable: true),
                    category_id = table.Column<int>(type: "integer", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("limits_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk__limits__category_id__categories",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "funds_categories",
                columns: table => new
                {
                    fund_internal_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("funds_categories_pkey", x => new { x.fund_internal_id, x.category_id });
                    table.ForeignKey(
                        name: "fk__funds_categories__category_id__categories",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk__funds_categories__fund_internal_id__funds",
                        column: x => x.fund_internal_id,
                        principalTable: "funds",
                        principalColumn: "internal_id");
                });

            migrationBuilder.CreateTable(
                name: "recurrences",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    transaction_internal_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_deleted = table.Column<BitArray>(type: "bit(1)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("recurrences_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk__recurrences__transaction_internal_id__transaction",
                        column: x => x.transaction_internal_id,
                        principalTable: "transactions",
                        principalColumn: "internal_id");
                });

            migrationBuilder.CreateTable(
                name: "transactions_categories",
                columns: table => new
                {
                    transaction_internal_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("transactions_categories_pkey", x => new { x.transaction_internal_id, x.category_id });
                    table.ForeignKey(
                        name: "fk__transactions_categories__category_id__categories",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk__transactions_categories__transaction_internal_id__transacti",
                        column: x => x.transaction_internal_id,
                        principalTable: "transactions",
                        principalColumn: "internal_id");
                });

            migrationBuilder.CreateIndex(
                name: "categories_name_key",
                table: "categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "funds_internal_id_key",
                table: "funds",
                column: "internal_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "funds_name_key",
                table: "funds",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funds_categories_category_id",
                table: "funds_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_limits_category_id",
                table: "limits",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "limits_internal_id_key",
                table: "limits",
                column: "internal_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recurrences_transaction_internal_id",
                table: "recurrences",
                column: "transaction_internal_id");

            migrationBuilder.CreateIndex(
                name: "transactions_internal_id_key",
                table: "transactions",
                column: "internal_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_categories_category_id",
                table: "transactions_categories",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funds_categories");

            migrationBuilder.DropTable(
                name: "limits");

            migrationBuilder.DropTable(
                name: "recurrences");

            migrationBuilder.DropTable(
                name: "transactions_categories");

            migrationBuilder.DropTable(
                name: "funds");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}
