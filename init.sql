-- dotnet ef migrations add rename
-- dotnet ef database update

INSERT INTO public.clients(
	surname, name, middle_name, email)
	VALUES ('Белоусов', 'Сергей', 'Леонидович', 'belousov2501@gmail.com');

INSERT INTO public.clients(
	surname, name, middle_name, email)
	VALUES ('Кольба', 'Андрей', 'Иванович', 'akolba@mail.ru');

INSERT INTO public.clients(
	surname, name, middle_name, email)
	VALUES ('Романова', 'Анастасия', 'Андреевна', 'romanova@parusyug.ru');

INSERT INTO public.clients(
	surname, name, middle_name, email)
	VALUES ('Пекшев', 'Роман', ',Борисович', 'rp@parusyug.ru');

INSERT INTO public.clients(
	surname, name, middle_name, email)
	VALUES ('Якубин', 'Виталий', ',Николаевич', 'Yakybin@parusyug.ru');

INSERT INTO public.training_programs(
	name)
	VALUES ('C# Developer. Professional');

INSERT INTO public.training_programs(
	name)
	VALUES ('Highload Architect');

INSERT INTO public.training_programs(
	name)
	VALUES ('Software Architect');

INSERT INTO public.training_programs(
	name)
	VALUES ('Microservice Architecture');

INSERT INTO public.training_programs(
	name)
	VALUES ('DevOps практики и инструменты');

INSERT INTO public.trainings(
	start_date_training, end_date_training, date_issue_certificates, "TrainingProgramId")
	VALUES ('2021-03-30', '2021-09-15', '2021-09-15', (SELECT id FROM public.training_programs where name='Microservice Architecture'));

INSERT INTO public.trainings(
	start_date_training, end_date_training, date_issue_certificates, "TrainingProgramId")
	VALUES ('2021-12-23', '2021-05-15', '2021-05-15', (SELECT id FROM public.training_programs where name='Microservice Architecture'));

INSERT INTO public.trainings(
	start_date_training, end_date_training, date_issue_certificates, "TrainingProgramId")
	VALUES ('2021-10-14', '2022-05-26', '2022-05-26', (SELECT id FROM public.training_programs where name='C# Developer. Professional'));

INSERT INTO public.trainings(
	start_date_training, end_date_training, date_issue_certificates, "TrainingProgramId")
	VALUES ( '2022-03-12', '2022-08-19', '2022-08-19', (SELECT id FROM public.training_programs where name='Software Architect'));

INSERT INTO public.trainings(
	start_date_training, end_date_training, date_issue_certificates, "TrainingProgramId")
	VALUES ('2021-11-30', '2022-04-05', '2022-04-05', (SELECT id FROM public.training_programs where name='DevOps практики и инструменты'));

INSERT INTO public.client_trainings(
	"TrainingId", "ClientId")
	VALUES ((SELECT t.id
	FROM public.trainings t,
	     public.training_programs ti
	 where t.start_date_training = '2021-03-30' and t."TrainingProgramId"=ti.id and ti.name = 'Microservice Architecture'), 
    (SELECT id FROM public.clients where email='belousov2501@gmail.com'));

INSERT INTO public.client_trainings(
	"TrainingId", "ClientId")
	VALUES ((SELECT t.id
	FROM public.trainings t,
	     public.training_programs ti
	 where t.start_date_training = '2021-10-14' and t."TrainingProgramId"=ti.id and ti.name = 'C# Developer. Professional'), 
    (SELECT id FROM public.clients where email='belousov2501@gmail.com'));

INSERT INTO public.client_trainings(
	"TrainingId", "ClientId")
	VALUES ((SELECT t.id
	FROM public.trainings t,
	     public.training_programs ti
	 where t.start_date_training = '2021-03-30' and t."TrainingProgramId"=ti.id and ti.name = 'Microservice Architecture'), 
    (SELECT id FROM public.clients where email='akolba@mail.ru'));

INSERT INTO public.client_trainings(
	"TrainingId", "ClientId")
	VALUES ((SELECT t.id
	FROM public.trainings t,
	     public.training_programs ti
	 where t.start_date_training = '2021-03-30' and t."TrainingProgramId"=ti.id and ti.name = 'Microservice Architecture'), 
    (SELECT id FROM public.clients where email='romanova@parusyug.ru'));

INSERT INTO public.client_trainings(
	"TrainingId", "ClientId")
	VALUES ((SELECT t.id
	FROM public.trainings t,
	     public.training_programs ti
	 where t.start_date_training = '2021-03-30' and t."TrainingProgramId"=ti.id and ti.name = 'Microservice Architecture'), 
    (SELECT id FROM public.clients where email='rp@parusyug.ru'));