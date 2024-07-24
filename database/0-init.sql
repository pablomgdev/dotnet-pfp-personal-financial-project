-- CREATE DATABASE "pfp-operations-database"
--     WITH
--     OWNER = postgres
--     ENCODING            = 'UTF8'
--     -- Docker gives error because in the postgres image es_ES.UTF-8 does not exist (locale -a)
--     LC_COLLATE          = 'es_ES.UTF-8'
--     LC_CTYPE            = 'es_ES.UTF-8'
--     LOCALE_PROVIDER     = 'libc'
--     TABLESPACE          = pg_default
--     CONNECTION LIMIT    = -1
--     IS_TEMPLATE         = False;

CREATE TABLE "operations" (
  "id" UUID PRIMARY KEY,
  "internal_id" integer UNIQUE,
  "amount" numeric,
  "description" varchar(255),
  "is_split" bit,
  "operation_not_split_internal_id" bit,
  "created_date" timestamp,
  "updated_date" timestamp,
  "is_deleted" bit,
  "deleted_date" timestamp,
  "user_id" UUID
);

CREATE TABLE "categories" (
  "id" integer PRIMARY KEY,
  "name" varchar(50) UNIQUE,
  "created_date" timestamp,
  "updated_date" timestamp,
  "is_deleted" bit,
  "deleted_date" timestamp,
  "user_id" UUID
);

CREATE TABLE "operations_categories" (
  "operation_internal_id" integer,
  "category_id" integer,
  PRIMARY KEY ("operation_internal_id", "category_id"),
  CONSTRAINT fk__operations_categories__operation_internal_id__operations FOREIGN KEY ("operation_internal_id") REFERENCES "operations" ("internal_id"),
  CONSTRAINT fk__operations_categories__category_id__categories FOREIGN KEY ("category_id") REFERENCES "categories" ("id")
);

CREATE TABLE "periodicities" (
  "id" integer PRIMARY KEY,
  "operation_internal_id" integer,
  "name" varchar(50),
  "created_date" timestamp,
  "updated_date" timestamp,
  "is_deleted" bit,
  "deleted_date" timestamp,
  "user_id" UUID,
  CONSTRAINT fk__periodicities__operation_internal_id__operations FOREIGN KEY ("operation_internal_id") REFERENCES "operations" ("internal_id")
);

CREATE TABLE "accounts" (
  "id" UUID PRIMARY KEY,
  "internal_id" integer UNIQUE,
  "name" varchar(50) UNIQUE,
  "description" varchar(255),
  "total_amount" numeric,
  "created_date" timestamp,
  "updated_date" timestamp,
  "is_deleted" bit,
  "deleted_date" timestamp,
  "user_id" UUID
);

CREATE TABLE "accounts_categories" (
  "account_internal_id" integer,
  "category_id" integer,
  PRIMARY KEY ("account_internal_id", "category_id"),
  CONSTRAINT fk__accounts_categories__account_internal_id__accounts FOREIGN KEY ("account_internal_id") REFERENCES "accounts" ("internal_id"),
  CONSTRAINT fk__accounts_categories__category_id__categories FOREIGN KEY ("category_id") REFERENCES "categories" ("id")
);

CREATE TABLE "limits" (
  "id" UUID PRIMARY KEY,
  "internal_id" integer UNIQUE,
  "category_id" integer,
  "amount" numeric,
  "created_date" timestamp,
  "updated_date" timestamp,
  "is_deleted" bit,
  "deleted_date" timestamp,
  "user_id" UUID,
  CONSTRAINT fk__limits__category_id__categories FOREIGN KEY ("category_id") REFERENCES "categories" ("id")
);
