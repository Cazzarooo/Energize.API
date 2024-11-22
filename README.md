# **Energize: Plataforma de Monitoramento Energético**

O **Energize** é uma solução desenvolvida com **.NET Core** para monitorar, analisar e otimizar o consumo de energia elétrica, promovendo sustentabilidade e eficiência energética. Esta aplicação modular utiliza padrões de design modernos, testes automatizados e documentação completa para entregar uma API robusta e escalável.

---

## **Resumo do Projeto**

- **Código-Fonte:** Disponível no [GitHub](https://github.com/seu-usuario/energize).  
- **Documentação:** Elaborada diretamente neste arquivo README.md e em uma interface interativa gerada com **Swagger**.  
- **Testes Unitários:** Implementados utilizando **xUnit** e **Moq**.  
- **Padrões de Design:** Inclui **Repository Pattern** e **Dependency Injection** para modularidade e flexibilidade.  
- **Clean Code:** O código foi desenvolvido seguindo as melhores práticas, utilizando princípios como **SOLID** e padrões de codificação consistentes.  

---

## **Tabela de Conteúdo**

1. [Visão Geral](#visão-geral)  
2. [Funcionalidades](#funcionalidades)  
3. [Estrutura do Projeto](#estrutura-do-projeto)  
4. [Documentação das APIs](#documentação-das-apis)  
5. [Configuração e Execução](#configuração-e-execução)  
6. [Testes Unitários](#testes-unitários)  
7. [Design Patterns](#design-patterns)  
8. [Equipe do Projeto](#equipe-do-projeto)

---

## **Visão Geral**

O **Energize** foi projetado para resolver os desafios do consumo energético, fornecendo dados e insights para ajudar na redução de desperdício e otimização do uso de energia elétrica.  

A solução é composta por:  
- **API desenvolvida em .NET Core:** Gerencia as operações do sistema de forma segura e eficiente.  
- **Banco de Dados Relacional:** Utilizando **Entity Framework Core** para persistência.  
- **Documentação via Swagger:** Fornece uma interface de teste e consulta das APIs.  
- **Testes Unitários:** Garantem qualidade e confiabilidade do código.  

---

## **Funcionalidades**

- **Monitoramento em Tempo Real:** Receba dados sobre corrente, tensão e potência elétrica coletados por dispositivos IoT.  
- **Análise e Otimização:** Identifique padrões de consumo e receba recomendações para economia de energia.  
- **Documentação Automatizada:** APIs documentadas com Swagger para fácil integração.  
- **Modularidade e Escalabilidade:** Estrutura projetada para evoluir com o aumento da demanda.  

---

## **Estrutura do Projeto**

A estrutura do projeto segue o padrão **Clean Architecture**, separando responsabilidades em camadas para maior organização e manutenibilidade:

- **`Energize.API`**: Contém os controladores e endpoints RESTful.  
- **`Energize.EnergiaRenovavel.Application`**: Implementa os casos de uso e orquestra as regras de negócio.  
- **`Energize.EnergiaRenovavel.Domain`**: Define as entidades de domínio e as interfaces principais.  
- **`Energize.EnergiaRenovavel.Data`**: Gerencia o acesso ao banco de dados utilizando **Entity Framework Core**.  
- **`Energize.EnergiaRenovavel.IoC`**: Configurações de injeção de dependência e registro de serviços.  
- **`Energize.EnergiaRenovavel.Tests`**: Contém testes unitários escritos com **xUnit** e **Moq**.  

---

## **Documentação das APIs**

A documentação das APIs foi criada com **Swagger**, permitindo a exploração e o teste direto no navegador.  

### **Acessando o Swagger**
Após iniciar a aplicação, acesse a URL abaixo para abrir a interface interativa:  
```
http://localhost:5000/swagger
```

Na interface, você pode:
- Visualizar todos os endpoints disponíveis.  
- Testar as APIs diretamente do navegador.  
- Consultar a estrutura de cada request e response.  

---

## **Configuração e Execução**

### **Pré-Requisitos**

1. **.NET SDK** (versão recomendada: 7.0 ou superior).  
2. **Banco de Dados Relacional** (ex.: SQL Server ou MySQL).  
3. Ferramentas como **Visual Studio** ou **Visual Studio Code**.  

### **Passos para Configurar**

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/seu-usuario/energize.git
   cd energize
   ```

2. **Restaure os pacotes NuGet**:
   ```bash
   dotnet restore
   ```

3. **Configure o Banco de Dados**:
   - Configure a string de conexão no arquivo `appsettings.json`.  
   - Execute as migrações para criar as tabelas:
     ```bash
     dotnet ef database update
     ```

4. **Execute a Aplicação**:
   ```bash
   dotnet run
   ```

---

## **Testes Unitários**

Os testes foram implementados utilizando **xUnit** e **Moq**.  

### **Cobertura dos Testes**
- Validação de regras de negócio na camada de domínio.  
- Testes dos casos de uso na camada de aplicação.  
- Simulação de dependências utilizando **Moq** para garantir isolamento.  

### **Executando os Testes**
1. Navegue até o diretório de testes:
   ```bash
   cd Energize.EnergiaRenovavel.Tests
   ```
2. Execute os testes:
   ```bash
   dotnet test
   ```

---

## **Design Patterns**

O projeto utiliza os seguintes padrões de design:  

1. **Repository Pattern**:
   - Facilita o acesso e a manipulação de dados.
   - Abstrai as operações do banco de dados para maior flexibilidade.  

2. **Dependency Injection**:
   - Gerencia dependências e reduz o acoplamento entre as camadas.  
   - Implementado utilizando o **Microsoft.Extensions.DependencyInjection**.  

### **Benefícios dos Padrões**
- Facilita a substituição de componentes e integração de novos recursos.  
- Reduz a complexidade do código e melhora a testabilidade.  

---

## **Equipe do Projeto**

- **Leonardo Valentim de Souza** (RM 98660)  
- **João Victor Leite Firmino** (RM 97714)  
- **Gustavo dos Santos Correa** (RM 99618)  
- **Lucas Cazzaro** (RM 551201)  
- **Ronaldo Riyudi Noda** (RM 99219)  
---
