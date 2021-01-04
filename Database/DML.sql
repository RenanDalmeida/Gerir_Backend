USE Gerir

--Adicionando valores para Usuarios
INSERT INTO Usuarios (id, nome, email, senha, tipo) 
VALUES (NEWID(), 'Renan', 'rdalmeidi@gmail.com', '12345', 'Comum');

INSERT INTO Usuarios 
VALUES (NEWID(), 'Bea', 'beaclaus@gmail.com', '12345', 'Comum');

UPDATE Usuarios SET tipo = 'Comum' WHERE id = '23C58F95-8C8D-45C5-B695-8A05B30B28A6'; 

SELECT * FROM Usuarios
SELECT nome, email FROM Usuarios
------------------------------------------------------------------------------------------
INSERT INTO Tarefas (id, titulo, descricao, categoria, dataentrega, status, usuario_id)
VALUES (NEWID(), 'Tarefa1', 'Descrição da tarefa 1', 'Pessoal', '04-01-2021 18:00:00', 0, 'A27AAD7E-B2FE-4B69-A443-DC7871687BDB');

INSERT INTO Tarefas (id, titulo, descricao, categoria, dataentrega, status, usuario_id)
VALUES (NEWID(), 'Tarefa2', 'Descrição da tarefa 2', 'Pessoal', '04-01-2021 10:55:00', 0, 'A27AAD7E-B2FE-4B69-A443-DC7871687BDB');

INSERT INTO Tarefas (id, titulo, descricao, categoria, dataentrega, status, usuario_id)
VALUES (NEWID(), 'Tarefa1', 'Descrição da tarefa 1', 'Pessoal', '04-01-2021 10:58:00', 0, '23C58F95-8C8D-45C5-B695-8A05B30B28A6');
