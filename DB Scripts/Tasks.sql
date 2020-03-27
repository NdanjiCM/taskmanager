-- Table: public.tasks

-- DROP TABLE public.tasks;

CREATE TABLE public.tasks
(
    taskid integer NOT NULL DEFAULT nextval('tasks_taskid_seq'::regclass),
    taskname character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description character varying(50) COLLATE pg_catalog."default",
    duedate character varying(100) COLLATE pg_catalog."default",
    status character varying(20) COLLATE pg_catalog."default",
    categoryid integer,
    CONSTRAINT tasks_pkey PRIMARY KEY (taskid),
    CONSTRAINT tasks_taskname_key UNIQUE (taskname),
    CONSTRAINT tasks_categoryid_fkey FOREIGN KEY (categoryid)
        REFERENCES public.category (categoryid) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE public.tasks
    OWNER to postgres;