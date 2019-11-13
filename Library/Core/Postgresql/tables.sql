-- Table: library.lib_authors

DROP TABLE library.lib_authors;

CREATE TABLE library.lib_authors
(
    author_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    author_name character varying COLLATE pg_catalog."default" NOT NULL,
    author_updated_by integer NOT NULL,
    author_deleted_by integer NOT NULL,
    author_updated_on date NOT NULL,
    author_deleted_on date NOT NULL,
    author_is_deleted boolean NOT NULL,
    CONSTRAINT pk_lib_authors PRIMARY KEY (author_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_authors
    OWNER to library;




-- Table: library.lib_book_locations

DROP TABLE library.lib_book_locations;

CREATE TABLE library.lib_book_locations
(
    book_location_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    section character varying COLLATE pg_catalog."default" NOT NULL,
    shelf character varying COLLATE pg_catalog."default" NOT NULL,
    book_location_updated_by integer NOT NULL,
    book_location_deleted_by integer NOT NULL,
    book_location_updated_on date NOT NULL,
    book_location_deleted_on date NOT NULL,
    book_location_is_deleted boolean NOT NULL,
    CONSTRAINT pk_lib_book_locations PRIMARY KEY (book_location_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_book_locations
    OWNER to library;




-- Table: library.lib_books

DROP TABLE library.lib_books;

CREATE TABLE library.lib_books
(
    book_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    book_name character varying COLLATE pg_catalog."default" NOT NULL,
    author_id integer NOT NULL,
    language_id integer NOT NULL,
    publishing_house_id integer NOT NULL,
    category_id integer NOT NULL,
    book_location_id integer NOT NULL,
    book_updated_by integer NOT NULL,
    book_deleted_by integer NOT NULL,
    book_updated_on date NOT NULL,
    book_deleted_on date NOT NULL,
    book_is_deleted boolean NOT NULL,
    rating integer NOT NULL DEFAULT 0,
    CONSTRAINT pk_lib_books PRIMARY KEY (book_id),
    CONSTRAINT fk_books_author_id FOREIGN KEY (author_id)
        REFERENCES library.lib_authors (author_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_books_category_id FOREIGN KEY (category_id)
        REFERENCES library.lib_categories (category_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_books_language_id FOREIGN KEY (language_id)
        REFERENCES library.lib_languages (language_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_books_location_id FOREIGN KEY (book_location_id)
        REFERENCES library.lib_book_locations (book_location_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_books_publishing_house_id FOREIGN KEY (publishing_house_id)
        REFERENCES library.lib_publishing_houses (publishing_house_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_books
    OWNER to library;




-- Table: library.lib_categories

DROP TABLE library.lib_categories;

CREATE TABLE library.lib_categories
(
    category_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    category_name character varying COLLATE pg_catalog."default" NOT NULL,
    category_updated_by integer NOT NULL,
    category_deleted_by integer NOT NULL,
    category_updated_on date NOT NULL,
    category_deleted_on date NOT NULL,
    category_is_deleted boolean NOT NULL,
    CONSTRAINT pk_lib_categories PRIMARY KEY (category_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_categories
    OWNER to library;




-- Table: library.lib_languages

DROP TABLE library.lib_languages;

CREATE TABLE library.lib_languages
(
    language_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    language_name character varying COLLATE pg_catalog."default" NOT NULL,
    language_updated_by integer NOT NULL,
    language_deleted_by integer NOT NULL,
    language_updated_on date NOT NULL,
    language_deleted_on date NOT NULL,
    language_is_deleted boolean NOT NULL,
    CONSTRAINT pk_lib_languages PRIMARY KEY (language_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_languages
    OWNER to library;




-- Table: library.lib_publishing_houses

DROP TABLE library.lib_publishing_houses;

CREATE TABLE library.lib_publishing_houses
(
    publishing_house_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    publishing_house_name character varying COLLATE pg_catalog."default" NOT NULL,
    publishing_house_updated_by integer NOT NULL,
    publishing_house_deleted_by integer NOT NULL,
    publishing_house_updated_on date NOT NULL,
    publishing_house_deleted_on date NOT NULL,
    publishing_house_is_deleted boolean NOT NULL,
    CONSTRAINT pk_lib_publishing_houses PRIMARY KEY (publishing_house_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_publishing_houses
    OWNER to library;





-- Table: library.lib_rating_histories

DROP TABLE library.lib_rating_histories;

CREATE TABLE library.lib_rating_histories
(
    rating_history_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    user_id integer NOT NULL,
    book_id integer NOT NULL,
    given_rating integer NOT NULL,
    rating_date date NOT NULL,
    rating_history_updated_by integer NOT NULL,
    rating_history_deleted_by integer NOT NULL,
    rating_history_updated_on date NOT NULL,
    rating_history_deleted_on date NOT NULL,
    rating_history_is_deleted boolean NOT NULL,
    CONSTRAINT pk_lib_rating_histories PRIMARY KEY (rating_history_id),
    CONSTRAINT fk_lib_rating_histories_book_id FOREIGN KEY (book_id)
        REFERENCES library.lib_books (book_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_lib_rating_histories_user_id FOREIGN KEY (user_id)
        REFERENCES library.lib_users (user_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_rating_histories
    OWNER to library;





-- Table: library.lib_user_baskets

DROP TABLE library.lib_user_baskets;

CREATE TABLE library.lib_user_baskets
(
    user_basket_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    user_id integer NOT NULL,
    book_id integer NOT NULL,
    pick_up_date date NOT NULL,
    deadline_date date NOT NULL,
    CONSTRAINT pk_lib_baskets PRIMARY KEY (user_basket_id),
    CONSTRAINT fk_lib_user_baskets_book_id FOREIGN KEY (book_id)
        REFERENCES library.lib_books (book_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_lib_user_baskets_user_id FOREIGN KEY (user_id)
        REFERENCES library.lib_users (user_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_user_baskets
    OWNER to library;




-- Table: library.lib_user_histories

DROP TABLE library.lib_user_histories;

CREATE TABLE library.lib_user_histories
(
    user_history_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    book_id integer NOT NULL,
    return_date date NOT NULL,
    user_id integer NOT NULL,
    user_history_updated_by integer NOT NULL,
    user_history_deleted_by integer NOT NULL,
    user_history_updated_on date NOT NULL,
    user_history_deleted_on date NOT NULL,
    user_history_is_deleted boolean NOT NULL,
    pick_up_date date NOT NULL,
    is_returned boolean NOT NULL,
    CONSTRAINT pk_lib_user_histories PRIMARY KEY (user_history_id),
    CONSTRAINT fk_lib_user_histories_book_id FOREIGN KEY (book_id)
        REFERENCES library.lib_books (book_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_lib_user_histories_user_id FOREIGN KEY (user_id)
        REFERENCES library.lib_users (user_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_user_histories
    OWNER to library;




-- Table: library.lib_users

DROP TABLE library.lib_users;

CREATE TABLE library.lib_users
(
    user_id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    user_name character varying COLLATE pg_catalog."default" NOT NULL,
    user_updated_by integer NOT NULL,
    user_deleted_by integer NOT NULL,
    user_updated_on date NOT NULL,
    user_deleted_on date NOT NULL,
    user_is_deleted boolean NOT NULL,
    CONSTRAINT lib_users_pk PRIMARY KEY (user_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE library.lib_users
    OWNER to library;