#  A Golden Data



  <p align="center">
  <img src="https://github.com/user-attachments/assets/5852c70d-e683-41af-b50b-d41477905e27" alt="Golden Data - Logo" width="200"/>
</p>


Golden Data é uma plataforma inovadora que facilita a troca direta de informações entre empresas e clientes, maximizando a personalização de serviços e campanhas de marketing. Desenvolvida especialmente para o comércio eletrônico, a Golden Data tem como objetivo aprimorar a experiência do cliente e aumentar o retorno sobre investimento (ROI) das empresas por meio de segmentação precisa e conteúdo direcionado.

---

## Integrantes do Projeto

| Nome | Matrícula | Turma |
|------|-----------|-------|
| Gabriel Previ de Oliveira | 98774 | 2TDSPV |
| Gustavo Soares Fosaluza | 97850 | 2TDSPF |
| Mateus Vinicius da Conceição Silva | 551692 | 2TDSPV |
| Pedro Henrique Figueiredo de Oliveira | 552000 | 2TDSPV |
| Vitor da Silva Ruas | 550871 | 2TDSPV |

---

## Visão Geral da Plataforma

### Funcionamento
Golden Data oferece uma plataforma onde clientes compartilham suas preferências de produtos e serviços por meio de pesquisas no aplicativo. Empresas, por sua vez, utilizam essas informações para direcionar ofertas e anúncios de forma mais assertiva, otimizando a comunicação com o público-alvo.

### Planos de Serviço
Golden Data oferece uma versão gratuita para avaliação e dois planos pagos para empresas:

- **Plano Beta**: Acesso completo aos dados dos clientes mediante pagamento.
- **Plano Sócios**: Inclui desconto nos serviços e envio de cupons de desconto diretamente aos clientes.

### Entrega de Cupons
Os cupons de desconto são enviados por e-mail, e ao clicar neles, o cliente é direcionado para a tela de login para resgatar o desconto. Essa abordagem melhora a comunicação e fortalece o relacionamento entre empresas e clientes.

---

## Tecnologias Utilizadas

Golden Data utiliza tecnologias avançadas para fornecer personalização e inteligência em tempo real:

- **Machine Learning**: Análise preditiva e segmentação inteligente dos dados.
- **Deep Analytics**: Insights detalhados sobre o comportamento dos clientes e tendências do mercado.
- **IA Generativa**: Criação de conteúdo personalizado com base nos interesses e comportamentos dos clientes.

Essas tecnologias ajudam as empresas a otimizar campanhas de marketing e gerar conteúdos relevantes para cada perfil de cliente.

---

## Benefícios para as Empresas

- **Aumento da taxa de conversão** com campanhas segmentadas.
- **Melhoria na experiência do cliente** com ofertas no momento ideal.
- **Segmentação avançada** para uma comunicação mais eficiente.
- **Conteúdo personalizado** de acordo com os interesses do público-alvo.
- **Identificação de clientes em risco de churn** com ações preventivas.
- **Otimização da jornada do cliente**, desde o primeiro contato até a conversão.

---

# Projeto Web API .NET Core [ C# ]

## Sistema

A plataforma Golden Data oferece serviços tanto para empresa quanto para os clientes das empresas. Neste projeto, direcionamos nosso foco as empresas. Lidamos com dados dos consumidores: informações pessoais, preferencias de compra, histórico de compras, forma de pagamento e feedbacks. Esses dados são disponibilizados para as empresas que contratam o serviço através da plataforma para Empresas, enquanto a personalização de serviços, fidelização do cliente, descontos, cupons, bonus, promoções são do lado consumidor, clientes que se propuseram participar da nossa pesquisa. Foco desse projeto é na Empresa

## Arquitetura do Sistema

Iniciamos o projeto com uma **arquitetura monolítica** para acelerar o desenvolvimento e validar o produto. No futuro, planeja-se uma **migração para microserviços**, que garantirá escalabilidade e maior flexibilidade para o crescimento da plataforma.

---

## Padrões de Design Utilizados

### Repository Pattern
Utilizado para isolar a lógica de acesso aos dados, facilitando a manutenção e a possibilidade de troca de fontes de dados (como bancos de dados ou APIs externas) sem afetar as demais camadas da aplicação. 

Exemplo: `ApplicationDbContext.cs` gerencia a interação com o banco de dados, e repositórios futuros encapsularão operações CRUD.

### Service Layer Pattern
Manter a lógica de negócios separada da camada de apresentação e da camada de dados promove a reutilização de código e facilita mudanças futuras na lógica de negócios sem impacto direto nas camadas de interface ou persistência de dados.

Exemplo: `ConsumidorService.cs` gerencia a lógica de consumidores, mantendo a camada de controladores livre de lógica complexa.

### Data Transfer Object (DTO)
Utilizamos DTOs para transferir dados entre camadas de forma segura e eficiente, garantindo integridade e evitando o envio de informações desnecessárias. Exemplo: `CriarConsumidorDto.cs` e `EditarConsumidorDto.cs`.

### Vantagens dos Padrões Utilizados

- **Manutenibilidade**: Separação clara de responsabilidades facilita a manutenção e a expansão de funcionalidades.
- **Testabilidade**: A lógica de negócios isolada facilita a criação de testes unitários e de integração.
- **Escalabilidade**: A estrutura modular permite expandir o sistema com baixo impacto no código existente.

## Princípios Utilizados

### Clean Code

- **Legibilidade**: Nomes descritivos como `ListarFeedBacks`, `BuscarFeedbackPorId`, e `CriarFeedback` tornam o código intuitivo.
- **Facilidade de Manutenção**: Métodos com responsabilidade única permitem alterações localizadas.
- **Redução de Erros**: A prática de verificar nulos antes de retornar dados evita exceções.
- **Aumento da Produtividade**: Estrutura clara e organizada facilita a compreensão e o desenvolvimento.
- **Melhor Colaboração**: Interfaces bem definidas promovem trabalho independente entre membros da equipe.

### SOLID

- **Single Responsibility Principle**: Cada método no controller e nos serviços possui uma única responsabilidade.
- **Open/Closed Principle**: O código está aberto a extensões e fechado para modificações, permitindo adicionar novas funcionalidades sem impactar o existente.
- **Liskov Substitution Principle**: O uso de interfaces permite que implementações sejam trocadas sem afetar a lógica do sistema.
- **Interface Segregation Principle**: Interfaces pequenas e focadas garantem que o código seja modular e fácil de entender.
- **Dependency Inversion Principle**: O controller depende de abstrações (interfaces), facilitando a troca de implementações e reduzindo o acoplamento.

## Benefícios

- **Facilidade de Extensão**: Novas funcionalidades podem ser adicionadas sem necessidade de modificar o código existente.
- **Reutilização de Código**: A implementação do padrão de repositório permite que a lógica de acesso a dados seja reutilizada em diferentes partes da aplicação.
- **Flexibilidade e Manutenção**: A separação clara entre camadas promove uma arquitetura que é fácil de modificar.
- **Melhor Testabilidade**: A estrutura modular facilita a criação de testes unitários, aumentando a confiabilidade do sistema.



---

## Guia para Testar a API com Swagger

### Passo 1: Abrir a Interface do Swagger
Após iniciar a API, acesse o **Swagger UI** pelo navegador. A URL será algo como:

https://localhost:7273/swagger/index.html


(O número da porta pode variar conforme o ambiente de execução).

### Passo 2: Explorar os Endpoints
Na interface do **Swagger**, visualize todos os endpoints disponíveis organizados por controladores. Expanda cada endpoint para ver detalhes como método HTTP, parâmetros e respostas.

### Login e Autenticação com token (JWT)

Antes de testar os endpoints, primeiro certifique-se de estar autenticado, caso contrário sua requisição será recusada (401)

![Captura de tela 2024-11-03 165435](https://github.com/user-attachments/assets/c6a5b6db-900f-4ffe-a2a3-ec96cb16613e)--- Tentativa sem autenticação com o token


![Captura de tela 2024-11-03 165554](https://github.com/user-attachments/assets/fa7a7360-efb6-4615-80d6-4130b494782a)--- O erro 401 Unauthorized indica que o acesso ao recurso solicitado foi recusado porque o usuário não está 
autenticado ou a autenticação fornecida não é válida

![Captura de tela 2024-11-03 165725](https://github.com/user-attachments/assets/a7d14f75-21ff-426d-9e31-7dd0bdf70e93)--- Acesse o endpoint login e insira as credenciais que estão sendo exigidas  username: "admin" | password: "gd123"

![Captura de tela 2024-11-03 165809](https://github.com/user-attachments/assets/22a3b9be-b1c6-4167-b22e-a56197c59a79)--- Após executar a requisição, o token será disponibilizado, copie o token

![Captura de tela 2024-11-03 165947](https://github.com/user-attachments/assets/21e6623c-5608-4204-9eb3-ef48c5fa739c)--- No canto superior direito da interface do Swagger voce encontrará um botão [Authorize] clique no botão

![Captura de tela 2024-11-03 175850](https://github.com/user-attachments/assets/f7280534-4360-49bb-8496-f26bf3edf544)--- Insira no campo a palavra Bearer e cole o token que voce copiou e em seguida clique em [Authorize]

![Captura de tela 2024-11-03 170051](https://github.com/user-attachments/assets/07cc3db6-1372-4e7a-ba27-eb77de32e616)--- Aqui é mostrado a autorização disponível para uso

![Captura de tela 2024-11-03 170207](https://github.com/user-attachments/assets/8e4aa2d0-3b61-47d7-8ce6-1b936009ced0)--- Tente executar um endpoint protegido novamente, o resultado obtido será semelhante ao da imagem

OBS: O token gerado tem validade de 1 minuto após esse tempo será necessário fazer lpgin novamente

### Passo 4: Testar um Endpoint
1. Selecione um endpoint e clique para expandir.
2. Preencha os parâmetros necessários.
3. Clique em **Try it out** para enviar uma requisição.
4. O Swagger retorna a resposta, incluindo:
   - **Código de status** (ex.: 200 OK, 404 Not Found).
   - **Corpo da resposta** no formato JSON.
   - **Cabeçalhos da requisição**.

### Passo 4: Revisar a Resposta

- Verifique a resposta retornada e, se necessário, ajuste os parâmetros e tente novamente.
- O **tipo de dados** (string, int, bool, double, etc.) deve ser conferido ao preencher os parâmetros.

--- 

## Machine Learning com ML NET

API em .NET Core para previsão de sentimento a partir de comentários e avaliações de clientes, usando aprendizado de máquina com o ML.NET. A API lê comentários e avaliações de clientes, passa por um modelo de ML treinado, e retorna se o sentimento é "Positivo" ou "Negativo". Ele não usa técnicas avançadas de Processamento de Linguagem Natural (NLP) para interpretar o contexto ou as nuances do texto do comentário. Em vez disso, a decisão sobre o sentimento é influenciada mais pela avaliação numérica (de 1 a 5) do que pelo conteúdo textual do comentário. Este modelo foi criado conforme os passos ensinados em aula com algumas modificações para atender os requisitos do resultado desejado


## Evidências:

![image](https://github.com/user-attachments/assets/ea44237f-5072-4d97-bd75-0be671d52018)

![image](https://github.com/user-attachments/assets/9fccd113-141b-4b35-aeec-26ad8843d7da)

![image](https://github.com/user-attachments/assets/d0d980f7-f178-44f4-83af-334f0fb85065)

![image](https://github.com/user-attachments/assets/b94e0da8-e962-454b-82b3-18164a544f2a)



![endpoints](https://github.com/user-attachments/assets/910a6840-7ca1-40ec-b873-030b3bb1e342)

![post_consumidor](https://github.com/user-attachments/assets/1986dd20-5fbb-427c-9458-72a61a21a5cb)

![insert_consumidor](https://github.com/user-attachments/assets/eca6006a-2f1c-4cf8-817a-710e3ec84a77)

![get_consumidores](https://github.com/user-attachments/assets/00abaf93-42fc-4334-8a31-636ba494120a)

![get_consumidor_id](https://github.com/user-attachments/assets/22122196-7d0c-4eb9-90fa-1d781645c0dd)

![put_consumidor](https://github.com/user-attachments/assets/c4674690-59bc-478f-85c2-da3fa7c88979)

![delete_consumidor](https://github.com/user-attachments/assets/9afe6379-5769-42f0-9f3c-553a287aa5a5)




![post_info](https://github.com/user-attachments/assets/5ebb451c-a28c-44a2-998d-2b8c79f6de1c)

![insert_info](https://github.com/user-attachments/assets/4d0450a1-4137-43f5-8d4e-45711b946333)

![get_infos](https://github.com/user-attachments/assets/124cef49-9bf7-4b16-a7aa-b4167032c671)

![get_info_id_info](https://github.com/user-attachments/assets/9adb0498-7f0c-451e-ba7a-a5781d2fc274)

![tabela_info](https://github.com/user-attachments/assets/e99da217-55ec-40c8-a5f6-5d77e6b25b07)

![get_info_id_consumidor](https://github.com/user-attachments/assets/7e7bfee2-d8a7-4513-8301-b872a5a9ecb9)

![put_info](https://github.com/user-attachments/assets/a84c2921-5402-4c05-9399-52a513e6b877)

![delete_info](https://github.com/user-attachments/assets/c289eff3-314f-4735-92d3-19a9621c950b)

![deleteb_info](https://github.com/user-attachments/assets/f0ba861a-99c8-4601-8138-9176c52cea36)
