-- ALL IS COMMENTED AS DATABASE MIGRATIONS ARE USED (SEE INFRASTRUCTURE PROJECT).

-- -- CREATE DATABASE "pfp-transactions-database"
-- --     WITH
-- --     OWNER = postgres
-- --     ENCODING            = 'UTF8'
-- --     -- Docker gives error because in the postgres image es_ES.UTF-8 does not exist (locale -a)
-- --     LC_COLLATE          = 'es_ES.UTF-8'
-- --     LC_CTYPE            = 'es_ES.UTF-8'
-- --     LOCALE_PROVIDER     = 'libc'
-- --     TABLESPACE          = pg_default
-- --     CONNECTION LIMIT    = -1
-- --     IS_TEMPLATE         = False;
-- 
-- CREATE TABLE "transactions"
-- (
--     "id"                                UUID PRIMARY KEY,
--     "internal_id"                       integer UNIQUE,
--     "amount"                            numeric,
--     "description"                       varchar(255),
--     "is_split"                          bit,
--     "transaction_not_split_internal_id" bit,
--     "created_date"                      timestamp,
--     "updated_date"                      timestamp,
--     "is_deleted"                        bit,
--     "deleted_date"                      timestamp,
--     "user_id"                           UUID
-- );
-- 
-- CREATE TABLE "categories"
-- (
--     "id"           integer PRIMARY KEY,
--     "name"         varchar(50) UNIQUE,
--     "created_date" timestamp,
--     "updated_date" timestamp,
--     "is_deleted"   bit,
--     "deleted_date" timestamp,
--     "user_id"      UUID
-- );
-- 
-- CREATE TABLE "transactions_categories"
-- (
--     "transaction_internal_id" integer,
--     "category_id"             integer,
--     PRIMARY KEY ("transaction_internal_id", "category_id"),
--     CONSTRAINT fk__transactions_categories__transaction_internal_id__transaction FOREIGN KEY ("transaction_internal_id") REFERENCES "transactions" ("internal_id"),
--     CONSTRAINT fk__transactions_categories__category_id__categories FOREIGN KEY ("category_id") REFERENCES "categories" ("id")
-- );
-- 
-- CREATE TABLE "recurrences"
-- (
--     "id"                      integer PRIMARY KEY,
--     "transaction_internal_id" integer,
--     "name"                    varchar(50),
--     "created_date"            timestamp,
--     "updated_date"            timestamp,
--     "is_deleted"              bit,
--     "deleted_date"            timestamp,
--     "user_id"                 UUID,
--     CONSTRAINT fk__recurrences__transaction_internal_id__transaction FOREIGN KEY ("transaction_internal_id") REFERENCES "transactions" ("internal_id")
-- );
-- 
-- CREATE TABLE "funds"
-- (
--     "id"           UUID PRIMARY KEY,
--     "internal_id"  integer UNIQUE,
--     "name"         varchar(50) UNIQUE,
--     "description"  varchar(255),
--     "total_amount" numeric,
--     "created_date" timestamp,
--     "updated_date" timestamp,
--     "is_deleted"   bit,
--     "deleted_date" timestamp,
--     "user_id"      UUID
-- );
-- 
-- CREATE TABLE "funds_categories"
-- (
--     "fund_internal_id" integer,
--     "category_id"      integer,
--     PRIMARY KEY ("fund_internal_id", "category_id"),
--     CONSTRAINT fk__funds_categories__fund_internal_id__funds FOREIGN KEY ("fund_internal_id") REFERENCES "funds" ("internal_id"),
--     CONSTRAINT fk__funds_categories__category_id__categories FOREIGN KEY ("category_id") REFERENCES "categories" ("id")
-- );
-- 
-- CREATE TABLE "limits"
-- (
--     "id"           UUID PRIMARY KEY,
--     "internal_id"  integer UNIQUE,
--     "category_id"  integer,
--     "amount"       numeric,
--     "created_date" timestamp,
--     "updated_date" timestamp,
--     "is_deleted"   bit,
--     "deleted_date" timestamp,
--     "user_id"      UUID,
--     CONSTRAINT fk__limits__category_id__categories FOREIGN KEY ("category_id") REFERENCES "categories" ("id")
-- );


-- Example data:
INSERT INTO funds(
    id, name, description, total_amount, created_date, updated_date, is_deleted, deleted_date, user_id)
VALUES (gen_random_uuid(), 'Gastos esenciales', 'Gastos fijos y otros esenciales', 123.9, now(), now(), false, null, null);

INSERT INTO categories(
    name, created_date, updated_date, is_deleted, deleted_date, user_id, limit_id, fund_id)
VALUES ('Gastos fijos', now(), now(), false, null, null, null, (SELECT "id" FROM funds WHERE internal_id = 1));

INSERT INTO transactions(
    id, amount, description, recurrence_id, is_split, transaction_not_split_internal_id, created_date, updated_date, is_deleted, deleted_date, user_id, category_id)
VALUES (gen_random_uuid(), 89.45, 'Compra de la semana', null, false, null, now(), now(), false, null, null, 1);

INSERT INTO recurrence_types(name)
VALUES ('Daily'), ('Weekly'), ('Monthly');

INSERT INTO recurrences(recurrence_type_id, created_date, updated_date, is_deleted, deleted_date, user_id)
VALUES (1, now(), now(), false, null, null);

INSERT INTO transactions(
    id, amount, description, recurrence_id, is_split, transaction_not_split_internal_id, created_date, updated_date, is_deleted, deleted_date, user_id, category_id)
VALUES (gen_random_uuid(), 34.45, 'Salida al cine', 1, true, null, now(), now(), false, null, null, 1);

INSERT INTO transactions(
    id, amount, description, recurrence_id, is_split, transaction_not_split_internal_id, created_date, updated_date, is_deleted, deleted_date, user_id, category_id)
VALUES (gen_random_uuid(), 32.45, 'Salida al cine 2', 1, true, 2, now(), now(), false, null, null, 1);

INSERT INTO transactions(
    id, amount, description, recurrence_id, is_split, transaction_not_split_internal_id, created_date, updated_date, is_deleted, deleted_date, user_id, category_id)
VALUES (gen_random_uuid(), 2.0, 'Salida al cine 3', 1, true, 2, now(), now(), false, null, null, 1);
