# ServerEngine

Projeto: Servidor e Cliente via Sockets

📌 Descrição

Este projeto implementa um servidor utilizando sockets para comunicação entre processos. Ele foi desenvolvido com o objetivo de aprofundar conhecimentos sobre redes, protocolo HTTP e manipulação de requisições.

🛠 Tecnologias Utilizadas

C# com .NET

Sockets TCP/IP

HTTP personalizado para resposta de requisições

Manipulação de Threads para conexões simultâneas

⚙️ Funcionalidades

📡 Servidor capaz de processar requisições HTTP GET e POST
📄 Serviço de entrega de arquivos HTML e CSS
🔀 Processamento de múltiplas conexões via threads
📡 Log de requisições e respostas no console

🏗 Estrutura do Projeto

/ServerEngine
  |-- /Engine
      |-- ServeHtml.cs  # Lida com a resposta de requisições HTTP e rotas
      |-- Messages.cs   # Gera cabeçalhos HTTP personalizados
      |-- Translate.cs  # Converte as respostas do servidor e envia via socket
  |-- /Application
      |-- /html
          |-- mainPage.html
          |-- formResponse.html
      |-- /css
          |-- style.css
          |-- formResponse.css
  |-- Program.cs        # Inicializa o servidor

🚀 Como Executar

📌 Clonando o repositório

git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio

📡 Executando o Servidor

Abra o projeto no Visual Studio ou VS Code

Compile e execute o Servidor

O servidor iniciará e ficará aguardando conexões

🔗 Testando com o Cliente (via cURL)

curl -X GET http://localhost:porta/

curl -X POST http://localhost:porta/race -d "firstname=John&lastname=Doe"

🛠 Melhorias Futuras

Implementação de banco de dados para armazenar dados recebidos via POST

Logs detalhados das requisições recebidas

📜 Licença

Este projeto é distribuído sob a Licença MIT. Sinta-se à vontade para utilizar e contribuir!


