# Golden Data

**Golden Data** é uma plataforma inovadora que facilita a troca direta de informações entre empresas e clientes, maximizando a personalização de serviços e campanhas de marketing, especialmente voltada para o comércio eletrônico. Nosso objetivo é aprimorar a experiência do cliente e aumentar o retorno sobre investimento (ROI) das empresas por meio de segmentação precisa e conteúdo direcionado.

## Funcionamento da Plataforma

Os clientes da Golden Data são incentivados a compartilhar seus interesses por meio de checkboxes em nosso aplicativo, especificando preferências de produtos e serviços que consomem online. As empresas, por sua vez, podem filtrar essas informações para direcionar ofertas e anúncios de forma mais assertiva, otimizando a comunicação e atingindo seu público-alvo com eficiência.

## Autenticação e Validação de Dados

Para garantir a integridade das informações e estar em conformidade com a Lei Geral de Proteção de Dados (LGPD), utilizamos validação de CPF para clientes e CNPJ para empresas. A plataforma oferece dois tipos de login:

- **Clientes**: Validação por CPF.
- **Empresas**: Validação por CNPJ.

## Planos de Serviço

A Golden Data oferece uma versão gratuita de avaliação e dois planos pagos para empresas:

- **Plano Beta**: Acesso completo aos dados dos clientes mediante pagamento integral.
- **Plano Sócios**: Além de descontos nos serviços, permite o envio de cupons de desconto diretamente aos clientes, potencializando as vendas.

## Entrega de Cupons

Os cupons de desconto são enviados por email, criando um canal direto e personalizado entre empresas e clientes. Ao clicar no cupom, o cliente é direcionado à tela de login para resgatar o desconto. Essa integração estimula o fornecimento de emails, permitindo uma comunicação mais eficiente.

## Tecnologias Utilizadas

Para proporcionar personalização e inteligência em tempo real, a Golden Data utiliza tecnologias avançadas:

- **Machine Learning**: Análise preditiva e segmentação inteligente dos dados dos clientes.
- **Deep Analytics**: Insights detalhados sobre comportamento e tendências de mercado.
- **IA Generativa**: Criação de conteúdo personalizado com base nos interesses e comportamentos dos clientes.

Essas tecnologias permitem que as empresas otimizem suas campanhas de marketing e criem conteúdos altamente relevantes para cada perfil de cliente.

## Benefícios para as Empresas

Com a Golden Data, as empresas podem:

- **Aumentar a taxa de conversão** por meio de campanhas segmentadas.
- **Melhorar a experiência do cliente** entregando ofertas no momento certo.
- **Realizar segmentações avançadas** para uma comunicação mais eficaz.
- **Criar conteúdo personalizado** alinhado com os interesses do público-alvo.
- **Identificar clientes em risco de churn** e agir preventivamente.
- **Otimizar a jornada do cliente**, do primeiro contato até a conversão.

## Arquitetura do Projeto

No estágio inicial do Golden Data, optamos por uma **arquitetura monolítica** para garantir um desenvolvimento ágil e de baixo custo. Essa abordagem facilita a validação do produto e do modelo de negócios, além de permitir modificações rápidas. No entanto, conforme a plataforma crescer, uma **migração gradual para microserviços** será considerada, a fim de garantir escalabilidade e maior flexibilidade no gerenciamento de serviços.

## Design Patterns Utilizados

Neste projeto, utilizamos dois padrões de design principais para estruturar o código e promover boas práticas de desenvolvimento: **Repository Pattern** e **Service Layer Pattern**. Esses padrões garantem que a aplicação seja modular, fácil de manter e escalável, promovendo a separação de responsabilidades e a redução de acoplamento entre as camadas.

### Repository Pattern

O **Repository Pattern** é usado para isolar a lógica de acesso a dados do restante da aplicação. Isso facilita a manutenção e a troca de fontes de dados (como bancos de dados ou APIs externas) sem afetar as camadas superiores do sistema. No nosso projeto, a classe `ApplicationDbContext.cs` (dentro da pasta **Data**) gerencia a interação com o banco de dados, enquanto os repositórios, se adicionados no futuro, encapsularão as operações CRUD.

Esse padrão também facilita a criação de testes unitários, pois permite o uso de repositórios falsos (mocked repositories) para simular interações com o banco de dados.

### Service Layer Pattern

O **Service Layer Pattern** é utilizado para manter a lógica de negócios separada da camada de apresentação (controladores) e da camada de dados. Isso promove a reutilização de código e facilita futuras alterações na lógica de negócios sem impacto direto nas camadas de interface ou persistência de dados.

Cada módulo da aplicação possui seus próprios serviços, como o `ConsumidorService.cs`, que gerencia a lógica relacionada a consumidores, garantindo que os controladores apenas orquestrem as chamadas sem conter lógica de negócios diretamente.

### DTO (Data Transfer Object)

Para garantir a segurança e eficiência na transferência de dados entre as camadas, usamos o padrão **Data Transfer Object (DTO)**. Os DTOs, como `CriarConsumidorDto.cs` e `EditarConsumidorDto.cs`, encapsulam os dados necessários para operações específicas, como criação ou edição de consumidores. Isso mantém a integridade dos dados e evita o envio de informações desnecessárias.

### Vantagens dos Padrões Utilizados

- **Manutenibilidade**: A separação clara das responsabilidades facilita a manutenção e adição de novas funcionalidades.
- **Testabilidade**: A lógica de negócios isolada em serviços e o uso do Repository Pattern tornam o código altamente testável, promovendo testes unitários e de integração.
- **Escalabilidade**: À medida que a aplicação cresce, a estrutura modular permite adicionar novas funcionalidades e fontes de dados com o mínimo de impacto no código existente.

Essa arquitetura garante que o sistema permaneça limpo, desacoplado e fácil de evoluir, fornecendo uma base sólida para futuras implementações, como integração com novas fontes de dados, serviços externos e funcionalidades adicionais.

## Passo a Passo para Testar a API com o Swagger

### Passo 1: Abrir o Swagger UI
Após executar a API, o navegador abrirá a interface do **Swagger UI**. A URL geralmente será algo como:

https://localhost:7273/swagger/index.html


(O número da porta pode variar conforme o ambiente de execução).

### Passo 2: Explorar os Endpoints
Na interface do **Swagger**, você verá a lista de todos os endpoints disponíveis em sua API, organizados por controladores.

- Cada endpoint terá uma breve descrição.
- O método HTTP associado (GET, POST, PUT, DELETE) será exibido.
- Haverá uma opção de expandir para visualizar detalhes, como parâmetros e respostas.

### Passo 3: Testar um Endpoint
1. Clique em um endpoint para expandi-lo.
2. Caso o endpoint exija parâmetros, como **body**, eles serão exibidos para preenchimento.
3. Após preencher os parâmetros necessários, clique em **Try it out**.
4. O Swagger enviará uma requisição para o endpoint e retornará a resposta, incluindo:
   - **Status code**
   - **Corpo da resposta**
   - **Cabeçalho da requisição**

### Passo 4: Verificar a Resposta
Após executar a requisição no Swagger:

1. A resposta será exibida logo abaixo, mostrando o **status HTTP** (ex.: 200 OK, 404 Not Found, etc.).
2. O **corpo da resposta** será mostrado no formato JSON (ou outro formato, dependendo do tipo de conteúdo retornado pela API).
3. Você pode revisar as informações e, se necessário, ajustar os parâmetros e tentar novamente.
4. Atente-se aos tipos de dados que o endpoint pede para preencher (string, int, bool, double...)



## Evidências:

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
