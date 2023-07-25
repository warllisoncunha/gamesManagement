# gamesManagement

Problema: Seus amigos vivem pedindo seus jogos emprestados. Muitas vezes você quer jogar um jogo e não sabe com quem está. Pensando nisso, 
crie um sistema que você possa gerenciar os empréstimos dos seus jogos. O sistema deverá permitir a inserção/edição/exclusão de amigos e jogos, 
além de permitir o gerenciamento e visualização dos seus jogos, dos amigos e qual jogo está com quem.

- Diante do problema proposto, foi criada uma web-api em .net 7, com  controle de segurança JWT, gerado a apartir da integração com o Firebase. Dessa forma a api não precisa se preocupar em deter o controle de usuários,
usando a infra e segurança google;
- Esta API tem como mecanismo para armazenamento de dados o SQL Server;
- Para aferir o corretude do código, foram implementados 24 testes unitários no progeto 'gamesManagement.UnitTest' , usando o XUnit como framework;
- Foi implementado um script CI para validar os steps da aplicação, podendo ser conferido na url: https://github.com/warllisoncunha/gamesManagement/actions;
- Toda a API e banco de Dados, estão em imagem docker. Para subir o container são necessários os seguintes passos:
  1. Faça um clone do projeto em seu diretório: 'git-clone https://github.com/warllisoncunha/gamesManagement.git'
  2. Faça um checkout para a branch master: git checkout master
  3. Garanta que tenha o docker e docker compose configurados em sua máquina, caso não possua, acesse a url(https://www.docker.com) e instale de acordo com o seu SO
  4. Abra o seu PoweShell, ou Bash, ou CMD e navegue até a raiz do projeto;
  5. Execute o comando 'docker-compose up', após isso o compose será criado com os containes da API e SQL Server
  6. A porta que está sendo exposta para a api é a 443, então acesse 'https://localhost/swagger/index.html' no navegador para o swagger abrir.
      PS.: Caso a porta não seja essa, rode o comando 'docker container list -a' e veja qual porta foi definida para a api, e insira no navegador: 'https://localhost:[porta]/swagger/index.html'
  7. Para acessar os Endpoints pelo swagger, é necessário fazer a autenticação no firebase, com o postman que está na raiz do projeto, e inserir o token gerado no swagger como: 'bearer + token'

- Um projeto de front-end foi criado na pasta 'gamesManagement.web', porém devido a falta de tempo não foi possível finalizá-lo, entretanto foi criado uma tela de login e um menu com opções.
- O projeto de front-end foi desenvolvido usando angular 16, bootstrap e html
- Para executar o projeto:
    1. A abra o diretório do projeto WEB com o VSCode
    2. execute o comando: 'npm install'
    3. logo após inicie o servidor angular com: 'ng serve' ou 'npm run start'
    4. O projeto rodará em 'http://localhost:4200/login'
    5. entre com a credenciais: email: warllisonlima@gmail.com / senha: gamesEld
    6. Você será redirecionado para a tela home
 
  - CASO NÃO CONSIGA IMPORTAR O ARQUIVO POSTMAN QUE ESTÁ NA RAIZ DO PROJETO:
    1. Crie uma nova requisição POST com o postman e insira na url: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyAtPcjbxwmbhKeNNbZnSTCa9MXZloMQKWE'
    2. Insira no body este json:
       {
        "returnSecureToken": true,
        "email": "warllisonlima@gmail.com",
        "password": "gamesEld"
       }
    3. Faça o request, o token estará no response

  Coloco-me à disposição para responder eventuais dúvidas e esclarecimentos. 
