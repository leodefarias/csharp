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

O score é calculado a partir do CPF (Pessoa Física) ou CNPJ (Pessoa Jurídica) do cliente no momento da contratação.

---

## 3. Diagrama de Classes

> Arquivo fonte: `docs/diagrama-classes.puml` (PlantUML). Importe no [draw.io](https://app.diagrams.net) via **Extras → Edit Diagram** e exporte como PNG para a entrega.

![Diagrama de Classes](docs/diagrama-classes.puml)

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
  "cidade": "São Paulo",
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
  "cidade": "São Paulo",
  "estado": "SP"
}
```

---

### GET `/api/agencias/{id}`
Busca agência por ID. Retorna **404** se não encontrada.

---

### POST `/api/clientes/pf`
Cadastra pessoa física.

**Request:**
```json
{
  "nome": "João da Silva",
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
  "nome": "João da Silva",
  "email": "joao@email.com",
  "cpf": "123.456.789-00",
  "dataNascimento": "1990-05-15T00:00:00",
  "agenciaId": 1,
  "tipoCliente": "PF"
}
```

**Erros:**
- **409 Conflict** — CPF já cadastrado
- **404 Not Found** — Agência não encontrada

---

### POST `/api/clientes/pj`
Cadastra pessoa jurídica.

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
  "tipoCliente": "PJ"
}
```

**Erros:**
- **409 Conflict** — CNPJ já cadastrado
- **404 Not Found** — Agência não encontrada

---

### GET `/api/clientes/{id}`
Busca cliente por ID (retorna PF ou PJ com dados da agência). Retorna **404** se não encontrado.

---

### POST `/api/contratacoes`
Solicita uma contratação de produto bancário. O score de crédito é calculado de forma síncrona e o resultado (Aprovado/Reprovado) já retorna na resposta.

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
Consulta status de uma contratação. Retorna **404** se não encontrada.

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
dotnet ef database update
```

---

## 6. Print do Swagger

> Inserir print do Swagger com pelo menos uma contratação aprovada após rodar a aplicação.
