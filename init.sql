CREATE TABLE pessoas (
    id SERIAL PRIMARY KEY,
    apelido VARCHAR(32) NOT NULL UNIQUE,
    nome VARCHAR(100) NOT NULL,
    nascimento DATE NOT NULL,
    stack VARCHAR(32)[]
);

INSERT INTO pessoas (apelido, nome, nascimento, stack) 
VALUES ('dwight', 'Dwight Schrute', '1970-01-20', ARRAY['Java', 'C#', 'PostgreSQL']);

INSERT INTO pessoas (apelido, nome, nascimento, stack) 
VALUES ('jimhalpert', 'Jim Halpert', '1980-10-01', ARRAY['JavaScript', 'React', 'Node.js']);

INSERT INTO pessoas (apelido, nome, nascimento, stack) 
VALUES ('pambeesly', 'Pam Beesly', '1982-03-25', ARRAY['HTML', 'CSS', 'Python']);

INSERT INTO pessoas (apelido, nome, nascimento, stack) 
VALUES ('michael', 'Michael Scott', '1964-03-15', ARRAY['PHP', 'MySQL', 'Laravel']);

INSERT INTO pessoas (apelido, nome, nascimento, stack) 
VALUES ('ryanhoward', 'Ryan Howard', '1984-11-05', ARRAY['Ruby', 'Rails', 'SQLite']);
