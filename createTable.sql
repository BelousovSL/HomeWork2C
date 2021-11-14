CREATE TABLE IF NOT EXISTS public.clients
(
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    surname text COLLATE pg_catalog."default",
    name text COLLATE pg_catalog."default",
    middle_name text COLLATE pg_catalog."default",
    email text COLLATE pg_catalog."default",
    date_birth timestamp without time zone,
    CONSTRAINT "PK_clients" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.clients
    OWNER to sergey;

CREATE TABLE IF NOT EXISTS public.training_programs
(
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name text COLLATE pg_catalog."default",
    CONSTRAINT "PK_training_programs" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.training_programs
    OWNER to sergey;

CREATE TABLE IF NOT EXISTS public.trainings
(
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    start_date_training timestamp without time zone NOT NULL,
    end_date_training timestamp without time zone NOT NULL,
    date_issue_certificates timestamp without time zone NOT NULL,
    test_int integer,
    "TrainingProgramId" integer,
    "TestId" integer,
    CONSTRAINT "PK_trainings" PRIMARY KEY (id),
    CONSTRAINT "FK_trainings_test_TestId" FOREIGN KEY ("TestId")
        REFERENCES public.test (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT,
    CONSTRAINT "FK_trainings_training_programs_TrainingProgramId" FOREIGN KEY ("TrainingProgramId")
        REFERENCES public.training_programs (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.trainings
    OWNER to sergey;
-- Index: IX_trainings_TestId

CREATE INDEX IF NOT EXISTS "IX_trainings_TestId"
    ON public.trainings USING btree
    ("TestId" ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: IX_trainings_TrainingProgramId

CREATE INDEX IF NOT EXISTS "IX_trainings_TrainingProgramId"
    ON public.trainings USING btree
    ("TrainingProgramId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public.client_trainings
(
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "TrainingId" integer,
    "ClientId" integer,
    CONSTRAINT "PK_client_trainings" PRIMARY KEY (id),
    CONSTRAINT "FK_client_trainings_clients_ClientId" FOREIGN KEY ("ClientId")
        REFERENCES public.clients (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT,
    CONSTRAINT "FK_client_trainings_trainings_TrainingId" FOREIGN KEY ("TrainingId")
        REFERENCES public.trainings (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.client_trainings
    OWNER to sergey;
-- Index: IX_client_trainings_ClientId

CREATE INDEX IF NOT EXISTS "IX_client_trainings_ClientId"
    ON public.client_trainings USING btree
    ("ClientId" ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: IX_client_trainings_TrainingId

CREATE INDEX IF NOT EXISTS "IX_client_trainings_TrainingId"
    ON public.client_trainings USING btree
    ("TrainingId" ASC NULLS LAST)
    TABLESPACE pg_default;