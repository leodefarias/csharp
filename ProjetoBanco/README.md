# Projeto Banco Digital — FIAP 3ESPX

## 1. Identificação

| Nome | RM |
|---|---|
| Leonardo de Farias | 555211 |
| Gustavo Laur | 556603 |

---

## 2. Produto Bancário Escolhido

**Empréstimo**

Justificativa: o produto Empréstimo permite implementar uma regra de negócio clara e mensurável — a análise de crédito via score — que determina de forma automática a aprovação ou reprovação da contratação e a taxa de juros aplicada. Isso atende o escopo extra exigido para dupla sem adicionar complexidade desnecessária.

**Regra de negócio (score de crédito):**

| Score | Resultado | Taxa de Juros |
|---|---|---|
| 0 – 300 | Reprovado | — |
| 301 – 600 | Aprovado | 5% ao mês |
| 601 – 1000 | Aprovado | 3% ao mês |

O score é calculado a partir do hash do CPF (Pessoa Física) ou CNPJ (Pessoa Jurídica) do cliente no momento da contratação.

---

## 3. Diagrama de Classes

> Arquivo fonte: `docs/diagrama-classes.puml` (PlantUML). Importe no [draw.io](https://app.diagrams.net) via **Extras → Edit Diagram** e exporte como PNG para a entrega.

---

## 4. Endpoints Disponíveis

### POST `/api/agencias`
Cadastra uma nova agência.

**Request:**
```json
{
  "nomeAgencia": "Agência Centro",
  "endereco": "Av. Paulista",
  "numero": "1000",
  "cidade": "Sao Paulo",
  "estado": "SP"
}
```

**Response 201:**
```json
{
  "idAgencia": 1,
  "nomeAgencia": "Agência Centro",
  "endereco": "Av. Paulista",
  "numero": "1000",
  "cidade": "Sao Paulo",
  "estado": "SP"
}
```

---

### GET `/api/agencias/{id}`
Busca agência por ID.

- **200** — agência encontrada
- **404** — agência não encontrada

---

### POST `/api/produtos/emprestimo`
Cadastra um produto do tipo Empréstimo.

**Request:**
```json
{
  "nome": "Empréstimo Pessoal",
  "descricao": "Empréstimo para pessoa física e jurídica",
  "valorMinimo": 1000.00,
  "valorMaximo": 50000.00,
  "taxaJuros": 0
}
```

**Response 201:**
```json
{
  "idProduto": 1,
  "nome": "Empréstimo Pessoal",
  "descricao": "Empréstimo para pessoa física e jurídica",
  "valorMinimo": 1000.00,
  "valorMaximo": 50000.00,
  "taxaJuros": 0,
  "tipoProduto": "Emprestimo"
}
```

---

### GET `/api/produtos/{id}`
Busca produto por ID.

- **200** — produto encontrado
- **404** — produto não encontrado

---

### POST `/api/clientes/pf`
Cadastra uma pessoa física.

**Request:**
```json
{
  "nome": "Joao Silva",
  "email": "joao@email.com",
  "cpf": "123.456.789-00",
  "dataNascimento": "1990-05-15",
  "agenciaId": 1
}
```

**Response 201:**
```json
{
  "id": 1,
  "nome": "Joao Silva",
  "email": "joao@email.com",
  "cpf": "123.456.789-00",
  "dataNascimento": "1990-05-15T00:00:00",
  "agenciaId": 1,
  "agencia": null,
  "tipoCliente": "PF"
}
```

**Erros:**
- **409 Conflict** — CPF já cadastrado
- **404 Not Found** — Agência não encontrada

---

### POST `/api/clientes/pj`
Cadastra uma pessoa jurídica.

**Request:**
```json
{
  "nome": "Empresa XYZ Ltda",
  "email": "contato@xyz.com",
  "cnpj": "12.345.678/0001-99",
  "razaoSocial": "Empresa XYZ Ltda",
  "agenciaId": 1
}
```

**Response 201:**
```json
{
  "id": 2,
  "nome": "Empresa XYZ Ltda",
  "email": "contato@xyz.com",
  "cnpj": "12.345.678/0001-99",
  "razaoSocial": "Empresa XYZ Ltda",
  "agenciaId": 1,
  "agencia": null,
  "tipoCliente": "PJ"
}
```

**Erros:**
- **409 Conflict** — CNPJ já cadastrado
- **404 Not Found** — Agência não encontrada

---

### GET `/api/clientes/{id}`
Busca cliente por ID (retorna PF ou PJ com dados da agência).

- **200** — cliente encontrado
- **404** — cliente não encontrado

---

### POST `/api/contratacoes`
Solicita a contratação de um produto bancário. O score de crédito é calculado de forma síncrona e o resultado (`Aprovado` / `Reprovado`) já retorna na resposta.

**Request:**
```json
{
  "clienteId": 1,
  "produtoId": 1,
  "valorSolicitado": 15000.00
}
```

**Response 201 — Aprovado:**
```json
{
  "idContratacao": 1,
  "clienteId": 1,
  "produtoId": 1,
  "dataSolicitacao": "2026-05-06T10:30:00",
  "status": "Aprovado",
  "valorSolicitado": 15000.00,
  "observacao": "Aprovado com taxa de 3% ao mês."
}
```

**Response 201 — Reprovado:**
```json
{
  "idContratacao": 2,
  "clienteId": 2,
  "produtoId": 1,
  "dataSolicitacao": "2026-05-06T10:31:00",
  "status": "Reprovado",
  "valorSolicitado": 5000.00,
  "observacao": "Score de crédito insuficiente."
}
```

**Erros:**
- **404 Not Found** — Cliente não encontrado
- **404 Not Found** — Produto não encontrado

---

### GET `/api/contratacoes/{id}`
Consulta status de uma contratação.

- **200** — contratação encontrada
- **404** — contratação não encontrada

---

## 5. Como Executar

### Pré-requisitos
- .NET 8.0 SDK
- Acesso à rede da FIAP (VPN se necessário) para o Oracle

### Executar a API
```bash
cd ProjetoBanco/ProjetoBanco.API
dotnet run
```

Acesse o Swagger em: `https://localhost:{porta}/swagger`

### Aplicar migrations (banco Oracle FIAP)
```bash
cd ProjetoBanco/ProjetoBanco.API
dotnet tool install --global dotnet-ef   # caso não tenha instalado
dotnet ef database update
```

### Ordem de uso recomendada

1. `POST /api/agencias` — crie uma agência
2. `POST /api/produtos/emprestimo` — crie o produto Empréstimo
3. `POST /api/clientes/pf` ou `POST /api/clientes/pj` — cadastre o cliente
4. `POST /api/contratacoes` — solicite a contratação (score calculado automaticamente)
5. `GET /api/contratacoes/{id}` — consulte o resultado

---

## 6. Print do Swagger

> Inserir print do Swagger com pelo menos uma contratação aprovada após rodar a aplicação.
