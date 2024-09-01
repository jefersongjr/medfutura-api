# Medfutura API

## 🚀 Resumo: 

Esse projeto, foi desenvolvido como desafio técnico para o processo seletivo da empresa [Medfutura](https://www.medfutura.com.br/). O objetivo do desafio era criar uma API REST para o cadastro de pessoas, com operações de criação, consulta, atualização e exclusão de pessoas. A aplicação foi construída utilizando C#, Dotnet, Postgres e Docker.

### 📋 Pré-requisitos:

Inicialmente você precisará ter instalados:

```
*Docker version 27.0.3
*Docker Compose version v2.5.0
```

### 🔧 Rodando o Projeto localmente:

<details>

  <summary> Clique para ver o passo a passo da instalação </summary>
    
  ### 1- Clone o repositório :

ex:
```bash
git clone https://github.com/jefersongjr/weesu-api.git

```
### 2- navegue até o diretório do `/weesu/frontend` :

ex:
```
cd /medfutura-api
```
### 3- Inicie o container Docker com o comando:


```bash
docker-compose up --build
```

### Docker montará todas as dependências necessárias para o projeto, nesse ponto a API estará pronta para uso.
</details>

## Rotas ◀️➡️ : 

<details>

  <summary> Clique para ver todas as rotas da API </summary>

  ## Rota Post `http://localhost:5231/pessoa`

  Você precisará ter uma entrada válida nesse formato:

  ```json
  
  {
  "apelido": "angel",
  "nome": "Angela Schrute",
  "nascimento": "1970-01-20",
  "stack": [
    "Java",
    "C#",
    "PostgreSQL"
  ]
}
  ```
E receberá o status `201 Created` e a resposta: 

  ```json
  
  {
  "id": 6,
  "apelido": "angel",
  "nome": "Angela Schrute",
  "nascimento": "1970-01-20",
  "stack": [
    "Java",
    "C#",
    "PostgreSQL"
  ]
}
  ```

Em caso de uma requisição mal construída: 

```json
{
  "apelido": "angel",
  "nome": "Angela Schrute",
  "stack": [
    "Java",
    "C#",
    "PostgreSQL"
  ]
}

```
A api retornará o status `422 Unprocessable Entity` e a mensagem `Campos obrigatórios ausentes ou inválidos.`
Para outros erros ela retornará o status `400`.

  ## Rota Get `http://localhost:5231/pessoa/:id`

  Usando a Rota ex: http://localhost:5231/pessoa/2 , a API retornará um status `200 ok` e a resposta: 

```json
{
  "id": 2,
  "apelido": "jimhalpert",
  "nome": "Jim Halpert",
  "nascimento": "1980-10-01",
  "stack": [
    "JavaScript",
    "React",
    "Node.js"
  ]
}
```

Caso seja usado um id que não existe no banco de dados será lançado o status `404 Not Found` e a resposta `Pessoa não encontrada.`.

  ## Rota Get `http://localhost:5231/pessoa?t={termo}`
  
  Usando a Rota ex: http://localhost:5231/pessoa/2 , a API retornará um status `200 ok` e a resposta: 

```json
[
  {
    "id": 4,
    "apelido": "michael",
    "nome": "Michael Scott",
    "nascimento": "1964-03-15",
    "stack": [
      "PHP",
      "MySQL",
      "Laravel"
    ]
  }
]
```
Caso seja usado um termo que não existe no banco de dados a api responderá com um array vazio ` [] `.

  ## Rota Put `http://localhost:5231/pessoa/:id`

Você precisará alterar o campo que desejar :

Antes: 
```json
{
  "apelido": "ryanhowardo",
  "nome": "Ryan Howard",
  "nascimento": "1984-11-05",
  "stack": [
    "Ruby",
    "Rails",
    "SQLite"
  ]
}
```

Alterado no `http://localhost:5231/pessoa/5` : 

```json
{
  "apelido": "kingryan",
  "nome": "Ryan Howard",
  "nascimento": "1984-11-05",
  "stack": [
    "Ruby",
    "Rails",
    "SQLite"
  ]
}
```
A API retornará um status `200 OK` e a resposta: 

```json
{
  "id": 5,
  "apelido": "kingryan",
  "nome": "Ryan Howard",
  "nascimento": "1984-11-05",
  "stack": [
    "Ruby",
    "Rails",
    "SQLite"
  ]
}
```
  ## Rota Delete `http://localhost:5231/pessoa/:id` :

Ao fazer a requisição delete para a rota http://localhost:5231/pessoa/3 a api retornará o Status `204 No Content` se a requisição for válida.
 Caso seja usado um id que não consta no banco de dados, Ex: `http://localhost:5231/pessoa/78` a resposta será um status `400 Bad Request`
  e a resposta `Não foi possível excluir a pessoa. O ID pode não existir.`


</details>

## 🛠️ Construído com

* - C#
* - Dotnet
* - Entity Framework Core
* - PostgreSQL
* - Docker

## ✒️ Autor

* **Jeferson Gomes** - *Trabalho Inicial* - [LinkedIn](https://www.linkedin.com/in/jefersongjr/)

## 📄 Licença

Este projeto está sob a licença (sua licença) - veja o arquivo [LICENSE.md](https://github.com/jefersongjr/weesu-api/blob/main/LICENSE.md) para detalhes.
