# .NET + RabbitMQ com  Mass Transit

Usando o conceito central em arquiteturas orientadas a eventos e sistemas distribuídos, onde componentes independentes se comunicam trocando mensagens por meio do RabbitMQ.

- #### Descrição do funcionamento e objetivo :
- Simulação de uma lista de relatorios.
- "Service Bus" barramento de mensagens.
- Quando fazer uma solicitação do relatorio.
- Publica eventos mensagens do tipo publish.
- Envent Consumer escuta verifica código da mensagem.
- Adiciona solicitação exibindo para o cliente como "Pendente".
- simulação de timer delay "Processando Relatório".
- Após RabbitMQ consumir "Realtório Processado" 


MassTransit com RabbitMQ, o termo Bus se refere ao "Service Bus", ou Barramento de Mensagens. 