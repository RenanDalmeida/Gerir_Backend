SELECT 
	u.id as id_usuario,
	u.nome,
	u.email,
	t.id as id_tarefa,
	t.titulo,
	t.descricao,
	t.categoria,
	t.status,
	t.dataentrega
FROM Usuarios u
INNER JOIN Tarefas t on t.usuario_id = u.id WHERE u.id = 'A27AAD7E-B2FE-4B69-A443-DC7871687BDB';

UPDATE Tarefas SET status = 1 WHERE id = 'F1C87161-8AC5-4AF8-AF55-C8DFA51362FF';

SELECT * FROM Tarefas;