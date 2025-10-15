# Projeto Integrador
###### apesar do cenário e de não ter sido exigido :
##### Para este desafio de acordo com as convenções da Microsoft, boas práticas, e com o mercado de trabalho nível sênior utilizei para continuar com práticas avançadas :

- Back-end: ASP.NET Core
- Modelo design DDD alinhado com os padrões (POO, SOLID)
- Clean Architecture
- UnitOfWork
- Fluent API
- Fluent Validation
- MediatR
- CQRS
- Migrations
- Front-end: Angular cli
- Containers: Docker 
- Banco de dados relacionais SQL
- Documentação: Swagger (Swashbuckle.AspNetCore)

### Rodando no servidor com documentação Swagger, possui também mais end-points, mas fiz por exercícios e práticas.
###### hospedado em uma parte gratuita do servidor que dorme quando não acessado aguarde 30 segundos para carregar.
https://prints-control.onrender.com/index.html

###### O projeto já se encontra hospedado rodando no servidor com front-end com a senha disponível para os Professores e Coordenadores :

###### Obs: O projeto fullStack está hospedado em uma parte gratuita do servidor que dorme quando não acessado aguarde 30 segundos para carregar.
###### https://fullstack.b1010code.com.br/

O front-end 'Angular' cli está sendo refatorado e com novas funcionalidade e foi transferido para outro repositório do github para ficar mais limpo, back-end em um repositório e front-end em outro. 
###### https://github.com/gilberto-domingos/prints-control-Front-end

<br/><br/>
<img src="assets/logo.png" width="200" alt="logo">

#### Tema gerador : Controle de Impressões 
 </br>
No Senac é possível realizar impressão de documentos pessoais. Para isso você
deve realizar a compra do cartão de impressão, com o cartão de impressão em
mãos, você deve direcionar ao setor que realiza as impressões e encaminhar para
o e-mail adequado os documentos que deseja imprimir. A impressão só acontece
caso o cartão de impressão ainda tenha a quantidade disponível que a pessoa
deseja realmente imprimir. Senão o aluno deve realizar a compra de um cartão
complementar com mais impressões. Com a quantidade disponível para
impressões, então a pessoa poderá ter seus documentos impressos conforme
solicitado.
Então temos o seguinte problema: </br>
Como melhorar a experiência dos usuários que
desejam realizar a impressão de documentos? </br>
Referências : </br>

- Definição do modelo entidade x relacionamento; </br>
- Criação das tabelas do banco de dados; </br>
- Uso de programação orientada a objetos na construção do código em c#. </br>
- Desenvolvimento do sistema de cadastro para a solução demandada; </br>
 </br>
- UC1: Desenvolver
Sistemas de
Informação.
 </br>
- UC2: Implementar
a Banco de Dados
Uso de programação
orientada a objetos na
construção do código
em c#.
 </br>
- Desenvolvimento dos cadastros do sistema;
 </br>
- Documento com modelo entidade x relacionamento;
 </br>
- Arquivo com os scripts de criação do banco;
 </br>

#### Requisitos do Projeto: Sistema de Controle de Impressões

Criar um sistema que substitui o controle manual de impressões
usado hoje no Senac. Em vez de usar fichas, o sistema será digital. 
</br>
Veja abaixo o
que o sistema precisa fazer:
#### 1. Compra de Impressões
-  Todo aluno começa com zero impressões. </br>
- O aluno pode comprar pacotes de impressões. Existem apenas duas opções
de compra: </br>
- Pacote com 25 impressões  </br>
- Pacote com 50 impressões </br>
- Não pode comprar quantidades diferentes, como 10, 30 ou 40. Só pode
comprar 25 ou 50 de cada vez. </br>
- O aluno pode acumular impressões. Ou seja, mesmo que ainda tenha
impressões sobrando, ele pode comprar mais. </br>
- Exemplo: se o aluno tem 12 impressões e compra mais 25, o novo saldo
será 37 impressões. </br>
- As impressões compradas nunca vencem. Sempre ficam disponíveis até
serem usadas. </br>
- Sempre que realizar uma compra deverá armazenar numa tabela de
histórico.
</br>
#### 2. Impressões Realizadas
- Quando o aluno imprime alguma coisa, o número de páginas impressas é
descontado do saldo. </br>
- Exemplo: se ele tem 20 impressões e imprimir 5 páginas, ficará com 15. </br>
- O sistema só permite imprimir se o aluno tiver saldo suficiente. </br>
- Se tentar imprimir mais do que tem, a impressão não é permitida. </br>
- Sempre que realizar uma impressão deverá armazenar numa tabela de
histórico.
</br>
#### 3. Consulta de Saldo
- O sistema deve permitir consultar o saldo de impressões de todos os alunos. </br>
- Assim, qualquer pessoa pode ver quanto de saldo cada aluno ainda
tem. </br>

#### Fluxo :

1. Cadastrar novo aluno
2. Comprar impressões
3. Realizar impressão
4. Consultar saldo de todos os alunos

#### Comprar Impressões
O aluno pode comprar somente pacotes de 25 ou 50 impressões.
Impressões nunca vencem e podem ser acumuladas.
Mesmo com saldo positivo, o aluno pode comprar mais pacotes.
 </br>
#### Fluxo :
Digite o nome do aluno: </br>
Pacotes disponíveis: 25 ou 50 </br>
Quantas impressões deseja comprar? 
=> [entrada deve ser validada: apenas 25 ou 50 são aceitos]
 </br>
#### Realizar Impressão
Solicita o nome do aluno e a quantidade de páginas a imprimir. </br>
O sistema verifica se há saldo suficiente antes de permitir a impressão.
 </br>
Se não houver saldo, a impressão é bloqueada com uma mensagem de aviso.
#### Fluxo :​
Digite o nome do aluno: </br>
Quantas páginas deseja imprimir? </br>
Resposta possível: </br>
"Impressão realizada com sucesso. </br>
Novo saldo: X impressões." </br>
"Saldo insuficiente. Impressão não realizada." </br>
#### Consultar Saldo de Todos os Alunos
Exibe a lista de todos os alunos cadastrados com seus respectivos saldos:
#### SALDO DE IMPRESSÕES 
João Silva: 37 impressões </br>
Maria Oliveira: 12 impressões </br>
Lucas Ferreira: 0 impressões </br>
Consultar histórico </br>
Solicita o nome do aluno. </br>
O sistema deverá exibir em ordem de data/hora a movimentação realizada. 
#### Fluxo :
- Digite o nome do aluno: </br>
-> Resposta possível Caso não tenha movimentação: </br>
- "Aluno não encontrado ou nenhuma movimentação realizada" </br>
-> Caso tenha movimentação:  
- "Data: dd/MM/yyyy Operação: compra/impressão Quantidade: 01"
- "Data: dd/MM/yyyy Operação: compra/impressão Quantidade: 01"
- "Data: dd/MM/yyyy Operação: compra/impressão Quantidade: 01"

#### Tabelas esperadas
##### Alunos
- Código </br>
- Nome </br>
- Saldo de impressões </br>
##### Compras
- Código </br>
- Aluno </br>
- Data da compra </br>
- Quantidade comprada </br>
##### Impressões
- Código </br>
- Aluno </br>
- Data da impressão </br>
- Quantidade impressa </br>
##### Histórico
- Código </br>
- Aluno </br>
- Data histórico </br>
- Tipo de movimentação: compra ou impressão </br>
- Quantidade movimentada </br> 
- Saldo antes da movimentação </br>
- Saldo após a movimentação </br>
