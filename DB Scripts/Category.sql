-- Table: public.category

DROP TABLE public.category;

CREATE TABLE public.category
(
	categoryId serial PRIMARY KEY,
	categoryName VARCHAR (50) UNIQUE NOT NULL
)
TABLESPACE pg_default;

ALTER TABLE public.category
    OWNER to postgres;
	
-- INSERT DATA
INSERT INTO public.category (categoryName)
VALUES ('uncategorised')