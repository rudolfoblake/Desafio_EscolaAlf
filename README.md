<h1>Escola Alf</h1>
<h1>Solução do Desafio:</h1>

<p>Para elaboração do desafio, foram utilizados:</p>
<p>-Banco de dados: SQL Server</p>
<p>-Back-End Linguagem: C#</p>
<p>-Back-End Frameworks: ASP.NET Core, EFCore</p>


<h2>WEB API:</h2>

<h3>1.Visão Geral:</h3>

<p>Sistema para cadastro e busca de alunos, provas e gabaritos.</p>
<p>Os registros são cadastrados e buscados no banco de dados SQL Server, feito através de Migrations via api.</p>
<p>A Api é responsável por buscar e cadastrar as informações no banco de dados, também é responsável por efetuar o tratamento das informações recebidas.</p>
<p>As informaçoes são no formato JSON. As requisições da API foram testadas via Postman, verificando o retorno das mesmas.</p>

<h3>2.Models:</h3> O Models possui as classes, cada classe da origem a uma tabela no Banco de Dados.

<h3>3.Controller:</h3> O Controller é responsável pelas funções HTTP que fazem as buscas e alterações no Banco de Dados.

<h3>4.Context:</h3> Contém a classe e interface do repositório com as funções de busca no Banco de Dados. Contém o Contexto com os DBSets para as tabelas no banco de dados.

<h2>Execução da Aplicação</h2>

<h3>1. Pré Requisitos</h3>

.Net e Sql Server

<h3>2.Para criação do banco de dados no SQL Server:</h3>

2.1. Alterar string de conexao na variável ConexaoBase no arquivo appsettings.json para o caminho do banco de dados SQL Server desejado.

2.2 Comandos via console:

Caminho: DesafioEscolaALf/ EscolaAlf_webAPI

dotnet ef migrations add “NomeDaCriacao”
dotnet ef database update

<h3>3.Para executar a aplicação devem-se utilizar os seguintes comandos via console:</h3>

Caminho: DesafioEscolaALf/ EscolaAlf_webAPI
Comando: dotnet watch run

<h3>4.Requisições API</h3>

As requisições GET, POST, PUT, DELETE podem ser feitas via POSTMAN no formato JSON.

Busca de Alunos aprovados:

GET:

 http://localhost:5000/aluno/situacao/aprovado
 
A tabela de alunos também mostra a Média final.

Gabaritos:

POST

Para cadastrar os gabaritos é necessário cadastrar primeiro as questões na tabela Questões e as alternativas na tabela Alternativas.

Respostas dos Alunos:	

POST

Para cadastrar as respostas dos alunos também é necessário utilizar as tabelas Questões e Alternativas.

Questoes:

POST

Para cadastrar as questões, é necessário cadastrar uma Prova e um AlunoProva.
