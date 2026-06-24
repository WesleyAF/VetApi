🐾 ClinicaVet API

API REST desenvolvida em ASP.NET Core para gerenciamento de uma clínica veterinária, com controle de donos, animais, consultas e veterinários.


📋 Sobre o Projeto

Este projeto foi desenvolvido como prática de arquitetura em camadas com .NET, aplicando conceitos reais do mercado como separação de responsabilidades, DTOs, repositórios genéricos e padronização de respostas.


🚀 Tecnologias Utilizadas


.NET / ASP.NET Core
Entity Framework Core
SQL Server
Swagger / Swashbuckle



🏗️ Arquitetura

O projeto segue uma arquitetura em camadas, separando claramente as responsabilidades:

ClinicaVet/
├── Controllers/        # Recebe as requisições HTTP
├── Services/           # Regras de negócio
├── Repositories/       # Acesso ao banco de dados
├── Models/             # Entidades do domínio
├── Dto/                # Objetos de transferência de dados
├── Mappers/            # Conversão entre Model e DTO
├── Data/               # Configuração do DbContext
└── Program.cs          # Configuração da aplicação

Fluxo de uma requisição

Cliente HTTP
    ↓
Controller  →  valida entrada e chama o Service
    ↓
Service     →  aplica regras de negócio
    ↓
Repository  →  acessa o banco via EF Core
    ↓
SQL Server


📦 Entidades

EntidadeDescriçãoDonoResponsável pelo animalAnimalPertence a um DonoConsultaAtendimento de um AnimalVeterinárioProfissional responsável pela consulta

Relacionamentos

Dono 1 ──── N Animal
Animal 1 ──── N Consulta
Veterinário 1 ──── N Consulta


🔌 Endpoints

👤 Donos

MétodoRotaDescriçãoGET/api/donosLista todos os donosGET/api/donos/{id}Busca dono por IDGET/api/donos/{id}/animaisLista animais de um donoPOST/api/donosCadastra um novo donoPUT/api/donos/{id}Atualiza um donoDELETE/api/donos/{id}Remove um dono

🐶 Animais

MétodoRotaDescriçãoGET/api/animaisLista todos os animaisGET/api/animais/{id}Busca animal por IDGET/api/animais/{id}/consultasHistórico de consultasPOST/api/animaisCadastra um novo animalPUT/api/animais/{id}Atualiza um animalDELETE/api/animais/{id}Remove um animal

🩺 Consultas

MétodoRotaDescriçãoGET/api/consultasLista todas as consultasGET/api/consultas/{id}Busca consulta por IDPOST/api/consultasRegistra uma nova consultaPUT/api/consultas/{id}Atualiza uma consultaDELETE/api/consultas/{id}Remove uma consulta

👨‍⚕️ Veterinários

MétodoRotaDescriçãoGET/api/veterinariosLista todos os veterináriosGET/api/veterinarios/{id}Busca veterinário por IDPOST/api/veterinariosCadastra um veterinárioPUT/api/veterinarios/{id}Atualiza um veterinárioDELETE/api/veterinarios/{id}Remove um veterinário


📐 Padrão de Resposta

Todas as respostas seguem um padrão único através do ApiResponse:

json{
  "dados": { },
  "mensagem": "Operação realizada com sucesso",
  "status": true
}


⚙️ Como Rodar o Projeto

Pré-requisitos


.NET 8 SDK
SQL Server
Git


Passo a passo

1. Clone o repositório

bashgit clone https://github.com/seu-usuario/clinicavet-api.git
cd clinicavet-api

2. Configure a connection string

No arquivo appsettings.json, ajuste a string de conexão:

json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=ClinicaVet;Trusted_Connection=True;"
  }
}

3. Rode as migrations

bashdotnet ef database update

4. Execute a aplicação

bashdotnet run

5. Acesse o Swagger

https://localhost:{porta}/swagger


🧠 Conceitos Aplicados


POO — Herança, encapsulamento e interfaces
Repository Pattern — Repositório genérico IRepository<T> com implementações específicas
Service Layer — Regras de negócio isoladas dos controllers
DTO + Mappers — Separação entre modelo de domínio e modelo de transporte
Injeção de Dependência — Registros via Program.cs e injeção via construtor
Entity Framework Core — ORM com migrations e relacionamentos configurados
ApiResponse Wrapper — Padronização de todas as respostas da API



👨‍💻 Autor

Feito por Wesley Firmino
