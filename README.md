##### - Back-end => C# - Repositório para estudos, dúvidas, práticas ou testes.

---

- ### Projetos nesse repositório :

=> &nbsp;&nbsp; \* advanced*concepts <br>
=> &nbsp;&nbsp; \* asp.net-identity <br>
=> &nbsp;&nbsp; \* fullstack <br>
=> &nbsp;&nbsp; \* hackerrank <br>
=> &nbsp;&nbsp; \* net_rabbitmq <br>
=> &nbsp;&nbsp; \* oop_advanced <br>
=> &nbsp;&nbsp; \* resolva_o_bug <br>
=> &nbsp;&nbsp; \* test_driven_development <br>
=> &nbsp;&nbsp; \* tips*.net_devs <br>
=> &nbsp;&nbsp; \* tokes-jwt <br>
=> &nbsp;&nbsp; \* valida_cpf_cnpj <br>

- => Laboratorio de Testes - projeto para praticar testes unitários.
- => Testando entidades no DDD.
- => Teste unitários, XUnit, Fluent Assertions.
- => Logica Exercicios - para praticar lógica e outras coisas.

- #### Conteúdos :
- POO - Programação Orientada a Objetos.
- Padrões Design Patterns
- Padrões SOLID
- Docker(containerização).
- Expressões Lambadas.
- Cultura de testes, para aplicações em cenário real.
- Automação de issues workflows com enumeração de tickets(#00000)

- ### ==> Padrões de Projetos (Design Patterns)
- Factory Method -> (Criacional) : Oferece uma interface para criar objetos, permitindo que subclasses decidam qual classe concreta será instanciada, usar quando você não quer depender diretamente de classes concretas.
- Decorator Pattern -> (Estrutural) : Extender funcionalidades de um objeto sem modificar seu código-fonte original, usar quando precisa seguir o princípio aberto/fechado (Open/Closed Principle - SOLID)
- Facade Pattern -> (Estrutural) : Fornece uma interface simplificada para um conjunto complexo de subsistemas, expondo apenas uma API simples para os clientes.
- Abstract Factory -> (Criacional) : fornecer uma interface para criar famílias de objetos relacionados sem especificar suas classes concretas, uma camada de abstração para a criação de objetos, seguindo o princípio Aberto/Fechado do SOLID.
- Observer Pattern -> (Comportamental) : define uma dependência um-para-muitos entre objetos, de forma que quando um objeto muda de estado, todos os seus observadores são notificados automaticamente. Objetivo criar um sistema de notificação automática.
- Adapter Pattern -> (Estrutural) : objetivo é permitir que duas interfaces incompatíveis trabalhem juntas ou exemplo: quando você precisa integrar um sistema legado com um sistema novo.
- Builder Pattern -> (Criacional) : permite a criação de diferentes representações de um objeto utilizando o mesmo código de construção. Objeto precisa ser criado passo a passo. Objetivo é separar a construção de um objeto complexo de sua representação, usar quando há a necessidade de criar diferentes variações do mesmo objeto sem poluir o código com muitos construtores sobrecarregados.

- ### ==> S.O.L.I.D
- -> (S) Single Responsibility Principle - Cada classe deve ter uma única responsabilidade no sistema, e apenas uma razão para mudar.
- -> (O) Open/Closed Principle - As classes devem estar "abertas para extensão, mas fechada para modificação". Novas funcionalidades só através de extensões.
- -> (L) Liskov Substitution Principle - Objetos de uma classe derivada devem poder substituir objetos de sua classe base sem alterar a funcionalidade do programa. Quando você cria uma subclasse, ela deve manter o contrato da classe base. Confiabiliade polimorfismo seguro.
- -> (I) Interface Segregation Principle - Cliente não deve ser forçado a depender de métodos que não utiliza. Objetivo é evitar interfaces grandes e genéricas demais. Dividir em interfaces menores e mais específicas, conforme a responsabilidade da classe.
- -> (D) Dependency Inversion Principle - Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações. Abstrações não devem depender de detalhes. Detalhes devem depender de abstrações. Objetivo é reduzir o acoplamento entre os módulos do sistema.

- ### ==> Laboratorio de Testes
- -> DevLabs.API - para experimentar testes unitário.
- -> Testando entidades no DDD - As entidades no (Domain-Driven Design) são mais do que apenas classes elas encapsulam comportamento e regras de negócio que precisam ser validadas corretamente.
- -> Testes Unitários com XUnit - framework de testes automatizados para projetos .NET C# mais usado no momento, desenvolver escrever, organizar e executar testes unitários no código.
